namespace MnemoTrainer
{
    partial class FormMagicAlphabetTrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMagicAlphabetTrain));
            this.lblTestWord = new System.Windows.Forms.Label();
            this.gbVisibleTime = new System.Windows.Forms.GroupBox();
            this.nUDVisibleTime = new System.Windows.Forms.NumericUpDown();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.gBOrderType = new System.Windows.Forms.GroupBox();
            this.rBRandom = new System.Windows.Forms.RadioButton();
            this.rbInverse = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tSSLCurrentIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSTotalTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.gbVisibleTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).BeginInit();
            this.gBOrderType.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTestWord
            // 
            this.lblTestWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTestWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTestWord.ForeColor = System.Drawing.Color.Green;
            this.lblTestWord.Location = new System.Drawing.Point(12, 90);
            this.lblTestWord.Name = "lblTestWord";
            this.lblTestWord.Size = new System.Drawing.Size(762, 357);
            this.lblTestWord.TabIndex = 2;
            this.lblTestWord.Text = "А\r\nП\r\nЛ";
            this.lblTestWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbVisibleTime
            // 
            this.gbVisibleTime.Controls.Add(this.nUDVisibleTime);
            this.gbVisibleTime.Location = new System.Drawing.Point(105, 12);
            this.gbVisibleTime.Name = "gbVisibleTime";
            this.gbVisibleTime.Size = new System.Drawing.Size(101, 40);
            this.gbVisibleTime.TabIndex = 1;
            this.gbVisibleTime.TabStop = false;
            this.gbVisibleTime.Text = "Время показа";
            // 
            // nUDVisibleTime
            // 
            this.nUDVisibleTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDVisibleTime.Location = new System.Drawing.Point(3, 16);
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
            this.nUDVisibleTime.Size = new System.Drawing.Size(95, 20);
            this.nUDVisibleTime.TabIndex = 0;
            this.nUDVisibleTime.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(12, 17);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(87, 35);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Начать";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // gBOrderType
            // 
            this.gBOrderType.Controls.Add(this.rBRandom);
            this.gBOrderType.Controls.Add(this.rbInverse);
            this.gBOrderType.Controls.Add(this.rbNormal);
            this.gBOrderType.Location = new System.Drawing.Point(212, 12);
            this.gBOrderType.Name = "gBOrderType";
            this.gBOrderType.Size = new System.Drawing.Size(255, 40);
            this.gBOrderType.TabIndex = 4;
            this.gBOrderType.TabStop = false;
            this.gBOrderType.Text = "Порядок отображения";
            // 
            // rBRandom
            // 
            this.rBRandom.AutoSize = true;
            this.rBRandom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rBRandom.Location = new System.Drawing.Point(162, 16);
            this.rBRandom.Name = "rBRandom";
            this.rBRandom.Size = new System.Drawing.Size(90, 21);
            this.rBRandom.TabIndex = 2;
            this.rBRandom.Text = "В случайном";
            this.rBRandom.UseVisualStyleBackColor = true;
            // 
            // rbInverse
            // 
            this.rbInverse.AutoSize = true;
            this.rbInverse.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbInverse.Location = new System.Drawing.Point(78, 16);
            this.rbInverse.Name = "rbInverse";
            this.rbInverse.Size = new System.Drawing.Size(84, 21);
            this.rbInverse.TabIndex = 1;
            this.rbInverse.Text = "В обратном";
            this.rbInverse.UseVisualStyleBackColor = true;
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Checked = true;
            this.rbNormal.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbNormal.Location = new System.Drawing.Point(3, 16);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(75, 21);
            this.rbNormal.TabIndex = 0;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "В прямом";
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSTotalTimer,
            this.tSSLCurrentIndex});
            this.statusStrip.Location = new System.Drawing.Point(0, 519);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(786, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 16;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tSSLCurrentIndex
            // 
            this.tSSLCurrentIndex.Name = "tSSLCurrentIndex";
            this.tSSLCurrentIndex.Size = new System.Drawing.Size(0, 17);
            // 
            // tSSTotalTimer
            // 
            this.tSSTotalTimer.Name = "tSSTotalTimer";
            this.tSSTotalTimer.Size = new System.Drawing.Size(0, 17);
            // 
            // FormMagicAlphabetTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 541);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gBOrderType);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.gbVisibleTime);
            this.Controls.Add(this.lblTestWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormMagicAlphabetTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Волшебный алфавит";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMagicAlphabetTrain_KeyDown);
            this.gbVisibleTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).EndInit();
            this.gBOrderType.ResumeLayout(false);
            this.gBOrderType.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTestWord;
        private System.Windows.Forms.GroupBox gbVisibleTime;
        private System.Windows.Forms.NumericUpDown nUDVisibleTime;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.GroupBox gBOrderType;
        private System.Windows.Forms.RadioButton rbInverse;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rBRandom;
        private System.Windows.Forms.StatusStrip statusStrip;
        private Controls.ToolStripStatusTimer tSSTotalTimer;
        private System.Windows.Forms.ToolStripStatusLabel tSSLCurrentIndex;
    }
}