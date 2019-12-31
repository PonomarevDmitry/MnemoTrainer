namespace MnemoTrainer
{
    partial class FormStrupTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStrupTest));
            this.lblTestWord = new System.Windows.Forms.Label();
            this.gbVisibleTime = new System.Windows.Forms.GroupBox();
            this.nUDVisibleTime = new System.Windows.Forms.NumericUpDown();
            this.cBAutoShow = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tSSTotalTime = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.tSSLTestCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbVisibleTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTestWord
            // 
            this.lblTestWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTestWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 70F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTestWord.ForeColor = System.Drawing.Color.Brown;
            this.lblTestWord.Location = new System.Drawing.Point(12, 90);
            this.lblTestWord.Name = "lblTestWord";
            this.lblTestWord.Size = new System.Drawing.Size(762, 357);
            this.lblTestWord.TabIndex = 2;
            this.lblTestWord.Text = "Фиолетовый";
            this.lblTestWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTestWord.Click += new System.EventHandler(this.lblTestWord_Click);
            // 
            // gbVisibleTime
            // 
            this.gbVisibleTime.Controls.Add(this.nUDVisibleTime);
            this.gbVisibleTime.Controls.Add(this.cBAutoShow);
            this.gbVisibleTime.Location = new System.Drawing.Point(12, 12);
            this.gbVisibleTime.Name = "gbVisibleTime";
            this.gbVisibleTime.Size = new System.Drawing.Size(116, 40);
            this.gbVisibleTime.TabIndex = 3;
            this.gbVisibleTime.TabStop = false;
            this.gbVisibleTime.Text = "Время показа";
            // 
            // nUDVisibleTime
            // 
            this.nUDVisibleTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDVisibleTime.Location = new System.Drawing.Point(53, 16);
            this.nUDVisibleTime.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nUDVisibleTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDVisibleTime.Name = "nUDVisibleTime";
            this.nUDVisibleTime.Size = new System.Drawing.Size(60, 20);
            this.nUDVisibleTime.TabIndex = 1;
            this.nUDVisibleTime.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDVisibleTime.ValueChanged += new System.EventHandler(this.nUDVisibleTime_ValueChanged);
            // 
            // cBAutoShow
            // 
            this.cBAutoShow.AutoSize = true;
            this.cBAutoShow.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBAutoShow.Location = new System.Drawing.Point(3, 16);
            this.cBAutoShow.Name = "cBAutoShow";
            this.cBAutoShow.Size = new System.Drawing.Size(50, 21);
            this.cBAutoShow.TabIndex = 17;
            this.cBAutoShow.Text = "Авто";
            this.cBAutoShow.UseVisualStyleBackColor = true;
            this.cBAutoShow.CheckedChanged += new System.EventHandler(this.cBAutoShow_CheckedChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSTotalTime,
            this.tSSLTestCount});
            this.statusStrip.Location = new System.Drawing.Point(0, 519);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(786, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 17;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tSSTotalTime
            // 
            this.tSSTotalTime.Format = "Полное время: {0} с.";
            this.tSSTotalTime.Name = "tSSTotalTime";
            this.tSSTotalTime.Size = new System.Drawing.Size(0, 17);
            this.tSSTotalTime.Type = MnemoTrainer.Controls.ToolStripStatusTimer.TimeStringType.Hours;
            // 
            // tSSLTestCount
            // 
            this.tSSLTestCount.Name = "tSSLTestCount";
            this.tSSLTestCount.Size = new System.Drawing.Size(0, 17);
            // 
            // FormStrupTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 541);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gbVisibleTime);
            this.Controls.Add(this.lblTestWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormStrupTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Игра Джона Струпа";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormStrupTest_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormStrupTest_MouseClick);
            this.gbVisibleTime.ResumeLayout(false);
            this.gbVisibleTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTestWord;
        private System.Windows.Forms.GroupBox gbVisibleTime;
        private System.Windows.Forms.NumericUpDown nUDVisibleTime;
        private System.Windows.Forms.CheckBox cBAutoShow;
        private System.Windows.Forms.StatusStrip statusStrip;
        private Controls.ToolStripStatusTimer tSSTotalTime;
        private System.Windows.Forms.ToolStripStatusLabel tSSLTestCount;
    }
}