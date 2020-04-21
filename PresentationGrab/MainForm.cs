using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.IO;
using PresentationGrab.Image;
using PresentationGrab.Voice;

namespace PresentationGrab
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            trackBar1.Value = wordSeparationThreshold;
            UpdateCaptureToggleButton();
        }

        private void OldCodeImageNames(object sender, EventArgs e)
        {
            var d = new DirectoryInfo(@"C:\Data\AcademicDocs\Study\Esame di stato\Lezione 3\Parte 1\");
            var fls = d.GetFiles("*.*").OrderBy(x => x.CreationTime).ToList();
            var basetime = System.DateTime.MinValue;

            var minAfterCreation = int.MaxValue;
            var maxAfterCreation = int.MinValue;
            var totAfterCreation = 0.0;
            var countAfterCreation = 0;

            StringBuilder timing = new StringBuilder();
            foreach (var fl in fls)
            {

                Regex r = new Regex(@"([\d]*)[ -]*(.*)\.png");
                var m = r.Match(fl.Name);
                if (m.Success)
                {
                    var tString = m.Groups[1].Value;
                    var secString = tString.Substring(tString.Length - 2);
                    var minString = tString.Substring(0, tString.Length - 2);

                    int sec = Convert.ToInt32(secString, CultureInfo.InvariantCulture);
                    int min = Convert.ToInt32(minString, CultureInfo.InvariantCulture);

                    DateTime timeFromName;
                    if (basetime == DateTime.MinValue)
                    {
                        basetime = fl.CreationTime.AddMinutes(-min).AddSeconds(-sec);
                        timeFromName = basetime.AddMinutes(min).AddSeconds(sec);
                    }
                    else
                    {
                        timeFromName = basetime.AddMinutes(min).AddSeconds(sec);
                    }

                    var creationTime = fl.CreationTime;

                    var deltaNameAfterCreation = timeFromName - creationTime;

                    var deltaFromName = timeFromName - basetime;
                    var deltaFromCreation = creationTime - basetime;

                    // stats
                    countAfterCreation++;
                    minAfterCreation = (int)Math.Min(minAfterCreation, deltaNameAfterCreation.TotalSeconds);
                    maxAfterCreation = (int)Math.Max(maxAfterCreation, deltaNameAfterCreation.TotalSeconds);
                    totAfterCreation += deltaNameAfterCreation.TotalSeconds;

                    // info
                    Debug.WriteLine($"{tString} : {minString} {secString} {deltaNameAfterCreation.TotalSeconds} after creation - {m.Groups[2].Value}");

                    // adjustment
                    // 
                    deltaFromName = deltaFromName.Add(new TimeSpan(0, 0, -30)); // make 30 seconds earlier

                    // output
                    timing.AppendLine($"[{deltaFromName.TotalMinutes:N0}:{deltaFromName.Seconds}.{deltaFromName.Milliseconds}] {m.Groups[2].Value}");

                }
                else
                {

                }
            }

            Debug.WriteLine("");
            Debug.WriteLine($"Values names after creation: Min: {minAfterCreation}, Max: {maxAfterCreation} avg: {totAfterCreation / countAfterCreation}");
            Debug.WriteLine("");
            Debug.WriteLine(timing.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // SpeechConvert.LongRunningRecognize(@"C:\Data\Work\Esame Stato\Lezioni\Lezione 1\Part2.mp3");
            // SpeechConvert.LongRunningRecognize(@"C:\Data\Work\Esame Stato\Lezioni\Lezione 1\P2\P1.flac");
            // SpeechConvert.LongRunningRecognize(@"gs://audio_playground/P1.flac");

            // SpeechConvert.LongRunningRecognize(@"gs://audio_playground/L44.flac", "en");
            // SpeechConvert.LongRunningRecognize(@"gs://audio_playground/01Label.flac", "it");
            // SpeechConvert.LongRunningRecognize(@"gs://audio_playground/Part2.flac", "it");

            //  ========================================================================================================================
            var language = "it";                                                                             // <====== FIX THE LANGUAGE
            // var language = "it";                                                                          // <====== FIX THE LANGUAGE

            var ret = MessageBox.Show($"Using language {language}. Continue?", "Check language settings.", MessageBoxButtons.YesNoCancel);
            if (ret != DialogResult.Yes)
                return;

            StringBuilder sb = new StringBuilder();

            foreach (var speech in SpeechConvert.GetFlacNames())
            {
                sb.Append($"[{DateTime.Now}] Converting {speech}... ");
                var storageName = $@"gs://audio_playground/{speech}";
                var output = SpeechConvert.LongRunningRecognize(storageName, language);
                if (output != null && output.Exists)
                {
                    TranscriptManager t = new TranscriptManager();
                    t.MakeLyrics(output);
                    sb.AppendLine("Done.");
                }
                else
                {
                    sb.AppendLine("Error.");
                }
            }
            textBox1.Text = sb.ToString();
            // MessageBox.Show("Completed", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TranscriptManager t = new TranscriptManager
            {
                WordSeparationThreshold = wordSeparationThreshold
            };
            textBox1.Text = t.MakeLyrics(true);
        }

        int wordSeparationThreshold = 650;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            wordSeparationThreshold = trackBar1.Value;
            label1.Text = wordSeparationThreshold.ToString();
            button5_Click(null, null);
        }

        ScreenManager s = new ScreenManager();

        bool doSound = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            PerformCapture();
        }

        private void PerformCapture(bool forceCapture = false)
        {
            var screenCaptureTimerState = screenCaptureTimer.Enabled;
            screenCaptureTimer.Enabled = false;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = s.CheckNew(DateTime.Now, forceCapture);
            var borderColor = Color.Transparent;
            if (result.ResultActions.HasFlag(ScreenManager.Results.NewImage) || result.ResultActions.HasFlag(ScreenManager.Results.CorrectedImage))
            {
                borderColor = Color.Green;
                pictureBox1.Image = result.ResultingBitmap;
                if (result.ResultActions.HasFlag(ScreenManager.Results.PointerLogged) && result.ResultActions.HasFlag(ScreenManager.Results.CorrectedImage))
                    borderColor = Color.Orange;
            }
            lblStatus.BackColor = borderColor;
            if (result.TotalDifferentArea != -1)
                lblStatus.Text = $"{result.ResultActions} in {sw.ElapsedMilliseconds} ms.\r\n Diff: {result.TotalDifferentArea} px";
            else
                lblStatus.Text = $"{result.ResultActions} in {sw.ElapsedMilliseconds} ms.";

            screenCaptureTimer.Enabled = screenCaptureTimerState;
            Debug.WriteLine($"{DateTime.Now} {DateTime.Now.Millisecond}");

            if (!doSound)
                return;

            var beeped = false;
            if (result.ResultActions.HasFlag(ScreenManager.Results.NewImage))
            {
                Console.Beep(700, 150);
                beeped = true;
            }
            if (result.ResultActions.HasFlag(ScreenManager.Results.CorrectedImage))
            {
                Console.Beep(900, 150);
                beeped = true;
            }
            if (result.ResultActions.HasFlag(ScreenManager.Results.PointerLogged))
            {
                Console.Beep(1000, 75);
                beeped = true;
            }
            if (!beeped)
                Console.Beep(800, 20);
        }

        private void ProcessImageFile(string filename)
        {
            var f = new FileInfo(filename);
            var r = new Bitmap(f.FullName);
            r = s.DoCrop(r);
            r = s.RemoveAlpha(r);
            s.CheckNew(f.CreationTime, false, r);
        }

        private void btnCaptureToggle_Click(object sender, EventArgs e)
        {
            screenCaptureTimer.Interval = (int)nudCaptureInterval.Value;
            screenCaptureTimer.Enabled = !screenCaptureTimer.Enabled;
            UpdateCaptureToggleButton();
        }

        private void UpdateCaptureToggleButton()
        {
            if (screenCaptureTimer.Enabled)
            {
                btnCaptureToggle.Text = "Stop screen capture";
                btnCaptureToggle.ImageIndex = 1;
                // status managed by timer
            }
            else
            {
                btnCaptureToggle.Text = "Start screen capture";
                lblStatus.Text = "Stopped";
                lblStatus.BackColor = Color.White;
                btnCaptureToggle.ImageIndex = 0;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            //s = new ScreenManager();
            ////s.CropRectangle = new Rectangle(
            ////        new Point(453, 184),
            ////        new Size(1963, 1102)
            ////        );

            //string L = "03";
            //string P = "01";
            //DirectoryInfo source = new DirectoryInfo($@"C:\Data\Work\Esame Stato\SupportingMedia\T{L}\P{P}");
            //DirectoryInfo dp = new DirectoryInfo($@"C:\Data\Work\Esame Stato\SupportingMedia\L{L}");
            //if (!dp.Exists)
            //    dp.Create();
            //DirectoryInfo dest = new DirectoryInfo($@"C:\Data\Work\Esame Stato\SupportingMedia\L{L}\P{P}");
            //if (!dest.Exists)
            //    dest.Create();
            //s.OutputDirectory = dest;
            //s.RecordingStartDateTime = new DateTime(2020, 03, 19, 19, 01, 25); // <=== FIX THE DATE
            //var images = source.GetFiles("*.png").OrderBy(x => x.CreationTime);
            //foreach (var item in images)
            //{
            //    ProcessImageFile(item.FullName);
            //}
            //s.Dispose();
        }


        private void mouseCaptureTimer_Tick(object sender, EventArgs e)
        {
            if (IsControlDown())
                s.WriteCursorPosition();
        }

        public static bool IsControlDown()
        {
            return (Control.ModifierKeys & Keys.Control) == Keys.Control;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            mouseCaptureTimer.Enabled = checkBox1.Checked;
            checkBox1.Text = checkBox1.Checked
                ? "Stop mouse capture"
                : "Start mouse capture";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!s.OutputDirectory.Exists)
                s.OutputDirectory.Create();
            Process.Start(s.OutputDirectory.FullName);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var option1 = 200;
            var option2 = 2000;
            var d1 = Math.Abs(nudCaptureInterval.Value - option1);
            var d2 = Math.Abs(nudCaptureInterval.Value - option2);

            var setvalue = d1 < d2 // set to the farthest
                ? option2  
                : option1;
            nudCaptureInterval.Value = setvalue;
        }

        private void nudCaptureInterval_ValueChanged(object sender, EventArgs e)
        {
            screenCaptureTimer.Interval = (int)nudCaptureInterval.Value;
        }

        private void btnPositionToggle_Click(object sender, EventArgs e)
        {
            if (s.CropRectangle.Equals(CropRectFromForm()))
            {
                SetFormToLeft();
                cmdSetCrop.Visible = false;
                if (lblStatus.Text == "Suspended")
                {
                    screenCaptureTimer.Enabled = true;
                    lblStatus.Text = "Waiting";
                    lblStatus.BackColor = Color.Transparent;
                }
            }
            else
            {
                // set form to crop area
                Location = new Point(s.CropRectangle.X - 7, s.CropRectangle.Y);
                Size = new Size(s.CropRectangle.Width + 14, s.CropRectangle.Height + 7);
                cmdSetCrop.Visible = true;
                if (screenCaptureTimer.Enabled)
                {
                    screenCaptureTimer.Enabled = false;
                    lblStatus.Text = "Suspended";
                    lblStatus.BackColor = Color.Orange;
                }
            }
        }

        private Rectangle CropRectFromForm()
        {
            return new Rectangle(
                new Point(Location.X + 7, Location.Y),
                new Size(Size.Width - 14, Size.Height - 7)
                );
        }

        private void SetFormToLeft()
        {
            Location = new Point(10, 100);
            Size = new Size(230, 600);
        }
        
        private void cmdSetCrop_Click(object sender, EventArgs e)
        {
            s.CropRectangle = CropRectFromForm();
            btnPositionToggle_Click(null, null);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            DrawFullScreen.Draw(s.CropRectangle, Brushes.Gold);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string L = "10";
            string P = "04";

            var ret = MessageBox.Show($"Have you set L ({L}), P ({P}) and music file?", "Settings", MessageBoxButtons.YesNo);
            if (ret != DialogResult.Yes)
                return;

            ProcessedConverter pc = new ProcessedConverter();
            // pc.Cropper = new Rectangle(new Point(24, 31), new Size(1912, 1071));

            pc.Process(L, P);
            MessageBox.Show("Done");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ProcessedConverter pc = new ProcessedConverter();
            var s = new DirectoryInfo(@"C:\Data\Dev\MyUtils\PresentationGrab\PresentationGrab\bin\Debug\DebugBlob\output");
            var d = new DirectoryInfo(@"C:\Data\Work\CDE\OpenCde\Meetings\2020 04 20");
            var a = new FileInfo(@"C:\Data\Work\CDE\OpenCde\Meetings\2020 04 20\CDE_11-03-04.mp3");
            pc.Process(s, d, a);
        }

        private void cmdCaptureNow_Click(object sender, EventArgs e)
        {
            if (s == null)
                return;
            PerformCapture(true);
            if (!screenCaptureTimer.Enabled)
            {
                Task.Delay(2000).ContinueWith(t => StatusClearBackground());
            }
        }

        private void StatusClearBackground()
        {
            lblStatus.BackColor = Color.Transparent;
        }

        private void nudAreaThreshold_ValueChanged(object sender, EventArgs e)
        {
            s.ImageDifferenceThreshold = (int)nudAreaThreshold.Value;
        }

        private void nudNoise_ValueChanged(object sender, EventArgs e)
        {
            s.NoiseThreshold = (int)nudNoise.Value;
        }

        private void chkTrackPowerPointLaser_CheckedChanged(object sender, EventArgs e)
        {
            s.TrackPowerPointLaser = chkTrackPowerPointLaser.Checked;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            cmdSetCrop.Visible = true;
        }

        private void nudBRW_ValueChanged(object sender, EventArgs e)
        {
            s.ButtonregionWidth = (int)nudBRW.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            s.ButtonregionHeight = (int)nudBRH.Value;
        }

        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);


        enum AffinityMode
        {
            WDA_NONE = 0,
            WDA_MONITOR = 1
        }

        AffinityMode md = AffinityMode.WDA_NONE;

        private void cmdAffinity_Click(object sender, EventArgs e)
        {
            if (md == AffinityMode.WDA_NONE)
                md = AffinityMode.WDA_MONITOR;
            else
                md = AffinityMode.WDA_NONE;
            SetWindowDisplayAffinity(this.Handle, (uint)md);
            cmdAffinity.Text = $"Affinity is {md.ToString()}";
        }
    }
}