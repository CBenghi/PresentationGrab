using Accord.Imaging.Filters;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PresentationGrab.ImageProcessing
{
    class ProcessedConverter
    {
        private Rectangle cropper;
        Crop cropFilter;
        bool doCrop = false;

        public Rectangle Cropper
        {
            get => cropper;

            set
            {
                cropper = value;
                cropFilter = new Crop(cropper);
                doCrop = true;
            }
        }

        internal bool Process(string L, string P)
        {
            DirectoryInfo source = new DirectoryInfo($@"C:\Data\Work\Esame Stato\SupportingMedia\T{L}\P{P}");
            if (!source.Exists)
            {
                source = new DirectoryInfo(@"C:\Data\Work\Wip\Capture\");
                source = new DirectoryInfo(@"C:\Data\Work\Wip\Capture\2020-6-24 - 31\");
            }
            DirectoryInfo destParent = new DirectoryInfo($@"C:\Data\Work\Esame Stato\SupportingMedia\L{L}");
            if (!destParent.Exists)
                destParent.Create();
            DirectoryInfo dest = new DirectoryInfo($@"C:\Data\Work\Esame Stato\SupportingMedia\L{L}\P{P}");
            if (!dest.Exists)
                dest.Create();

            DirectoryInfo musicDir = new DirectoryInfo($@"C:\Data\Work\Esame Stato\Audio\L{L}");
            if (!musicDir.Exists)
            {
                System.Windows.Forms.MessageBox.Show($"Music dir not found '{musicDir.FullName}'.");
                return false;
            }
            var musicFile = musicDir.GetFiles($"L{L}P{P}*.mp3").FirstOrDefault();
            if (musicFile == null)
            {
                System.Windows.Forms.MessageBox.Show($"Music file not found in {musicDir.FullName}. Opening folder after ok.");
                System.Diagnostics.Process.Start(musicDir.FullName);
                return false;
            }
            Process(source, dest, musicFile);
            return true;
        }

        internal void Process(DirectoryInfo source, DirectoryInfo dest, FileInfo musicFile)
        {
            if (!musicFile.Exists)
            {
                System.Windows.Forms.MessageBox.Show("Audio file missing.", "Error", System.Windows.Forms.MessageBoxButtons.OK);
                return;
            }
            Regex r = new Regex(@"(\d+)-(\d+)-(\d+)\.mp3$");
            var m = r.Match(musicFile.Name);
            if (!m.Success)
                return;
            var hou = Convert.ToInt32(m.Groups[1].Value);
            var min = Convert.ToInt32(m.Groups[2].Value);
            var sec = Convert.ToInt32(m.Groups[3].Value);

            var imagesFiles = source.GetFiles("*.png");
            var dates = imagesFiles.Select(x => CapturedImage.GetTimeStampDate(x));
            var mindate = dates.Min().Date;
            var audioDateTimeStart = mindate.AddHours(hou).AddMinutes(min).AddSeconds(sec);

            TimeSpan duration = new TimeSpan(24, 0, 0); // a full day, if something goes wrong in reading the mp3
            using (var reader = new Mp3FileReader(musicFile.FullName))
            {
                duration = reader.TotalTime;
            }
            // var audioDateTimeEnd = mindate + duration;


            // process images
            foreach (FileInfo imagefile in imagesFiles)
            {
                ProcessImageFile(imagefile, audioDateTimeStart, dest, duration);
            }
            var cursorName = source.GetFiles("cursor.txt").FirstOrDefault();
            if (cursorName == null)
                return;

            // process pointer
            var lyrDest = Path.Combine(dest.FullName, cursorName.Name);
            FileInfo fLyr = new FileInfo(lyrDest);
            using (var fw = fLyr.CreateText())
            {
                Regex rLyr = new Regex(@"(?<h>\d+):(?<m>\d+):(?<s>\d+)\.(?<ms>\d+) (?<x>\d+), (?<y>\d+)(?<rest>.*)");
                foreach (string line in File.ReadLines(cursorName.FullName))
                {
                    var mtLyr = rLyr.Match(line);
                    if (mtLyr.Success)
                    {
                        var lh = Convert.ToInt32(mtLyr.Groups["h"].Value);
                        var lm = Convert.ToInt32(mtLyr.Groups["m"].Value);
                        var ls = Convert.ToInt32(mtLyr.Groups["s"].Value);
                        var lms = Convert.ToInt32(mtLyr.Groups["ms"].Value);
                        var lx = Convert.ToInt32(mtLyr.Groups["x"].Value);
                        var ly = Convert.ToInt32(mtLyr.Groups["y"].Value);
                        var rest = mtLyr.Groups["rest"].Value;
                        var thisTs = mindate.AddHours(lh).AddMinutes(lm).AddSeconds(ls).AddMilliseconds(lms);
                        var thisDiff = thisTs - audioDateTimeStart;

                        if (thisDiff < new TimeSpan(0))
                            continue;
                        if (thisDiff > duration)
                            break;
                        if (doCrop)
                        {
                            lx = lx - cropper.X;
                            ly = ly - cropper.Y;
                        }
                        var outLine = GetLyricsTimestamp((int)thisDiff.TotalMilliseconds) + $"{lx}, {ly}{rest}";
                        fw.WriteLine(outLine);
                    }
                }
            }
        }

        private void ProcessImageFile(FileInfo image, DateTime audioDateTime, DirectoryInfo desitnationDir, TimeSpan maxDuration)
        {
            var imageTimeStamp = CapturedImage.GetTimeStampDate(image);
            var diff = imageTimeStamp - audioDateTime;
            if (diff > maxDuration)
                return;
            if (diff < new TimeSpan(0))
                return;
            var sec = (int)diff.TotalSeconds;
            var ts = GetImagesTimestamp(sec);
            var destName = ts + " - .png";
            var fullDest = Path.Combine(desitnationDir.FullName, destName);
            if (doCrop)
            {
                Bitmap b = new Bitmap(image.FullName);
                var cropped = cropFilter.Apply(b);
                cropped.Save(fullDest);
            }
            else
            {
                File.Copy(image.FullName, fullDest);
            }
        }

        internal static string GetImagesTimestamp(int seconds)
        {
            int minutes = seconds / 60;
            seconds = seconds % 60;
            if (minutes > 0)
                return minutes.ToString() + seconds.ToString("D2");
            return seconds.ToString();
        }

        internal static string GetLyricsTimestamp(int playerPositionMilliseconds)
        {
            int seconds = playerPositionMilliseconds / 1000;
            int milliseconds = playerPositionMilliseconds % 1000;
            int minutes = seconds / 60;
            seconds = seconds % 60;

            return $"[{minutes:D3}:{seconds:D2}.{milliseconds:D3}] ";
        }

        
    }
}
