﻿
using System;
using Accord.Imaging.Filters;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Imaging;
using Accord.Math;
using System.IO;
using System.Drawing.Drawing2D;
using Accord.Statistics.Distributions.Univariate;
using Accord;
using System.Xml.XPath;

namespace PresentationGrab.ImageProcessing
{
    class CaptureManager : IDisposable
    {
        readonly BlobCounterBase differenceBlobFounder;
        Crop cropFilter;
        Subtract removeNoiseFilter = null;

        // this is the filter that we cache to compare from one frame to the next
        Subtract diffFilter = null;


        float _scaling = 1.0f;

        public CaptureManager()
        {
            differenceBlobFounder = new BlobCounter
            {
                // set filtering options
                FilterBlobs = true,
                MinWidth = 6,
                MinHeight = 6,
                ObjectsOrder = ObjectsOrder.XY
            };


            cropFilter = new Crop(CropRectangle);

            _scaling = ScreenCapture.GetScalingFactor();
        }

        private Rectangle cropRectangle = new Rectangle(
                    new System.Drawing.Point(456, 184),
                    new Size(1907, 1070)
                    );

        internal Rectangle FixRect(Rectangle rect)
        {
            var r = new Rectangle(
                (int)(rect.X * _scaling),
                (int)(rect.Y * _scaling),
                (int)(rect.Width * _scaling),
                (int)(rect.Height * _scaling)
                );
            return r;
        }


        public bool CropActive
        {
            set
            {
                if (value == false)
                {
                    cropFilter = null;
                }
            }
        }




        internal Rectangle CropRectangle
        {
            get => cropRectangle; 
            set
            {
                CropActive = true;
                // if size is changed then 
                if (!value.Size.Equals(cropRectangle.Size))
                {
                    // start new image capture
                    diffFilter = null;
                }
                cropRectangle = value;
                cropFilter = new Crop(CropRectangle);
                removeNoiseFilter = null;
            }
        }

        public Bitmap RemoveAlpha(Bitmap orig)
        {
            Bitmap clone = new Bitmap(orig.Width, orig.Height,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (Graphics gr = Graphics.FromImage(clone))
            {
                gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
            }
            return clone;
        }

        public Bitmap GetCroppedBitmap()
        {
            if (capturePtr != IntPtr.Zero)
            {
                var img = ScreenCapture.CaptureWindow(capturePtr) as Bitmap;
                if (img == null)
                {
                    capturePtr = IntPtr.Zero;
                    return null;
                }
                // Clipboard.SetImage(img);
                Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                Graphics graphics = Graphics.FromImage(bmp);
                graphics.DrawImage(img, 0, 0);
                // graphics.DrawEllipse(Pens.Red, new Rectangle(0, 0, 100, 100));
                return DoCrop(bmp);
            }
            else
            {
                Bitmap printedScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                                Screen.PrimaryScreen.Bounds.Height,
                                                System.Drawing.Imaging.PixelFormat.Format24bppRgb
                                                );
                Graphics graphics = Graphics.FromImage(printedScreen as System.Drawing.Image);
                graphics.CopyFromScreen(0, 0, 0, 0, printedScreen.Size);

                return DoCrop(printedScreen);
            }
        }

        private int noiseThreshold = 5;
        public int NoiseThreshold
        {
            get => noiseThreshold; 
            set
            {
                noiseThreshold = value;
                removeNoiseFilter = null;
            }
        }

        public Bitmap GetGrey(Bitmap relevantBmp)
        {
            var greyIntensity = NoiseThreshold;
            Bitmap makingGrey = new Bitmap(relevantBmp.Width,
                                            relevantBmp.Height,
                                            System.Drawing.Imaging.PixelFormat.Format24bppRgb
                                            );
            Graphics graphics = Graphics.FromImage(makingGrey);
            graphics.Clear(Color.FromArgb(255, greyIntensity, greyIntensity, greyIntensity));
            return makingGrey;
        }

        internal Bitmap DoCrop(Bitmap inputImage)
        {
            if (cropFilter != null)
            {
                var cropped = cropFilter.Apply(inputImage);
                return cropped;
            }
            return inputImage;
        }

        internal DirectoryInfo OutputDirectory { get; set; } = new DirectoryInfo(@"C:\Data\Work\Wip\Capture\");

        Bitmap currentBackground;
        DateTime currentBackgroundTimeStamp;
        bool needPointerRemoval = false;

        [Flags]
        public enum Results
        {
            NothingDone = 0,
            NewImage = 1,
            CorrectedImage = 2,
            PointerLogged = 4,
            WindowNotFound = 8
        }

        public class ScreenManagerResult
        {
            public Results ResultActions { get; set; } = Results.NothingDone;
            public Bitmap ResultingBitmap { get; set; } = null;
            public int TotalDifferentArea { get; internal set; } = -1;
        }


        public bool TrackPowerPointLaser { get; set; } = true;

        public int ImageDifferenceThreshold { get; set; } = 2400;

        internal ScreenManagerResult CheckNew(DateTime timeStamp, bool forceImageCapture = false, Bitmap bitmapUnderAnalysis = null)
        {
            ScreenManagerResult ret = new ScreenManagerResult();

            // var s = new Stopwatch(); s.Start();
            if (bitmapUnderAnalysis == null)
            {
                bitmapUnderAnalysis = GetCroppedBitmap();
                if (bitmapUnderAnalysis == null)
                {
                    ret.ResultActions |= Results.WindowNotFound;
                    return ret;
                }
            }
            

            // remove control region in the bottom left
            //
            bitmapUnderAnalysis = RemoveButtonsRegion(bitmapUnderAnalysis);
            if (diffFilter == null || diffFilter.OverlayImage.Width != bitmapUnderAnalysis.Width || diffFilter.OverlayImage.Height != bitmapUnderAnalysis.Height)
            {
                // we need to init the first image
                ret.ResultActions = SetBitmap(timeStamp, bitmapUnderAnalysis); // this also sets need to remove pointer
                ret.ResultingBitmap = bitmapUnderAnalysis;
                removeNoiseFilter = null;
            }
            else
            {
                var imageCapture = forceImageCapture;
                if (!imageCapture)
                {
                    var diffImage = diffFilter.Apply(bitmapUnderAnalysis);
                    if (removeNoiseFilter == null)
                        removeNoiseFilter = new Subtract(GetGrey(diffImage));
                    diffImage = removeNoiseFilter.Apply(diffImage);
                    differenceBlobFounder.ProcessImage(diffImage);

                    Blob[] blobs = differenceBlobFounder.GetObjectsInformation();
                    var totArea = blobs.Sum(x => x.Area);
                    ret.TotalDifferentArea = totArea;
                    imageCapture = totArea > ImageDifferenceThreshold;
                }

                if (imageCapture)
                {
                    // a new image background
                    //
                    ret.ResultActions = SetBitmap(timeStamp, bitmapUnderAnalysis); // this also sets need to remove pointer
                    ret.ResultingBitmap = bitmapUnderAnalysis;
                    if (needPointerRemoval)
                    {
                        if (WriteMouseCoords(pointerToRemove.X, pointerToRemove.Y, timeStamp, "capture"))
                            ret.ResultActions |= Results.PointerLogged;
                    }
                    SaveTemp();
                }
                else if (TrackPowerPointLaser)
                {
                    // track pointer
                    //
                    if (pointerDetector.HasPointer(bitmapUnderAnalysis, out Accord.Point pointFound))
                    {
                        if (WriteMouseCoords(pointFound.X, pointFound.Y, timeStamp, "capture"))
                            ret.ResultActions |= Results.PointerLogged;
                        // if we have a pointer and the original image needs it removed then copy part of image over
                        if (needPointerRemoval && pointFound.DistanceTo(pointerToRemove) > 40)
                        {
                            ret.ResultActions |= Results.CorrectedImage;
                            Rectangle copyRec = new Rectangle((int)pointerToRemove.X - 16, (int)pointerToRemove.Y - 16, 32, 32);
                            CopyRegionIntoImage(bitmapUnderAnalysis, copyRec, currentBackground, copyRec);
                            ret.ResultingBitmap = currentBackground;
                            needPointerRemoval = false;
                        }
                    }
                }
            }
            return ret;
        }

        public int ButtonregionWidth { get; set; } = 0;
        public int ButtonregionHeight { get; set; } = 0;


        public Bitmap RemoveButtonsRegion(Bitmap bitmapUnderAnalysis)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddRectangle(new Rectangle(0, bitmapUnderAnalysis.Height - ButtonregionHeight, ButtonregionWidth, ButtonregionHeight));

            Graphics graphics = Graphics.FromImage(bitmapUnderAnalysis);
            graphics.FillPath(Brushes.White, p);
            return bitmapUnderAnalysis;
        }

//         DateTime LastCaptureTime { get; set; } = DateTime.Now;

        Accord.Point pointerToRemove;

        PointerDetector pointerDetector = new PointerDetector();

        TimeSpan MinDeltaCaptureTime = new TimeSpan(0, 0, 2); // 2 seconds.

        private Results SetBitmap(DateTime timeStamp, Bitmap bitmapUnderAnalysis)
        {
            var ret = Results.NewImage;
            // decides whether to save the current background depending on elapsed time
            //
            var delta = timeStamp - currentBackgroundTimeStamp;
            if (delta > MinDeltaCaptureTime)
            {
                SaveCurrentBackground(); // save the old image and start afresh
            }
            else
            {
                // saves to temp but keeps previos timestamp, to save propertly later.
                ret = Results.CorrectedImage;
                timeStamp = currentBackgroundTimeStamp; // keep the timestamp of the dropped image.
            }
            currentBackground = bitmapUnderAnalysis;
            diffFilter = new Subtract(currentBackground);
            if (TrackPowerPointLaser)
            {
                if (pointerDetector == null)
                {
                    pointerDetector = new PointerDetector();
                }
                needPointerRemoval = pointerDetector.HasPointer(bitmapUnderAnalysis, out pointerToRemove);
            }
            else
                needPointerRemoval = false;
            currentBackgroundTimeStamp = timeStamp;
            return ret;
        }

        internal DateTime RecordingStartDateTime { get; set; }

        private void SaveCurrentBackground()
        {
            if (currentBackground != null)
            {
                var outName = $"{currentBackgroundTimeStamp:yyyy-M-dd--HH-mm-ss}.png";
                if (RecordingStartDateTime != default(DateTime))
                {
                    var diffTime = currentBackgroundTimeStamp - RecordingStartDateTime;
                    var secs = (int)diffTime.TotalSeconds;
                    var mins = secs / 60;
                    secs = secs % 60;
                    if (mins > 0)
                        outName = $"{mins}{secs:D2}";
                    else
                        outName = secs.ToString();
                    outName += " - .png";
                }
                // need to write the image to disk
                if (!OutputDirectory.Exists)
                    OutputDirectory.Create();
                var fullname = Path.Combine(OutputDirectory.FullName, outName);
                try
                {
                    currentBackground.Save(fullname);
                    currentBackground = null;
                }
                catch (Exception)
                {
                    // Clipboard.SetImage(currentBackground);
                }
            }
        }
        private void SaveTemp()
        {
            if (currentBackground != null)
            {
                var outName = $"temp.png";
                // need to write the image to disk
                if (!OutputDirectory.Exists)
                    OutputDirectory.Create();
                var fullname = Path.Combine(OutputDirectory.FullName, outName);
                try
                {
                    currentBackground.Save(fullname);
                }
                catch (Exception)
                {
                    // Clipboard.SetImage(currentBackground);
                }
            }
        }

        public static void CopyRegionIntoImage(Bitmap srcBitmap, Rectangle srcRegion, Bitmap destBitmap, Rectangle destRegion)
        {
            using (Graphics grD = Graphics.FromImage(destBitmap))
            {
                grD.DrawImage(srcBitmap, destRegion, srcRegion, GraphicsUnit.Pixel);
            }
        }


        int lastX = 0;
        int lastY = 0;
        private bool disposedValue;
        internal IntPtr capturePtr = IntPtr.Zero;

        internal string GetLyricsTimestamp(int playerPositionMilliseconds)
        {
            int seconds = playerPositionMilliseconds / 1000;
            int milliseconds = playerPositionMilliseconds % 1000;
            int minutes = seconds / 60;
            seconds = seconds % 60;

            return $"[{minutes:D3}:{seconds:D2}.{milliseconds:D3}] ";
        }


        private bool WriteMouseCoords(double pointX, double pointY, DateTime timeStamp, string extra)
        {
            if (!OutputDirectory.Exists)
                OutputDirectory.Create();
            int roundX = (int)Math.Round(pointX);
            int roundY = (int)Math.Round(pointY);

            if (roundX == lastX && roundY == lastY)
                return false;

            lastX = roundX;
            lastY = roundY;

            string ts = timeStamp.ToString("HH:mm:ss.fff ");
            if (RecordingStartDateTime != default(DateTime))
            {
                var diffTime = timeStamp - RecordingStartDateTime;
                var millis = (int)diffTime.TotalMilliseconds;
                ts = GetLyricsTimestamp(millis);
            }

            var fullname = Path.Combine(OutputDirectory.FullName, "cursor.txt");
            FileInfo f = new FileInfo(fullname);
            using (var writer = f.AppendText())
            {
                writer.WriteLine($"{ts}{roundX}, {roundY}, \"{extra}\"");
            }
            return true;
        }

        internal void WriteCursorPosition()
        {
            var pos = Cursor.Position;
            var dx = pos.X - cropRectangle.X;
            var dy = pos.Y - cropRectangle.Y;

            if (dx < 0 || dy < 0 || dx > cropRectangle.Width || dy > cropRectangle.Height)
                return;
            WriteMouseCoords(dx, dy, DateTime.Now, "user");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    SaveCurrentBackground();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ScreenManager()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
