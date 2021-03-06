﻿using System;
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
using PresentationGrab.ImageProcessing;
using PresentationGrab.Voice;
using PresentationGrab.Audio;
using static PresentationGrab.ImageProcessing.CaptureManager;
using NAudio.Wave;

namespace PresentationGrab
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            trackBar1.Value = wordSeparationThreshold;
            UpdateCaptureToggleButton();
            UpdateAudioCaptureToggleButton();
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
            
            StringBuilder sb = new StringBuilder();

            foreach (var speech in SpeechConvert.GetFlacNames())
            {
                sb.Append($"[{DateTime.Now}] Converting {speech}... ");
                var storageName = $@"gs://audio_playground/{speech}";
                var output = SpeechConvert.LongRunningRecognize(storageName, cmbLang.Text);
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

        CaptureManager imageGrabber = new CaptureManager();

        bool doSound = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            PerformCapture();
        }

        DateTime? lastCapure = null;

        private void PerformCapture(bool forceCapture = false)
        {
            var screenCaptureTimerState = screenCaptureTimer.Enabled;
            screenCaptureTimer.Enabled = false;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = imageGrabber.CheckNew(DateTime.Now, forceCapture);
            if (result.ResultActions.HasFlag(Results.WindowNotFound))
            {
                if (audioRecorder != null)
                {
                    // stop audio recording.
                    button10_Click(null, null);
                }
                if (screenCaptureTimerState == true)
                {
                    // stop screen capture.
                    UpdateCaptureToggleButton();
                    screenCaptureTimerState = false;
                }
            }
            var borderColor = Color.Transparent;
            if (result.ResultActions.HasFlag(CaptureManager.Results.NewImage) || result.ResultActions.HasFlag(CaptureManager.Results.CorrectedImage))
            {
                lastCapure = DateTime.Now;
                borderColor = Color.Green;
                pictureBox1.Image = result.ResultingBitmap;
                if (result.ResultActions.HasFlag(CaptureManager.Results.PointerLogged) && result.ResultActions.HasFlag(CaptureManager.Results.CorrectedImage))
                    borderColor = Color.Orange;
            }
            lblStatus.BackColor = borderColor;
            if (result.TotalDifferentArea != -1)
                lblStatus.Text = $"{result.ResultActions} in {sw.ElapsedMilliseconds} ms.\r\n Diff: {result.TotalDifferentArea} px";
            else
                lblStatus.Text = $"{result.ResultActions} in {sw.ElapsedMilliseconds} ms.";

            screenCaptureTimer.Enabled = screenCaptureTimerState;

            if (lastCapure.HasValue)
            {
                if (!screenCaptureTimer.Enabled)
                {
                    lblElapsedTime.Text = lastCapure.Value.ToShortTimeString();
                }
                else
                {
                    var diff = DateTime.Now - lastCapure;
                    lblElapsedTime.Text = $"{diff.Value:mm\\:ss}";
                }
            }

            if (!doSound)
                return;

            var beeped = false;
            if (result.ResultActions.HasFlag(CaptureManager.Results.NewImage))
            {
                Console.Beep(700, 150);
                beeped = true;
            }
            if (result.ResultActions.HasFlag(CaptureManager.Results.CorrectedImage))
            {
                Console.Beep(900, 150);
                beeped = true;
            }
            if (result.ResultActions.HasFlag(CaptureManager.Results.PointerLogged))
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
            r = imageGrabber.DoCrop(r);
            r = imageGrabber.RemoveAlpha(r);
            imageGrabber.CheckNew(f.CreationTime, false, r);
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
                imageGrabber.WriteCursorPosition();
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
            if (!imageGrabber.OutputDirectory.Exists)
                imageGrabber.OutputDirectory.Create();
            Process.Start(imageGrabber.OutputDirectory.FullName);
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
            var sendLeft = imageGrabber.CropRectangle.Equals(CropRectFromForm());
            SendFormLeft(sendLeft);
        }

        private void SendFormLeft(bool sendLeft)
        {
            if (sendLeft)
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
                Location = new Point(imageGrabber.CropRectangle.X - 7, imageGrabber.CropRectangle.Y);
                Size = new Size(imageGrabber.CropRectangle.Width + 14, imageGrabber.CropRectangle.Height + 7);
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
            Size = new Size(230, 750);
        }
        
        private void cmdSetCrop_Click(object sender, EventArgs e)
        {
            if (imageGrabber.capturePtr == IntPtr.Zero)
            {
                imageGrabber.CropRectangle = CropRectFromForm();
                btnPositionToggle_Click(null, null);
            }
            else
            {
                var rectToSelect = CropRectFromForm();
                var rectWindow = new ScreenCapture.User32.RECT();
                ScreenCapture.User32.GetWindowRect(imageGrabber.capturePtr, ref rectWindow);
                Rectangle crop = new Rectangle(
                    rectToSelect.X - rectWindow.left,
                    rectToSelect.Y - rectWindow.top,
                    rectToSelect.Width,
                    rectToSelect.Height
                    );
                crop = imageGrabber.FixRect(crop);
                imageGrabber.CropRectangle = crop;
                SendFormLeft(true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DrawFullScreen.Draw(imageGrabber.CropRectangle, Brushes.Gold);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string L = $"{(int)nudL.Value:D2}";
            string P = $"{(int)nudP.Value:D2}";

            //var ret = MessageBox.Show($"Have you set L ({L}), P ({P}) and music file?", "Settings", MessageBoxButtons.YesNo);
            //if (ret != DialogResult.Yes)
            //    return;

            ProcessedConverter pc = new ProcessedConverter();
            // pc.Cropper = new Rectangle(new Point(24, 31), new Size(1912, 1071));

            pc.Process(L, P);
            MessageBox.Show("Done");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ProcessedConverter pc = new ProcessedConverter();
            var s = new DirectoryInfo(@"C:\Data\Work\Wip\Capture");
            var d = new DirectoryInfo(@"C:\Data\Work\CDE\OpenCde\Meetings\2020 04 20");
            var a = new FileInfo(@"C:\Data\Work\CDE\OpenCde\Meetings\2020 04 20\CDE_11-03-04.mp3");
            pc.Process(s, d, a);
        }

        private void cmdCaptureNow_Click(object sender, EventArgs e)
        {
            if (imageGrabber == null)
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
            imageGrabber.ImageDifferenceThreshold = (int)nudAreaThreshold.Value;
        }

        private void nudNoise_ValueChanged(object sender, EventArgs e)
        {
            imageGrabber.NoiseThreshold = (int)nudNoise.Value;
        }

        private void chkTrackPowerPointLaser_CheckedChanged(object sender, EventArgs e)
        {
            imageGrabber.TrackPowerPointLaser = chkTrackPowerPointLaser.Checked;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            cmdSetCrop.Visible = true;
        }

        private void nudBRW_ValueChanged(object sender, EventArgs e)
        {
            imageGrabber.ButtonregionWidth = (int)nudBRW.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            imageGrabber.ButtonregionHeight = (int)nudBRH.Value;
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

        

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing )
            {
                if (components != null)
                    components.Dispose();
                if (imageGrabber != null)
                    imageGrabber.Dispose();
            }
            
            base.Dispose(disposing);
        }

        private void cmdSelectWindow_Click(object sender, EventArgs e)
        {
            cmdSelectWindow.Text = "Window";
            if (imageGrabber.capturePtr == IntPtr.Zero)
            {
                frmWindowSelect wSel = new frmWindowSelect();
                wSel.ShowDialog();
                if (wSel.retPtr != IntPtr.Zero)
                {
                    imageGrabber.capturePtr = wSel.retPtr;
                    cmdSelectWindow.Text = "RemWindow";
                    imageGrabber.CropActive = false;
                }
                else
                {
                    imageGrabber.capturePtr = IntPtr.Zero;
                }
            }
            else
            {
                imageGrabber.capturePtr = IntPtr.Zero;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string L = $"{(int)nudL.Value:D2}";
            string P = $"{(int)nudP.Value:D2}";
            DirectoryInfo source = new DirectoryInfo($@"C:\Data\Work\Esame Stato\SupportingMedia\L{L}\P{P}");
            var pngs = source.GetFiles("*.png");
            var Page = new FileInfo(Path.Combine(source.FullName, $"L{L}P{P}.html"));



            using (var p = Page.CreateText())
            {
                p.WriteLine("<HTML>");

                p.WriteLine("<HEAD>");
                p.WriteLine($"<TITLE>AFC - Lezione {L} Parte {P}</TITLE>");
                p.WriteLine("</HEAD>");

                p.WriteLine("<BODY>");
                foreach (var png in pngs)
                {
                    p.WriteLine($"<IMG SRC=\"{png.Name}\" />");
                }
                p.WriteLine("</BODY>");
                p.WriteLine("</HTML>");
            }
        }

        private void UpdateAudioCaptureToggleButton()
        {
            if (audioRecorder != null)
            {
                btnAudioCapture.Text = "Stop audio capture";
                btnAudioCapture.ImageIndex = 1;
                btnTimedNote.Visible = true;
            }
            else
            {
                btnAudioCapture.Text = "Start audio capture";
                btnAudioCapture.ImageIndex = 0;
                btnTimedNote.Visible = false;
            }
        }

        Mp3AudioRecorder audioRecorder;

        private void button10_Click(object sender, EventArgs e)
        {
            if (audioRecorder == null)
            {
                audioRecorder = new Mp3AudioRecorder();
                audioRecorder.StartRecording();
            }
            else
            {
                audioRecorder.StopRecording();
                var asDisp = audioRecorder as IDisposable;
                asDisp.Dispose();
                audioRecorder = null;
            }
            UpdateAudioCaptureToggleButton();
        }

        private void btnTimeNote_Click(object sender, EventArgs e)
        {
            if (audioRecorder.StartTime == null)
                return;
            DateTime start = audioRecorder.StartTime.Value;
            var delta = DateTime.Now - start;
            // L06P03[015:01.600]
            var h = $"L{(int)nudL.Value:D2}P{(int)nudP.Value:D2}[{(int)delta.TotalMinutes:D3}:{(int)delta.Seconds:D2}.{(int)delta.Milliseconds:D3}]";
            Clipboard.SetText(h);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {

            //var rectWindow = new ScreenCapture.User32.RECT();
            //ScreenCapture.User32.GetWindowRect(imageGrabber.capturePtr, ref rectWindow);
            //var sw = rectWindow.right - rectWindow.left;
            //var sh = rectWindow.bottom - rectWindow.top;

            

            int w = 1957;
            int h = 1387    ;
            const short SWP_NOMOVE = 0X2;
            const short SWP_NOSIZE = 1;
            const short SWP_NOZORDER = 0X4;
            const int SWP_SHOWWINDOW = 0x0040;

            if (imageGrabber.capturePtr == IntPtr.Zero)
                return;
            OpenWindowsGetter.SetWindowPos(imageGrabber.capturePtr, 0, 0, 0, w, h, SWP_NOMOVE | SWP_NOZORDER);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var re = new Regex(@"(\d+).*", RegexOptions.Compiled);
            for (int lecture = 18; lecture < 40; lecture++)
            {
                var pAudio = Path.Combine(@"C:\Data\Work\Esame Stato\Audio", $"L{lecture}");
                var p = Path.Combine(@"C:\Data\Work\Esame Stato\SupportingMedia", $"L{lecture}");
                var dirs = Directory.GetDirectories(p);
                foreach (var dir in dirs)
                {
                    DirectoryInfo dinfor = new DirectoryInfo(dir);
                    var mp3s = Directory.GetFiles(pAudio, $"L{lecture}{dinfor.Name}*.mp3");
                    foreach (var mp3 in mp3s)
                    {
                        var file = TagLib.File.Create(mp3);
                        string title = file.Tag.Title;
                        int dur = (int)Math.Round( file.Properties.Duration.TotalMinutes); 

                        Debug.WriteLine($"{title} ({dur} minuti)");
                    }


                    //var images = dinfor.GetFiles("*.png").OrderBy(x => Int32.Parse(re.Replace(x.Name, "$1"))).ToList();
                    //foreach (var image in images)
                    //{
                    //    if (nameFrom.Text != "" && nameTo.Text != "")
                    //    {
                    //        var replaced = image.FullName.Replace(nameFrom.Text, nameTo.Text);
                    //        if (image.FullName != replaced)
                    //            File.Move(image.FullName, replaced);
                    //    }
                    //    Debug.WriteLine($"- {image.Name.Replace(".png", "")}");
                    //}
                }
                Debug.WriteLine($"");
            }
        }
    }
}