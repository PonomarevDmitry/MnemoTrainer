namespace MnemoTrainer
{
    partial class FormTrainImpression
    {
        private System.Windows.Forms.GroupBox gBSymbols;
        private System.Windows.Forms.NumericUpDown nUDSymbolsCount;
        private System.Windows.Forms.TextBox tBTestWord;
        private System.Windows.Forms.Label lblTestWord;
        private System.Windows.Forms.GroupBox gbVisibleTime;
        private System.Windows.Forms.NumericUpDown nUDVisibleTime;
        private System.Windows.Forms.Label lblCheckResult;
        private System.Windows.Forms.GroupBox gBTestType;
        private System.Windows.Forms.CheckBox cbRandomSymbols;
        private System.Windows.Forms.CheckBox cBColor;
        private System.Windows.Forms.RadioButton rbDictionary;
        private System.Windows.Forms.RadioButton rbSymbols;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tStStatusWords;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.GroupBox gBDictionary;
        private System.Windows.Forms.ComboBox cBDictionary;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrainImpression));
            this.gBSymbols = new System.Windows.Forms.GroupBox();
            this.nUDSymbolsCount = new System.Windows.Forms.NumericUpDown();
            this.tBTestWord = new System.Windows.Forms.TextBox();
            this.lblTestWord = new System.Windows.Forms.Label();
            this.gbVisibleTime = new System.Windows.Forms.GroupBox();
            this.nUDVisibleTime = new System.Windows.Forms.NumericUpDown();
            this.lblCheckResult = new System.Windows.Forms.Label();
            this.gBTestType = new System.Windows.Forms.GroupBox();
            this.cbRandomSymbols = new System.Windows.Forms.CheckBox();
            this.cBColor = new System.Windows.Forms.CheckBox();
            this.rbDictionary = new System.Windows.Forms.RadioButton();
            this.rbSymbols = new System.Windows.Forms.RadioButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tStStatusWords = new System.Windows.Forms.ToolStripStatusLabel();
            this.gBDictionary = new System.Windows.Forms.GroupBox();
            this.cBDictionary = new System.Windows.Forms.ComboBox();
            this.gBWords = new System.Windows.Forms.GroupBox();
            this.nUDWordsCount = new System.Windows.Forms.NumericUpDown();
            this.errorPictureBox = new MnemoTrainer.Controls.ErrorPictureBox(this.components);
            this.tSSTotalTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.tSSTestTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.gBSymbols.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSymbolsCount)).BeginInit();
            this.gbVisibleTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).BeginInit();
            this.gBTestType.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.gBDictionary.SuspendLayout();
            this.gBWords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDWordsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // gBSymbols
            // 
            this.gBSymbols.Controls.Add(this.nUDSymbolsCount);
            this.gBSymbols.Location = new System.Drawing.Point(546, 12);
            this.gBSymbols.Name = "gBSymbols";
            this.gBSymbols.Size = new System.Drawing.Size(76, 40);
            this.gBSymbols.TabIndex = 3;
            this.gBSymbols.TabStop = false;
            this.gBSymbols.Text = "Символов";
            // 
            // nUDSymbolsCount
            // 
            this.nUDSymbolsCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDSymbolsCount.Location = new System.Drawing.Point(3, 16);
            this.nUDSymbolsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDSymbolsCount.Name = "nUDSymbolsCount";
            this.nUDSymbolsCount.Size = new System.Drawing.Size(70, 20);
            this.nUDSymbolsCount.TabIndex = 0;
            this.nUDSymbolsCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDSymbolsCount.ValueChanged += new System.EventHandler(this.nUDSymbolsCount_ValueChanged);
            // 
            // tBTestWord
            // 
            this.tBTestWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tBTestWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBTestWord.Location = new System.Drawing.Point(168, 287);
            this.tBTestWord.Name = "tBTestWord";
            this.tBTestWord.Size = new System.Drawing.Size(450, 29);
            this.tBTestWord.TabIndex = 0;
            this.tBTestWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBTestWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBTestWord_KeyDown);
            this.tBTestWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBTestWord_KeyPress);
            // 
            // lblTestWord
            // 
            this.lblTestWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTestWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTestWord.ForeColor = System.Drawing.Color.Green;
            this.lblTestWord.Location = new System.Drawing.Point(12, 90);
            this.lblTestWord.Name = "lblTestWord";
            this.lblTestWord.Size = new System.Drawing.Size(762, 169);
            this.lblTestWord.TabIndex = 5;
            this.lblTestWord.Text = "Тест";
            this.lblTestWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTestWord.Visible = false;
            // 
            // gbVisibleTime
            // 
            this.gbVisibleTime.Controls.Add(this.nUDVisibleTime);
            this.gbVisibleTime.Location = new System.Drawing.Point(12, 12);
            this.gbVisibleTime.Name = "gbVisibleTime";
            this.gbVisibleTime.Size = new System.Drawing.Size(98, 40);
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
            this.nUDVisibleTime.Size = new System.Drawing.Size(92, 20);
            this.nUDVisibleTime.TabIndex = 0;
            this.nUDVisibleTime.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDVisibleTime.ValueChanged += new System.EventHandler(this.nUDVisibleTime_ValueChanged);
            // 
            // lblCheckResult
            // 
            this.lblCheckResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCheckResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCheckResult.ForeColor = System.Drawing.Color.Green;
            this.lblCheckResult.Location = new System.Drawing.Point(70, 350);
            this.lblCheckResult.Name = "lblCheckResult";
            this.lblCheckResult.Size = new System.Drawing.Size(646, 110);
            this.lblCheckResult.TabIndex = 6;
            this.lblCheckResult.Text = "Ответ\r\n7,5 c";
            this.lblCheckResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCheckResult.Visible = false;
            // 
            // gBTestType
            // 
            this.gBTestType.Controls.Add(this.cbRandomSymbols);
            this.gBTestType.Controls.Add(this.cBColor);
            this.gBTestType.Controls.Add(this.rbDictionary);
            this.gBTestType.Controls.Add(this.rbSymbols);
            this.gBTestType.Location = new System.Drawing.Point(116, 12);
            this.gBTestType.Name = "gBTestType";
            this.gBTestType.Size = new System.Drawing.Size(283, 40);
            this.gBTestType.TabIndex = 2;
            this.gBTestType.TabStop = false;
            this.gBTestType.Text = "Тип теста";
            // 
            // cbRandomSymbols
            // 
            this.cbRandomSymbols.AutoSize = true;
            this.cbRandomSymbols.Location = new System.Drawing.Point(215, 20);
            this.cbRandomSymbols.Name = "cbRandomSymbols";
            this.cbRandomSymbols.Size = new System.Drawing.Size(61, 17);
            this.cbRandomSymbols.TabIndex = 3;
            this.cbRandomSymbols.Text = "Случай";
            this.cbRandomSymbols.UseVisualStyleBackColor = true;
            this.cbRandomSymbols.CheckedChanged += new System.EventHandler(this.cbRandomSymbols_CheckedChanged);
            // 
            // cBColor
            // 
            this.cBColor.AutoSize = true;
            this.cBColor.Location = new System.Drawing.Point(84, 20);
            this.cBColor.Name = "cBColor";
            this.cBColor.Size = new System.Drawing.Size(51, 17);
            this.cBColor.TabIndex = 1;
            this.cBColor.Text = "Цвет";
            this.cBColor.UseVisualStyleBackColor = true;
            this.cBColor.CheckedChanged += new System.EventHandler(this.cBColor_CheckedChanged);
            // 
            // rbDictionary
            // 
            this.rbDictionary.AutoSize = true;
            this.rbDictionary.Location = new System.Drawing.Point(141, 19);
            this.rbDictionary.Name = "rbDictionary";
            this.rbDictionary.Size = new System.Drawing.Size(68, 17);
            this.rbDictionary.TabIndex = 2;
            this.rbDictionary.Text = "Словарь";
            this.rbDictionary.UseVisualStyleBackColor = true;
            this.rbDictionary.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbSymbols
            // 
            this.rbSymbols.AutoSize = true;
            this.rbSymbols.Checked = true;
            this.rbSymbols.Location = new System.Drawing.Point(6, 19);
            this.rbSymbols.Name = "rbSymbols";
            this.rbSymbols.Size = new System.Drawing.Size(72, 17);
            this.rbSymbols.TabIndex = 0;
            this.rbSymbols.TabStop = true;
            this.rbSymbols.Text = "Символы";
            this.rbSymbols.UseVisualStyleBackColor = true;
            this.rbSymbols.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStStatusWords,
            this.tSSTotalTimer,
            this.tSSTestTimer});
            this.statusStrip.Location = new System.Drawing.Point(0, 519);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(786, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tStStatusWords
            // 
            this.tStStatusWords.Name = "tStStatusWords";
            this.tStStatusWords.Size = new System.Drawing.Size(0, 17);
            // 
            // gBDictionary
            // 
            this.gBDictionary.Controls.Add(this.cBDictionary);
            this.gBDictionary.Location = new System.Drawing.Point(405, 12);
            this.gBDictionary.Name = "gBDictionary";
            this.gBDictionary.Size = new System.Drawing.Size(135, 40);
            this.gBDictionary.TabIndex = 4;
            this.gBDictionary.TabStop = false;
            this.gBDictionary.Text = "Словарь";
            // 
            // cBDictionary
            // 
            this.cBDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBDictionary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBDictionary.FormattingEnabled = true;
            this.cBDictionary.Location = new System.Drawing.Point(3, 16);
            this.cBDictionary.Name = "cBDictionary";
            this.cBDictionary.Size = new System.Drawing.Size(129, 21);
            this.cBDictionary.TabIndex = 0;
            // 
            // gBWords
            // 
            this.gBWords.Controls.Add(this.nUDWordsCount);
            this.gBWords.Location = new System.Drawing.Point(625, 12);
            this.gBWords.Name = "gBWords";
            this.gBWords.Size = new System.Drawing.Size(76, 40);
            this.gBWords.TabIndex = 4;
            this.gBWords.TabStop = false;
            this.gBWords.Text = "Слов";
            // 
            // nUDWordsCount
            // 
            this.nUDWordsCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDWordsCount.Location = new System.Drawing.Point(3, 16);
            this.nUDWordsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDWordsCount.Name = "nUDWordsCount";
            this.nUDWordsCount.Size = new System.Drawing.Size(70, 20);
            this.nUDWordsCount.TabIndex = 0;
            this.nUDWordsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDWordsCount.ValueChanged += new System.EventHandler(this.nUDWordsCount_ValueChanged);
            // 
            // errorPictureBox
            // 
            this.errorPictureBox.Location = new System.Drawing.Point(130, 284);
            this.errorPictureBox.Name = "errorPictureBox";
            this.errorPictureBox.Size = new System.Drawing.Size(32, 32);
            this.errorPictureBox.TabIndex = 17;
            // 
            // tSSTotalTimer
            // 
            this.tSSTotalTimer.Format = "Полное время: {0}.";
            this.tSSTotalTimer.Name = "tSSTotalTimer";
            this.tSSTotalTimer.Size = new System.Drawing.Size(0, 0);
            this.tSSTotalTimer.Type = MnemoTrainer.Controls.ToolStripStatusTimer.TimeStringType.Hours;
            // 
            // tSSTestTimer
            // 
            this.tSSTestTimer.Name = "tSSTestTimer";
            this.tSSTestTimer.Size = new System.Drawing.Size(0, 0);
            // 
            // FormImpressionTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 541);
            this.Controls.Add(this.gBWords);
            this.Controls.Add(this.errorPictureBox);
            this.Controls.Add(this.gBDictionary);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gBTestType);
            this.Controls.Add(this.lblCheckResult);
            this.Controls.Add(this.gbVisibleTime);
            this.Controls.Add(this.tBTestWord);
            this.Controls.Add(this.gBSymbols);
            this.Controls.Add(this.lblTestWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormImpressionTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Тренировка \"Зрительная память\"";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormImpressionTrain_KeyDown);
            this.gBSymbols.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDSymbolsCount)).EndInit();
            this.gbVisibleTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).EndInit();
            this.gBTestType.ResumeLayout(false);
            this.gBTestType.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gBDictionary.ResumeLayout(false);
            this.gBWords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDWordsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Controls.ToolStripStatusTimer tSSTestTimer;
        private Controls.ToolStripStatusTimer tSSTotalTimer;
        private Controls.ErrorPictureBox errorPictureBox;
        private System.Windows.Forms.GroupBox gBWords;
        private System.Windows.Forms.NumericUpDown nUDWordsCount;
    }
}