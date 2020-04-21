namespace PresentationGrab
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.nudBRH = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudBRW = new System.Windows.Forms.NumericUpDown();
            this.chkTrackPowerPointLaser = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudNoise = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudAreaThreshold = new System.Windows.Forms.NumericUpDown();
            this.cmdCaptureNow = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTogglePosition = new System.Windows.Forms.Button();
            this.cmdSetCrop = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.nudCaptureInterval = new System.Windows.Forms.NumericUpDown();
            this.btnCaptureToggle = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.screenCaptureTimer = new System.Windows.Forms.Timer(this.components);
            this.mouseCaptureTimer = new System.Windows.Forms.Timer(this.components);
            this.cmdAffinity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBRH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBRW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAreaThreshold)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaptureInterval)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(7, 51);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(149, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Google transcribe";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(7, 235);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(162, 285);
            this.textBox1.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(9, 212);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(162, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Json => Lyrics";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.LargeChange = 50;
            this.trackBar1.Location = new System.Drawing.Point(9, 241);
            this.trackBar1.Maximum = 1500;
            this.trackBar1.Minimum = 500;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(162, 45);
            this.trackBar1.SmallChange = 10;
            this.trackBar1.TabIndex = 6;
            this.trackBar1.TickFrequency = 50;
            this.trackBar1.Value = 650;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(182, 547);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.nudBRH);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.nudBRW);
            this.tabPage1.Controls.Add(this.chkTrackPowerPointLaser);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.nudNoise);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.nudAreaThreshold);
            this.tabPage1.Controls.Add(this.cmdCaptureNow);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.lblStatus);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.nudCaptureInterval);
            this.tabPage1.Controls.Add(this.btnCaptureToggle);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(174, 521);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Screen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 475);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Buttons H";
            // 
            // nudBRH
            // 
            this.nudBRH.Location = new System.Drawing.Point(98, 473);
            this.nudBRH.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudBRH.Name = "nudBRH";
            this.nudBRH.Size = new System.Drawing.Size(67, 20);
            this.nudBRH.TabIndex = 31;
            this.nudBRH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudBRH.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudBRH.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 449);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Buttons W";
            // 
            // nudBRW
            // 
            this.nudBRW.Location = new System.Drawing.Point(98, 447);
            this.nudBRW.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudBRW.Name = "nudBRW";
            this.nudBRW.Size = new System.Drawing.Size(67, 20);
            this.nudBRW.TabIndex = 29;
            this.nudBRW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudBRW.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudBRW.ValueChanged += new System.EventHandler(this.nudBRW_ValueChanged);
            // 
            // chkTrackPowerPointLaser
            // 
            this.chkTrackPowerPointLaser.AutoSize = true;
            this.chkTrackPowerPointLaser.Checked = true;
            this.chkTrackPowerPointLaser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrackPowerPointLaser.Location = new System.Drawing.Point(12, 222);
            this.chkTrackPowerPointLaser.Name = "chkTrackPowerPointLaser";
            this.chkTrackPowerPointLaser.Size = new System.Drawing.Size(95, 17);
            this.chkTrackPowerPointLaser.TabIndex = 28;
            this.chkTrackPowerPointLaser.Text = "Search pointer";
            this.chkTrackPowerPointLaser.UseVisualStyleBackColor = true;
            this.chkTrackPowerPointLaser.CheckedChanged += new System.EventHandler(this.chkTrackPowerPointLaser_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Noise threshold:";
            // 
            // nudNoise
            // 
            this.nudNoise.Location = new System.Drawing.Point(98, 198);
            this.nudNoise.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudNoise.Name = "nudNoise";
            this.nudNoise.Size = new System.Drawing.Size(67, 20);
            this.nudNoise.TabIndex = 26;
            this.nudNoise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudNoise.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudNoise.ValueChanged += new System.EventHandler(this.nudNoise_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Diff threshold:";
            // 
            // nudAreaThreshold
            // 
            this.nudAreaThreshold.Location = new System.Drawing.Point(98, 172);
            this.nudAreaThreshold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAreaThreshold.Name = "nudAreaThreshold";
            this.nudAreaThreshold.Size = new System.Drawing.Size(67, 20);
            this.nudAreaThreshold.TabIndex = 24;
            this.nudAreaThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudAreaThreshold.Value = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            this.nudAreaThreshold.ValueChanged += new System.EventHandler(this.nudAreaThreshold_ValueChanged);
            // 
            // cmdCaptureNow
            // 
            this.cmdCaptureNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCaptureNow.Location = new System.Drawing.Point(6, 94);
            this.cmdCaptureNow.Name = "cmdCaptureNow";
            this.cmdCaptureNow.Size = new System.Drawing.Size(159, 42);
            this.cmdCaptureNow.TabIndex = 23;
            this.cmdCaptureNow.Text = "Capture one";
            this.cmdCaptureNow.UseVisualStyleBackColor = true;
            this.cmdCaptureNow.Click += new System.EventHandler(this.cmdCaptureNow_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTogglePosition);
            this.groupBox1.Controls.Add(this.cmdSetCrop);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 82);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crop area";
            // 
            // btnTogglePosition
            // 
            this.btnTogglePosition.Location = new System.Drawing.Point(6, 19);
            this.btnTogglePosition.Name = "btnTogglePosition";
            this.btnTogglePosition.Size = new System.Drawing.Size(69, 23);
            this.btnTogglePosition.TabIndex = 17;
            this.btnTogglePosition.Text = "Toggle";
            this.btnTogglePosition.UseVisualStyleBackColor = true;
            this.btnTogglePosition.Click += new System.EventHandler(this.btnPositionToggle_Click);
            // 
            // cmdSetCrop
            // 
            this.cmdSetCrop.Location = new System.Drawing.Point(6, 48);
            this.cmdSetCrop.Name = "cmdSetCrop";
            this.cmdSetCrop.Size = new System.Drawing.Size(144, 23);
            this.cmdSetCrop.TabIndex = 15;
            this.cmdSetCrop.Text = "Set";
            this.cmdSetCrop.UseVisualStyleBackColor = true;
            this.cmdSetCrop.Visible = false;
            this.cmdSetCrop.Click += new System.EventHandler(this.cmdSetCrop_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(81, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Flash";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(118, 274);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 20);
            this.button7.TabIndex = 21;
            this.button7.Text = "Speed";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 349);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(6, 297);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(159, 49);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Status:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.Location = new System.Drawing.Point(6, 142);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(159, 24);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Enable mouse capture (ctrl)";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // nudCaptureInterval
            // 
            this.nudCaptureInterval.Location = new System.Drawing.Point(6, 274);
            this.nudCaptureInterval.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudCaptureInterval.Name = "nudCaptureInterval";
            this.nudCaptureInterval.Size = new System.Drawing.Size(106, 20);
            this.nudCaptureInterval.TabIndex = 13;
            this.nudCaptureInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCaptureInterval.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudCaptureInterval.ValueChanged += new System.EventHandler(this.nudCaptureInterval_ValueChanged);
            // 
            // btnCaptureToggle
            // 
            this.btnCaptureToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaptureToggle.ImageIndex = 0;
            this.btnCaptureToggle.ImageList = this.imageList1;
            this.btnCaptureToggle.Location = new System.Drawing.Point(6, 245);
            this.btnCaptureToggle.Name = "btnCaptureToggle";
            this.btnCaptureToggle.Size = new System.Drawing.Size(159, 23);
            this.btnCaptureToggle.TabIndex = 12;
            this.btnCaptureToggle.Text = "Start screen capture";
            this.btnCaptureToggle.UseVisualStyleBackColor = true;
            this.btnCaptureToggle.Click += new System.EventHandler(this.btnCaptureToggle_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Record.png");
            this.imageList1.Images.SetKeyName(1, "Stop.png");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(174, 521);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Process";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(7, 88);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(161, 130);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Images";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(8, 102);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(149, 23);
            this.button9.TabIndex = 23;
            this.button9.Text = "Process AFC";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 72);
            this.label5.TabIndex = 1;
            this.label5.Text = "1. Place mp3 in the audio file,\r\n2. Optional: Place images in T/P structure, \r\n3." +
    " Process";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(7, 5);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(161, 79);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transcript";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 38);
            this.label4.TabIndex = 0;
            this.label4.Text = "Prepare mono 16khz files in wip then transcribe";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.trackBar1);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.button11);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(174, 521);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Misc";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdAffinity);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Location = new System.Drawing.Point(9, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 125);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WIP";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(144, 23);
            this.button6.TabIndex = 19;
            this.button6.Text = "Open Folder";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(9, 150);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(156, 46);
            this.button8.TabIndex = 12;
            this.button8.Text = "custom capture processing (optional crops)";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(9, 389);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(159, 57);
            this.button11.TabIndex = 11;
            this.button11.Text = "OLD: Process screenshot folder";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Visible = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // screenCaptureTimer
            // 
            this.screenCaptureTimer.Interval = 5000;
            this.screenCaptureTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mouseCaptureTimer
            // 
            this.mouseCaptureTimer.Tick += new System.EventHandler(this.mouseCaptureTimer_Tick);
            // 
            // cmdAffinity
            // 
            this.cmdAffinity.Location = new System.Drawing.Point(6, 48);
            this.cmdAffinity.Name = "cmdAffinity";
            this.cmdAffinity.Size = new System.Drawing.Size(144, 23);
            this.cmdAffinity.TabIndex = 20;
            this.cmdAffinity.Text = "Affintiy";
            this.cmdAffinity.UseVisualStyleBackColor = true;
            this.cmdAffinity.Click += new System.EventHandler(this.cmdAffinity_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 571);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "LectureCapture";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBRH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBRW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAreaThreshold)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaptureInterval)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer screenCaptureTimer;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button btnCaptureToggle;
        private System.Windows.Forms.NumericUpDown nudCaptureInterval;
        private System.Windows.Forms.Button cmdSetCrop;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer mouseCaptureTimer;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTogglePosition;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button cmdCaptureNow;
        private System.Windows.Forms.NumericUpDown nudAreaThreshold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudNoise;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTrackPowerPointLaser;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudBRH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudBRW;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button cmdAffinity;
    }
}

