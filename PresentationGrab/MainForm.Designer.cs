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
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.screenCaptureTimer = new System.Windows.Forms.Timer(this.components);
            this.mouseCaptureTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAreaThreshold)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaptureInterval)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(10, 78);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(224, 35);
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
            this.textBox1.Location = new System.Drawing.Point(11, 362);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(241, 324);
            this.textBox1.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(14, 326);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(243, 35);
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
            this.trackBar1.Location = new System.Drawing.Point(14, 371);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar1.Maximum = 1500;
            this.trackBar1.Minimum = 500;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(243, 45);
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
            this.label1.Location = new System.Drawing.Point(321, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
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
            this.tabControl1.Location = new System.Drawing.Point(18, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(273, 729);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
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
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(265, 696);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Screen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkTrackPowerPointLaser
            // 
            this.chkTrackPowerPointLaser.AutoSize = true;
            this.chkTrackPowerPointLaser.Checked = true;
            this.chkTrackPowerPointLaser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrackPowerPointLaser.Location = new System.Drawing.Point(18, 342);
            this.chkTrackPowerPointLaser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTrackPowerPointLaser.Name = "chkTrackPowerPointLaser";
            this.chkTrackPowerPointLaser.Size = new System.Drawing.Size(132, 24);
            this.chkTrackPowerPointLaser.TabIndex = 28;
            this.chkTrackPowerPointLaser.Text = "Search pointer";
            this.chkTrackPowerPointLaser.UseVisualStyleBackColor = true;
            this.chkTrackPowerPointLaser.CheckedChanged += new System.EventHandler(this.chkTrackPowerPointLaser_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 308);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Noise threshold:";
            // 
            // nudNoise
            // 
            this.nudNoise.Location = new System.Drawing.Point(147, 305);
            this.nudNoise.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudNoise.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudNoise.Name = "nudNoise";
            this.nudNoise.Size = new System.Drawing.Size(100, 26);
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
            this.label2.Location = new System.Drawing.Point(14, 268);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Diff threshold:";
            // 
            // nudAreaThreshold
            // 
            this.nudAreaThreshold.Location = new System.Drawing.Point(147, 265);
            this.nudAreaThreshold.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudAreaThreshold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAreaThreshold.Name = "nudAreaThreshold";
            this.nudAreaThreshold.Size = new System.Drawing.Size(100, 26);
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
            this.cmdCaptureNow.Location = new System.Drawing.Point(9, 145);
            this.cmdCaptureNow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdCaptureNow.Name = "cmdCaptureNow";
            this.cmdCaptureNow.Size = new System.Drawing.Size(238, 65);
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
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(238, 126);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crop area";
            // 
            // btnTogglePosition
            // 
            this.btnTogglePosition.Location = new System.Drawing.Point(9, 29);
            this.btnTogglePosition.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTogglePosition.Name = "btnTogglePosition";
            this.btnTogglePosition.Size = new System.Drawing.Size(104, 35);
            this.btnTogglePosition.TabIndex = 17;
            this.btnTogglePosition.Text = "Toggle";
            this.btnTogglePosition.UseVisualStyleBackColor = true;
            this.btnTogglePosition.Click += new System.EventHandler(this.btnPositionToggle_Click);
            // 
            // cmdSetCrop
            // 
            this.cmdSetCrop.Location = new System.Drawing.Point(9, 74);
            this.cmdSetCrop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdSetCrop.Name = "cmdSetCrop";
            this.cmdSetCrop.Size = new System.Drawing.Size(216, 35);
            this.cmdSetCrop.TabIndex = 15;
            this.cmdSetCrop.Text = "Set";
            this.cmdSetCrop.UseVisualStyleBackColor = true;
            this.cmdSetCrop.Visible = false;
            this.cmdSetCrop.Click += new System.EventHandler(this.cmdSetCrop_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(122, 29);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 35);
            this.button3.TabIndex = 16;
            this.button3.Text = "Flash";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(177, 422);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(70, 31);
            this.button7.TabIndex = 21;
            this.button7.Text = "Speed";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 537);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(9, 457);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(238, 75);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Status:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.Location = new System.Drawing.Point(9, 218);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(238, 37);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Enable mouse capture (ctrl)";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // nudCaptureInterval
            // 
            this.nudCaptureInterval.Location = new System.Drawing.Point(9, 422);
            this.nudCaptureInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudCaptureInterval.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudCaptureInterval.Name = "nudCaptureInterval";
            this.nudCaptureInterval.Size = new System.Drawing.Size(159, 26);
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
            this.btnCaptureToggle.Location = new System.Drawing.Point(9, 377);
            this.btnCaptureToggle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCaptureToggle.Name = "btnCaptureToggle";
            this.btnCaptureToggle.Size = new System.Drawing.Size(238, 35);
            this.btnCaptureToggle.TabIndex = 12;
            this.btnCaptureToggle.Text = "Start screen capture";
            this.btnCaptureToggle.UseVisualStyleBackColor = true;
            this.btnCaptureToggle.Click += new System.EventHandler(this.btnCaptureToggle_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(265, 696);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Speech";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.trackBar1);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.button11);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Size = new System.Drawing.Size(265, 696);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Misc";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Location = new System.Drawing.Point(14, 9);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(234, 192);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WIP";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(10, 106);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(224, 35);
            this.button9.TabIndex = 23;
            this.button9.Text = "Process AFC";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(9, 29);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(216, 35);
            this.button6.TabIndex = 19;
            this.button6.Text = "Open Folder";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(14, 231);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(234, 71);
            this.button8.TabIndex = 12;
            this.button8.Text = "custom capture processing (optional crops)";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(14, 598);
            this.button11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(238, 88);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(11, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(241, 121);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transcript";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 59);
            this.label4.TabIndex = 0;
            this.label4.Text = "Prepare mono 16khz files in wip then transcribe";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(11, 135);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(241, 149);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Images";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 79);
            this.label5.TabIndex = 1;
            this.label5.Text = "Place images in T/P structure, place mp3 in the audio file then process";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 766);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "LectureCapture";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAreaThreshold)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaptureInterval)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
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
    }
}

