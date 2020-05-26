namespace PresentationGrab
{
    partial class frmWindowSelect
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
            this.lstWindows = new System.Windows.Forms.ListBox();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ctnCurrent = new System.Windows.Forms.Button();
            this.lblPtr = new System.Windows.Forms.Label();
            this.tmrPick = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lstWindows
            // 
            this.lstWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWindows.FormattingEnabled = true;
            this.lstWindows.Location = new System.Drawing.Point(12, 38);
            this.lstWindows.Name = "lstWindows";
            this.lstWindows.Size = new System.Drawing.Size(776, 368);
            this.lstWindows.TabIndex = 0;
            this.lstWindows.Click += new System.EventHandler(this.lstWindows_Click);
            // 
            // cmdSelect
            // 
            this.cmdSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelect.Location = new System.Drawing.Point(713, 412);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(75, 23);
            this.cmdSelect.TabIndex = 1;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRefresh.Location = new System.Drawing.Point(713, 10);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(75, 23);
            this.cmdRefresh.TabIndex = 2;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(407, 12);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(300, 20);
            this.txtFilter.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(632, 412);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ctnCurrent
            // 
            this.ctnCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctnCurrent.Location = new System.Drawing.Point(12, 417);
            this.ctnCurrent.Name = "ctnCurrent";
            this.ctnCurrent.Size = new System.Drawing.Size(75, 23);
            this.ctnCurrent.TabIndex = 5;
            this.ctnCurrent.Text = "Pick";
            this.ctnCurrent.UseVisualStyleBackColor = true;
            this.ctnCurrent.Click += new System.EventHandler(this.ctnCurrent_Click);
            // 
            // lblPtr
            // 
            this.lblPtr.AutoSize = true;
            this.lblPtr.Location = new System.Drawing.Point(93, 422);
            this.lblPtr.Name = "lblPtr";
            this.lblPtr.Size = new System.Drawing.Size(106, 13);
            this.lblPtr.TabIndex = 6;
            this.lblPtr.Text = "No selected window.";
            // 
            // tmrPick
            // 
            this.tmrPick.Interval = 1000;
            this.tmrPick.Tick += new System.EventHandler(this.tmrPick_Tick);
            // 
            // frmWindowSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPtr);
            this.Controls.Add(this.ctnCurrent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.lstWindows);
            this.Name = "frmWindowSelect";
            this.Text = "frmWindowSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstWindows;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button ctnCurrent;
        private System.Windows.Forms.Label lblPtr;
        private System.Windows.Forms.Timer tmrPick;
    }
}