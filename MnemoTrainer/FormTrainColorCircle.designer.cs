namespace MnemoTrainer
{
    partial class FormTrainColorCircle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrainColorCircle));
            this.gBNextCircle = new System.Windows.Forms.GroupBox();
            this.nUDTimeNextCircle = new System.Windows.Forms.NumericUpDown();
            this.chBNextCircle = new System.Windows.Forms.CheckBox();
            this.gbVisibleTime = new System.Windows.Forms.GroupBox();
            this.nUDVisibleTime = new System.Windows.Forms.NumericUpDown();
            this.chBVisionTime = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tSSTotalTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.tSSTestTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.tSSLCurrentIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorCircle = new MnemoTrainer.Controls.ColorCircle();
            this.gBNextCircle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeNextCircle)).BeginInit();
            this.gbVisibleTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBNextCircle
            // 
            this.gBNextCircle.Controls.Add(this.nUDTimeNextCircle);
            this.gBNextCircle.Controls.Add(this.chBNextCircle);
            this.gBNextCircle.Location = new System.Drawing.Point(119, 12);
            this.gBNextCircle.Name = "gBNextCircle";
            this.gBNextCircle.Size = new System.Drawing.Size(90, 40);
            this.gBNextCircle.TabIndex = 2;
            this.gBNextCircle.TabStop = false;
            this.gBNextCircle.Text = "Следующий";
            // 
            // nUDTimeNextCircle
            // 
            this.nUDTimeNextCircle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDTimeNextCircle.Location = new System.Drawing.Point(18, 16);
            this.nUDTimeNextCircle.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nUDTimeNextCircle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDTimeNextCircle.Name = "nUDTimeNextCircle";
            this.nUDTimeNextCircle.Size = new System.Drawing.Size(69, 20);
            this.nUDTimeNextCircle.TabIndex = 1;
            this.nUDTimeNextCircle.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.nUDTimeNextCircle.ValueChanged += new System.EventHandler(this.nUDTimeNextCircle_ValueChanged);
            // 
            // chBNextCircle
            // 
            this.chBNextCircle.AutoSize = true;
            this.chBNextCircle.Dock = System.Windows.Forms.DockStyle.Left;
            this.chBNextCircle.Location = new System.Drawing.Point(3, 16);
            this.chBNextCircle.Name = "chBNextCircle";
            this.chBNextCircle.Size = new System.Drawing.Size(15, 21);
            this.chBNextCircle.TabIndex = 0;
            this.chBNextCircle.UseVisualStyleBackColor = true;
            this.chBNextCircle.CheckedChanged += new System.EventHandler(this.cBNextCircle_CheckedChanged);
            // 
            // gbVisibleTime
            // 
            this.gbVisibleTime.Controls.Add(this.nUDVisibleTime);
            this.gbVisibleTime.Controls.Add(this.chBVisionTime);
            this.gbVisibleTime.Location = new System.Drawing.Point(12, 12);
            this.gbVisibleTime.Name = "gbVisibleTime";
            this.gbVisibleTime.Size = new System.Drawing.Size(101, 40);
            this.gbVisibleTime.TabIndex = 1;
            this.gbVisibleTime.TabStop = false;
            this.gbVisibleTime.Text = "Время показа";
            // 
            // nUDVisibleTime
            // 
            this.nUDVisibleTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDVisibleTime.Location = new System.Drawing.Point(18, 16);
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
            this.nUDVisibleTime.Size = new System.Drawing.Size(80, 20);
            this.nUDVisibleTime.TabIndex = 1;
            this.nUDVisibleTime.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDVisibleTime.ValueChanged += new System.EventHandler(this.nUDVisibleTime_ValueChanged);
            // 
            // chBVisionTime
            // 
            this.chBVisionTime.AutoSize = true;
            this.chBVisionTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.chBVisionTime.Location = new System.Drawing.Point(3, 16);
            this.chBVisionTime.Name = "chBVisionTime";
            this.chBVisionTime.Size = new System.Drawing.Size(15, 21);
            this.chBVisionTime.TabIndex = 0;
            this.chBVisionTime.UseVisualStyleBackColor = true;
            this.chBVisionTime.CheckedChanged += new System.EventHandler(this.cBVisionTime_CheckedChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSTotalTimer,
            this.tSSTestTimer,
            this.tSSLCurrentIndex});
            this.statusStrip.Location = new System.Drawing.Point(0, 682);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(710, 22);
            this.statusStrip.TabIndex = 16;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tSSTotalTimer
            // 
            this.tSSTotalTimer.Format = "Полное время теста: {0}.";
            this.tSSTotalTimer.Interval = 1000;
            this.tSSTotalTimer.Name = "tSSTotalTimer";
            this.tSSTotalTimer.Size = new System.Drawing.Size(0, 17);
            this.tSSTotalTimer.Type = MnemoTrainer.Controls.ToolStripStatusTimer.TimeStringType.Hours;
            // 
            // tSSTestTimer
            // 
            this.tSSTestTimer.Name = "tSSTestTimer";
            this.tSSTestTimer.Size = new System.Drawing.Size(0, 17);
            // 
            // tSSLCurrentIndex
            // 
            this.tSSLCurrentIndex.Name = "tSSLCurrentIndex";
            this.tSSLCurrentIndex.Size = new System.Drawing.Size(0, 17);
            // 
            // colorCircle
            // 
            this.colorCircle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.colorCircle.CircleColor = System.Drawing.Color.Empty;
            this.colorCircle.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F);
            this.colorCircle.ForeColor = System.Drawing.Color.Green;
            this.colorCircle.Location = new System.Drawing.Point(12, 55);
            this.colorCircle.Name = "colorCircle";
            this.colorCircle.ShowCircle = false;
            this.colorCircle.Size = new System.Drawing.Size(686, 618);
            this.colorCircle.TabIndex = 17;
            this.colorCircle.Text = "colorCircle";
            this.colorCircle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorCircle_MouseClick);
            // 
            // FormTrainColorCircle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 704);
            this.Controls.Add(this.colorCircle);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gBNextCircle);
            this.Controls.Add(this.gbVisibleTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormTrainColorCircle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Цветные круги";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormColorCircleTrain_KeyDown);
            this.gBNextCircle.ResumeLayout(false);
            this.gBNextCircle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeNextCircle)).EndInit();
            this.gbVisibleTime.ResumeLayout(false);
            this.gbVisibleTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBNextCircle;
        private System.Windows.Forms.NumericUpDown nUDTimeNextCircle;
        private System.Windows.Forms.CheckBox chBNextCircle;
        private System.Windows.Forms.GroupBox gbVisibleTime;
        private System.Windows.Forms.NumericUpDown nUDVisibleTime;
        private System.Windows.Forms.CheckBox chBVisionTime;
        private System.Windows.Forms.StatusStrip statusStrip;
        private Controls.ToolStripStatusTimer tSSTestTimer;
        private Controls.ColorCircle colorCircle;
        private System.Windows.Forms.ToolStripStatusLabel tSSLCurrentIndex;
        private Controls.ToolStripStatusTimer tSSTotalTimer;
    }
}