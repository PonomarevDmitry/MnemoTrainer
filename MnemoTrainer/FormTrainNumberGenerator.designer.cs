namespace MnemoTrainer
{
    partial class FormTrainNumberGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrainNumberGenerator));
            this.gBSymbols = new System.Windows.Forms.GroupBox();
            this.nUDSymbolsCount = new System.Windows.Forms.NumericUpDown();
            this.tBTestWord = new System.Windows.Forms.TextBox();
            this.lblTestWord = new System.Windows.Forms.Label();
            this.lblCheckResult = new System.Windows.Forms.Label();
            this.gbVisibleTime = new System.Windows.Forms.GroupBox();
            this.nUDVisibleTime = new System.Windows.Forms.NumericUpDown();
            this.chBAutoShow = new System.Windows.Forms.CheckBox();
            this.gBTimeForAnswer = new System.Windows.Forms.GroupBox();
            this.nUDTimeForAnswer = new System.Windows.Forms.NumericUpDown();
            this.chBTimeForAnswer = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tSSTotalTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.tSSTestTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.gbRange = new System.Windows.Forms.GroupBox();
            this.nUDRight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nUDLeft = new System.Windows.Forms.NumericUpDown();
            this.chbValueRange = new System.Windows.Forms.CheckBox();
            this.gBNets = new System.Windows.Forms.GroupBox();
            this.netCheckedListBox = new MnemoTrainer.Controls.NetCheckedListBox();
            this.errorPictureBox = new MnemoTrainer.Controls.ErrorPictureBox(this.components);
            this.gBSymbols.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSymbolsCount)).BeginInit();
            this.gbVisibleTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).BeginInit();
            this.gBTimeForAnswer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForAnswer)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.gbRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLeft)).BeginInit();
            this.gBNets.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBSymbols
            // 
            this.gBSymbols.Controls.Add(this.nUDSymbolsCount);
            this.gBSymbols.Location = new System.Drawing.Point(247, 12);
            this.gBSymbols.Name = "gBSymbols";
            this.gBSymbols.Size = new System.Drawing.Size(77, 40);
            this.gBSymbols.TabIndex = 3;
            this.gBSymbols.TabStop = false;
            this.gBSymbols.Text = "Символов";
            // 
            // nUDSymbolsCount
            // 
            this.nUDSymbolsCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDSymbolsCount.Location = new System.Drawing.Point(3, 16);
            this.nUDSymbolsCount.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.nUDSymbolsCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nUDSymbolsCount.Name = "nUDSymbolsCount";
            this.nUDSymbolsCount.Size = new System.Drawing.Size(71, 20);
            this.nUDSymbolsCount.TabIndex = 0;
            this.nUDSymbolsCount.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nUDSymbolsCount.ValueChanged += new System.EventHandler(this.nUDSymbolsCount_ValueChanged);
            // 
            // tBTestWord
            // 
            this.tBTestWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tBTestWord.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBTestWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBTestWord.Location = new System.Drawing.Point(168, 385);
            this.tBTestWord.Name = "tBTestWord";
            this.tBTestWord.Size = new System.Drawing.Size(450, 29);
            this.tBTestWord.TabIndex = 0;
            this.tBTestWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBTestWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBTestWord_KeyDown);
            this.tBTestWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // lblTestWord
            // 
            this.lblTestWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTestWord.Font = new System.Drawing.Font("Lucida Console", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTestWord.ForeColor = System.Drawing.Color.Green;
            this.lblTestWord.Location = new System.Drawing.Point(12, 55);
            this.lblTestWord.Name = "lblTestWord";
            this.lblTestWord.Size = new System.Drawing.Size(762, 324);
            this.lblTestWord.TabIndex = 4;
            this.lblTestWord.Text = "12 34 56 78 90";
            this.lblTestWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTestWord.Visible = false;
            // 
            // lblCheckResult
            // 
            this.lblCheckResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCheckResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCheckResult.ForeColor = System.Drawing.Color.Green;
            this.lblCheckResult.Location = new System.Drawing.Point(70, 417);
            this.lblCheckResult.Name = "lblCheckResult";
            this.lblCheckResult.Size = new System.Drawing.Size(646, 96);
            this.lblCheckResult.TabIndex = 5;
            this.lblCheckResult.Text = "Ответ\r\n1 с";
            this.lblCheckResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCheckResult.Visible = false;
            // 
            // gbVisibleTime
            // 
            this.gbVisibleTime.Controls.Add(this.nUDVisibleTime);
            this.gbVisibleTime.Controls.Add(this.chBAutoShow);
            this.gbVisibleTime.Location = new System.Drawing.Point(12, 12);
            this.gbVisibleTime.Name = "gbVisibleTime";
            this.gbVisibleTime.Size = new System.Drawing.Size(120, 40);
            this.gbVisibleTime.TabIndex = 1;
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
            this.nUDVisibleTime.Size = new System.Drawing.Size(64, 20);
            this.nUDVisibleTime.TabIndex = 1;
            this.nUDVisibleTime.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDVisibleTime.ValueChanged += new System.EventHandler(this.nUDVisibleTime_ValueChanged);
            // 
            // chBAutoShow
            // 
            this.chBAutoShow.AutoSize = true;
            this.chBAutoShow.Dock = System.Windows.Forms.DockStyle.Left;
            this.chBAutoShow.Location = new System.Drawing.Point(3, 16);
            this.chBAutoShow.Name = "chBAutoShow";
            this.chBAutoShow.Size = new System.Drawing.Size(50, 21);
            this.chBAutoShow.TabIndex = 17;
            this.chBAutoShow.Text = "Авто";
            this.chBAutoShow.UseVisualStyleBackColor = true;
            this.chBAutoShow.CheckedChanged += new System.EventHandler(this.cBAutoShow_CheckedChanged);
            // 
            // gBTimeForAnswer
            // 
            this.gBTimeForAnswer.Controls.Add(this.nUDTimeForAnswer);
            this.gBTimeForAnswer.Controls.Add(this.chBTimeForAnswer);
            this.gBTimeForAnswer.Location = new System.Drawing.Point(138, 12);
            this.gBTimeForAnswer.Name = "gBTimeForAnswer";
            this.gBTimeForAnswer.Size = new System.Drawing.Size(103, 40);
            this.gBTimeForAnswer.TabIndex = 2;
            this.gBTimeForAnswer.TabStop = false;
            this.gBTimeForAnswer.Text = "Время на ответ";
            // 
            // nUDTimeForAnswer
            // 
            this.nUDTimeForAnswer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDTimeForAnswer.Location = new System.Drawing.Point(18, 16);
            this.nUDTimeForAnswer.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nUDTimeForAnswer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDTimeForAnswer.Name = "nUDTimeForAnswer";
            this.nUDTimeForAnswer.Size = new System.Drawing.Size(82, 20);
            this.nUDTimeForAnswer.TabIndex = 1;
            this.nUDTimeForAnswer.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nUDTimeForAnswer.ValueChanged += new System.EventHandler(this.nUDTimeForAnswer_ValueChanged);
            // 
            // chBTimeForAnswer
            // 
            this.chBTimeForAnswer.AutoSize = true;
            this.chBTimeForAnswer.Dock = System.Windows.Forms.DockStyle.Left;
            this.chBTimeForAnswer.Location = new System.Drawing.Point(3, 16);
            this.chBTimeForAnswer.Name = "chBTimeForAnswer";
            this.chBTimeForAnswer.Size = new System.Drawing.Size(15, 21);
            this.chBTimeForAnswer.TabIndex = 0;
            this.chBTimeForAnswer.UseVisualStyleBackColor = true;
            this.chBTimeForAnswer.CheckedChanged += new System.EventHandler(this.cBTimeForAnswer_CheckedChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSTotalTimer,
            this.tSSTestTimer});
            this.statusStrip.Location = new System.Drawing.Point(0, 519);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(786, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 16;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tSSTotalTimer
            // 
            this.tSSTotalTimer.Format = "Полное время: {0}.";
            this.tSSTotalTimer.Name = "tSSTotalTimer";
            this.tSSTotalTimer.Size = new System.Drawing.Size(0, 17);
            this.tSSTotalTimer.Type = MnemoTrainer.Controls.ToolStripStatusTimer.TimeStringType.Hours;
            // 
            // tSSTestTimer
            // 
            this.tSSTestTimer.Name = "tSSTestTimer";
            this.tSSTestTimer.Size = new System.Drawing.Size(0, 17);
            // 
            // gbRange
            // 
            this.gbRange.Controls.Add(this.nUDRight);
            this.gbRange.Controls.Add(this.label2);
            this.gbRange.Controls.Add(this.nUDLeft);
            this.gbRange.Controls.Add(this.chbValueRange);
            this.gbRange.Location = new System.Drawing.Point(330, 12);
            this.gbRange.Name = "gbRange";
            this.gbRange.Size = new System.Drawing.Size(136, 40);
            this.gbRange.TabIndex = 4;
            this.gbRange.TabStop = false;
            this.gbRange.Text = "Диапазон значений";
            this.gbRange.Validating += new System.ComponentModel.CancelEventHandler(this.gbRange_Validating);
            // 
            // nUDRight
            // 
            this.nUDRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDRight.Location = new System.Drawing.Point(88, 16);
            this.nUDRight.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nUDRight.Name = "nUDRight";
            this.nUDRight.Size = new System.Drawing.Size(45, 20);
            this.nUDRight.TabIndex = 3;
            this.nUDRight.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nUDRight.ValueChanged += new System.EventHandler(this.nUDRight_ValueChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(66, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "  -  ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nUDLeft
            // 
            this.nUDLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.nUDLeft.Location = new System.Drawing.Point(21, 16);
            this.nUDLeft.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nUDLeft.Name = "nUDLeft";
            this.nUDLeft.Size = new System.Drawing.Size(45, 20);
            this.nUDLeft.TabIndex = 1;
            this.nUDLeft.ValueChanged += new System.EventHandler(this.nUDLeft_ValueChanged);
            // 
            // chbValueRange
            // 
            this.chbValueRange.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbValueRange.Location = new System.Drawing.Point(3, 16);
            this.chbValueRange.Name = "chbValueRange";
            this.chbValueRange.Size = new System.Drawing.Size(18, 21);
            this.chbValueRange.TabIndex = 0;
            this.chbValueRange.UseVisualStyleBackColor = true;
            this.chbValueRange.CheckedChanged += new System.EventHandler(this.cbValueRange_CheckedChanged);
            // 
            // gBNets
            // 
            this.gBNets.Controls.Add(this.netCheckedListBox);
            this.gBNets.Location = new System.Drawing.Point(472, 12);
            this.gBNets.Name = "gBNets";
            this.gBNets.Size = new System.Drawing.Size(174, 40);
            this.gBNets.TabIndex = 17;
            this.gBNets.TabStop = false;
            this.gBNets.Text = "Сетка";
            // 
            // netCheckedListBox
            // 
            this.netCheckedListBox.BackColor = System.Drawing.SystemColors.Window;
            this.netCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.netCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.netCheckedListBox.DropDownHeight = 0;
            this.netCheckedListBox.Location = new System.Drawing.Point(3, 16);
            this.netCheckedListBox.Name = "netCheckedListBox";
            this.netCheckedListBox.Size = new System.Drawing.Size(168, 21);
            this.netCheckedListBox.TabIndex = 1;
            this.netCheckedListBox.Text = "Не выбрана";
            this.netCheckedListBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorPictureBox
            // 
            this.errorPictureBox.Location = new System.Drawing.Point(130, 382);
            this.errorPictureBox.Name = "errorPictureBox";
            this.errorPictureBox.Size = new System.Drawing.Size(32, 32);
            this.errorPictureBox.TabIndex = 18;
            this.errorPictureBox.TabStop = false;
            // 
            // FormTrainNumberGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 541);
            this.Controls.Add(this.errorPictureBox);
            this.Controls.Add(this.gBNets);
            this.Controls.Add(this.gbRange);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gBTimeForAnswer);
            this.Controls.Add(this.gbVisibleTime);
            this.Controls.Add(this.lblCheckResult);
            this.Controls.Add(this.tBTestWord);
            this.Controls.Add(this.gBSymbols);
            this.Controls.Add(this.lblTestWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormTrainNumberGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Генератор чисел";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormNumberGenerator_KeyDown);
            this.gBSymbols.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDSymbolsCount)).EndInit();
            this.gbVisibleTime.ResumeLayout(false);
            this.gbVisibleTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).EndInit();
            this.gBTimeForAnswer.ResumeLayout(false);
            this.gBTimeForAnswer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForAnswer)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gbRange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLeft)).EndInit();
            this.gBNets.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBSymbols;
        private System.Windows.Forms.NumericUpDown nUDSymbolsCount;
        private System.Windows.Forms.TextBox tBTestWord;
        private System.Windows.Forms.Label lblTestWord;
        private System.Windows.Forms.Label lblCheckResult;
        private System.Windows.Forms.GroupBox gbVisibleTime;
        private System.Windows.Forms.NumericUpDown nUDVisibleTime;
        private System.Windows.Forms.GroupBox gBTimeForAnswer;
        private System.Windows.Forms.NumericUpDown nUDTimeForAnswer;
        private System.Windows.Forms.CheckBox chBTimeForAnswer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.CheckBox chBAutoShow;
        private System.Windows.Forms.GroupBox gbRange;
        private System.Windows.Forms.NumericUpDown nUDRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nUDLeft;
        private System.Windows.Forms.CheckBox chbValueRange;
        private System.Windows.Forms.GroupBox gBNets;
        private Controls.ToolStripStatusTimer tSSTestTimer;
        private Controls.NetCheckedListBox netCheckedListBox;
        private Controls.ErrorPictureBox errorPictureBox;
        private Controls.ToolStripStatusTimer tSSTotalTimer;
    }
}