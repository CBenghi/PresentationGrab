
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

namespace PresentationGrab
{
    class ScreenManager : IDisposable
    {
        readonly BlobCounterBase differenceBlobFounder;
        Crop cropFilter;
        Subtract removeNoiseFilter = null;

        // this is the filter that we cache to compare from one frame to the next
        Subtract diffFilter = null;

        public ScreenManager()
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
            removeNoiseFilter = new Subtract(GetGrey());
        }

        private Rectangle cropRectangle = new Rectangle(
                    new System.Drawing.Point(456, 184),
                    new Size(2417 - 456, 1287 - 184)
                    );

        internal Rectangle CropRectangle
        {
            get => cropRectangle; 
            set
            {
                // if size is changed then 
                if (!value.Size.Equals(cropRectangle.Size))
                {
                    // start new image capture
                    diffFilter = null;
                }
                cropRectangle = value;
                cropFilter = new Crop(CropRectangle);
                removeNoiseFilter = new Subtract(GetGrey());
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

        public Bitmap GetCroppedBitmapFromScreen()
        {
            Bitmap printedScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                            Screen.PrimaryScreen.Bounds.Height,
                                            System.Drawing.Imaging.PixelFormat.Format24bppRgb
                                            );
            Graphics graphics = Graphics.FromImage(printedScreen as System.Drawing.Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printedScreen.Size);

            return DoCrop(printedScreen);
        }

        private int noiseThreshold = 5;
        public int NoiseThreshold
        {
            get => noiseThreshold; 
            set
            {
                noiseThreshold = value;
                removeNoiseFilter = new Subtract(GetGrey());
            }
        }

        public Bitmap GetGrey()
        {
            var greyIntensity = NoiseThreshold;
            Bitmap printedScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                            Screen.PrimaryScreen.Bounds.Height,
                                            System.Drawing.Imaging.PixelFormat.Format24bppRgb
                                            );
            Graphics graphics = Graphics.FromImage(printedScreen as System.Drawing.Image);
            graphics.Clear(Color.FromArgb(255, greyIntensity, greyIntensity, greyIntensity));
            return DoCrop(printedScreen);
        }

        internal Bitmap DoCrop(Bitmap inputImage)
        {
            var cropped = cropFilter.Apply(inputImage);
            return cropped;
        }

        internal DirectoryInfo OutputDirectory { get; set; } = new DirectoryInfo(@".\DebugBlob\output\");

        Bitmap currentBackground;
        DateTime currentBackgroundTimeStamp;
        bool needPointerRemoval = false;

        [Flags]
        public enum Results
        {
            NothingDone = 0,
            NewImage = 1,
            CorrectedImage = 2,
            PointerLogged = 4
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
                bitmapUnderAnalysis = GetCroppedBitmapFromScreen();

            // remove control region in the bottom left
            //
            bitmapUnderAnalysis = RemoveButtonsRegion(bitmapUnderAnalysis);


            if (diffFilter == null)
            {
                // we need to init the first image
                SetBitmap(timeStamp, bitmapUnderAnalysis); // this also sets need to remove pointer
                ret.ResultingBitmap = bitmapUnderAnalysis;
                ret.ResultActions = Results.NewImage;
            }
            else
            {
                var imageCapture = forceImageCapture;
                if (!imageCapture)
                {
                    var diffImage = diffFilter.Apply(bitmapUnderAnalysis);

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
                    SetBitmap(timeStamp, bitmapUnderAnalysis); // this also sets need to remove pointer
                    ret.ResultActions = Results.NewImage;
                    ret.ResultingBitmap = bitmapUnderAnalysis;
                    if (needPointerRemoval)
                    {
                        if (WriteMouseCoords(pointerToRemove.X, pointerToRemove.Y, timeStamp, "capture"))
                            ret.ResultActions |= Results.PointerLogged;
                    }
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

        public Bitmap RemoveButtonsRegion(Bitmap bitmapUnderAnalysis)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddRectangle(new Rectangle(0, 1066, 307, 37));

            Graphics graphics = Graphics.FromImage(bitmapUnderAnalysis);
            graphics.FillPath(Brushes.White, p);
            return bitmapUnderAnalysis;
        }

        Accord.Point pointerToRemove;

        readonly PointerDetector pointerDetector = new PointerDetector();

        private void SetBitmap(DateTime timeStamp, Bitmap bitmapUnderAnalysis)
        {
            SaveCurrentBackground();
            currentBackground = bitmapUnderAnalysis;
            diffFilter = new Subtract(currentBackground);
            if (TrackPowerPointLaser)
                needPointerRemoval = pointerDetector.HasPointer(bitmapUnderAnalysis, out pointerToRemove);
            else
                needPointerRemoval = false;
            currentBackgroundTimeStamp = timeStamp;
        }

        internal DateTime RecordingStartDateTime { get; set; }

        private void SaveCurrentBackground()
        {
            if (currentBackground != null)
            {
                var outName = $"{currentBackgroundTimeStamp:yyyy-dd-M--HH-mm-ss}.png";
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
