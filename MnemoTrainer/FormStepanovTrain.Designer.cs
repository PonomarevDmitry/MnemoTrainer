namespace MnemoTrainer
{
    partial class FormStepanovTrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStepanovTrain));
            this.gBSymbols = new System.Windows.Forms.GroupBox();
            this.nUDSymbolsCount = new System.Windows.Forms.NumericUpDown();
            this.tBTestWord = new System.Windows.Forms.TextBox();
            this.lblTestWord = new System.Windows.Forms.Label();
            this.lblCheckResult = new System.Windows.Forms.Label();
            this.gbVisibleTime = new System.Windows.Forms.GroupBox();
            this.nUDVisibleTime = new System.Windows.Forms.NumericUpDown();
            this.cBVisionTime = new System.Windows.Forms.CheckBox();
            this.gBTimeForAnswer = new System.Windows.Forms.GroupBox();
            this.nUDTimeForAnswer = new System.Windows.Forms.NumericUpDown();
            this.cBTimeForAnswer = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tSSTotalTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.tSSTestTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.gBTestType = new System.Windows.Forms.GroupBox();
            this.rbNumbersAndSymbols = new System.Windows.Forms.RadioButton();
            this.rbNumbers = new System.Windows.Forms.RadioButton();
            this.errorPictureBox = new MnemoTrainer.Controls.ErrorPictureBox(this.components);
            this.gBSymbols.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSymbolsCount)).BeginInit();
            this.gbVisibleTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).BeginInit();
            this.gBTimeForAnswer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForAnswer)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.gBTestType.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBSymbols
            // 
            this.gBSymbols.Controls.Add(this.nUDSymbolsCount);
            this.gBSymbols.Location = new System.Drawing.Point(228, 12);
            this.gBSymbols.Name = "gBSymbols";
            this.gBSymbols.Size = new System.Drawing.Size(72, 40);
            this.gBSymbols.TabIndex = 3;
            this.gBSymbols.TabStop = false;
            this.gBSymbols.Text = "Символов";
            // 
            // nUDSymbolsCount
            // 
            this.nUDSymbolsCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDSymbolsCount.Location = new System.Drawing.Point(3, 16);
            this.nUDSymbolsCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDSymbolsCount.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUDSymbolsCount.Name = "nUDSymbolsCount";
            this.nUDSymbolsCount.Size = new System.Drawing.Size(66, 20);
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
            this.tBTestWord.Location = new System.Drawing.Point(168, 336);
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
            this.lblTestWord.Font = new System.Drawing.Font("Lucida Console", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTestWord.ForeColor = System.Drawing.Color.Green;
            this.lblTestWord.Location = new System.Drawing.Point(12, 90);
            this.lblTestWord.Name = "lblTestWord";
            this.lblTestWord.Size = new System.Drawing.Size(762, 218);
            this.lblTestWord.TabIndex = 4;
            this.lblTestWord.Text = "1 2 3 4 5 6   1 2 3 4 5 6\r\n7 8 9 0 1 2   7 8 9 0 1 2";
            this.lblTestWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTestWord.Visible = false;
            // 
            // lblCheckResult
            // 
            this.lblCheckResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCheckResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCheckResult.ForeColor = System.Drawing.Color.Green;
            this.lblCheckResult.Location = new System.Drawing.Point(70, 399);
            this.lblCheckResult.Name = "lblCheckResult";
            this.lblCheckResult.Size = new System.Drawing.Size(646, 110);
            this.lblCheckResult.TabIndex = 5;
            this.lblCheckResult.Text = "Ответ";
            this.lblCheckResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCheckResult.Visible = false;
            // 
            // gbVisibleTime
            // 
            this.gbVisibleTime.Controls.Add(this.nUDVisibleTime);
            this.gbVisibleTime.Controls.Add(this.cBVisionTime);
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
            1000,
            0,
            0,
            0});
            this.nUDVisibleTime.ValueChanged += new System.EventHandler(this.nUDVisibleTime_ValueChanged);
            // 
            // cBVisionTime
            // 
            this.cBVisionTime.AutoSize = true;
            this.cBVisionTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBVisionTime.Location = new System.Drawing.Point(3, 16);
            this.cBVisionTime.Name = "cBVisionTime";
            this.cBVisionTime.Size = new System.Drawing.Size(15, 21);
            this.cBVisionTime.TabIndex = 0;
            this.cBVisionTime.UseVisualStyleBackColor = true;
            this.cBVisionTime.CheckedChanged += new System.EventHandler(this.cBVisionTime_CheckedChanged);
            // 
            // gBTimeForAnswer
            // 
            this.gBTimeForAnswer.Controls.Add(this.nUDTimeForAnswer);
            this.gBTimeForAnswer.Controls.Add(this.cBTimeForAnswer);
            this.gBTimeForAnswer.Location = new System.Drawing.Point(119, 12);
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
            // cBTimeForAnswer
            // 
            this.cBTimeForAnswer.AutoSize = true;
            this.cBTimeForAnswer.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBTimeForAnswer.Location = new System.Drawing.Point(3, 16);
            this.cBTimeForAnswer.Name = "cBTimeForAnswer";
            this.cBTimeForAnswer.Size = new System.Drawing.Size(15, 21);
            this.cBTimeForAnswer.TabIndex = 0;
            this.cBTimeForAnswer.UseVisualStyleBackColor = true;
            this.cBTimeForAnswer.CheckedChanged += new System.EventHandler(this.cBTimeForAnswer_CheckedChanged);
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
            // gBTestType
            // 
            this.gBTestType.Controls.Add(this.rbNumbersAndSymbols);
            this.gBTestType.Controls.Add(this.rbNumbers);
            this.gBTestType.Location = new System.Drawing.Point(306, 12);
            this.gBTestType.Name = "gBTestType";
            this.gBTestType.Size = new System.Drawing.Size(197, 40);
            this.gBTestType.TabIndex = 4;
            this.gBTestType.TabStop = false;
            this.gBTestType.Text = "Тип теста";
            // 
            // rbNumbersAndSymbols
            // 
            this.rbNumbersAndSymbols.AutoSize = true;
            this.rbNumbersAndSymbols.Location = new System.Drawing.Point(73, 19);
            this.rbNumbersAndSymbols.Name = "rbNumbersAndSymbols";
            this.rbNumbersAndSymbols.Size = new System.Drawing.Size(119, 17);
            this.rbNumbersAndSymbols.TabIndex = 1;
            this.rbNumbersAndSymbols.Text = "Цифры и символы";
            this.rbNumbersAndSymbols.UseVisualStyleBackColor = true;
            // 
            // rbNumbers
            // 
            this.rbNumbers.AutoSize = true;
            this.rbNumbers.Checked = true;
            this.rbNumbers.Location = new System.Drawing.Point(6, 19);
            this.rbNumbers.Name = "rbNumbers";
            this.rbNumbers.Size = new System.Drawing.Size(61, 17);
            this.rbNumbers.TabIndex = 0;
            this.rbNumbers.TabStop = true;
            this.rbNumbers.Text = "Цифры";
            this.rbNumbers.UseVisualStyleBackColor = true;
            this.rbNumbers.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // errorPictureBox
            // 
            this.errorPictureBox.Location = new System.Drawing.Point(130, 333);
            this.errorPictureBox.Name = "errorPictureBox";
            this.errorPictureBox.Size = new System.Drawing.Size(32, 32);
            this.errorPictureBox.TabIndex = 17;
            this.errorPictureBox.TabStop = false;
            // 
            // FormStepanovTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 541);
            this.Controls.Add(this.errorPictureBox);
            this.Controls.Add(this.gBTestType);
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
            this.Name = "FormStepanovTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Упражнение Степанова";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormStepanovTrain_KeyDown);
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
            this.gBTestType.ResumeLayout(false);
            this.gBTestType.PerformLayout();
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
        private System.Windows.Forms.CheckBox cBVisionTime;
        private System.Windows.Forms.GroupBox gBTimeForAnswer;
        private System.Windows.Forms.NumericUpDown nUDTimeForAnswer;
        private System.Windows.Forms.CheckBox cBTimeForAnswer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.GroupBox gBTestType;
        private System.Windows.Forms.RadioButton rbNumbersAndSymbols;
        private System.Windows.Forms.RadioButton rbNumbers;
        private Controls.ToolStripStatusTimer tSSTestTimer;
        private Controls.ErrorPictureBox errorPictureBox;
        private Controls.ToolStripStatusTimer tSSTotalTimer;
    }
}