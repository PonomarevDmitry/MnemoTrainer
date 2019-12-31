namespace MnemoTrainer
{
    partial class FormTrainNet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrainNet));
            this.gbRange = new System.Windows.Forms.GroupBox();
            this.nUDRight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nUDLeft = new System.Windows.Forms.NumericUpDown();
            this.chbValueRange = new System.Windows.Forms.CheckBox();
            this.gBTestType = new System.Windows.Forms.GroupBox();
            this.cBTestType = new System.Windows.Forms.ComboBox();
            this.gBNets = new System.Windows.Forms.GroupBox();
            this.netCheckedListBox = new MnemoTrainer.Controls.NetCheckedListBox();
            this.lblTestWord = new System.Windows.Forms.Label();
            this.tBTestWord = new System.Windows.Forms.TextBox();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tStQuestionCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStStatusCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSTotalTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.tSSTestTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.gBType = new System.Windows.Forms.GroupBox();
            this.rBCalculation = new System.Windows.Forms.RadioButton();
            this.rBNumber = new System.Windows.Forms.RadioButton();
            this.gbVisibleTime = new System.Windows.Forms.GroupBox();
            this.nUDVisibleTime = new System.Windows.Forms.NumericUpDown();
            this.chBVisionTime = new System.Windows.Forms.CheckBox();
            this.errorPictureBox = new MnemoTrainer.Controls.ErrorPictureBox(this.components);
            this.gbRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLeft)).BeginInit();
            this.gBTestType.SuspendLayout();
            this.gBNets.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.gBType.SuspendLayout();
            this.gbVisibleTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).BeginInit();
            this.SuspendLayout();
            // 
            // gbRange
            // 
            this.gbRange.Controls.Add(this.nUDRight);
            this.gbRange.Controls.Add(this.label2);
            this.gbRange.Controls.Add(this.nUDLeft);
            this.gbRange.Controls.Add(this.chbValueRange);
            this.gbRange.Location = new System.Drawing.Point(263, 12);
            this.gbRange.Name = "gbRange";
            this.gbRange.Size = new System.Drawing.Size(136, 40);
            this.gbRange.TabIndex = 2;
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
            // gBTestType
            // 
            this.gBTestType.Controls.Add(this.cBTestType);
            this.gBTestType.Location = new System.Drawing.Point(405, 12);
            this.gBTestType.Name = "gBTestType";
            this.gBTestType.Size = new System.Drawing.Size(122, 40);
            this.gBTestType.TabIndex = 3;
            this.gBTestType.TabStop = false;
            this.gBTestType.Text = "Тип теста";
            // 
            // cBTestType
            // 
            this.cBTestType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBTestType.FormattingEnabled = true;
            this.cBTestType.Items.AddRange(new object[] {
            "Числа и образы",
            "Только числа",
            "Только образы"});
            this.cBTestType.Location = new System.Drawing.Point(3, 16);
            this.cBTestType.Name = "cBTestType";
            this.cBTestType.Size = new System.Drawing.Size(116, 21);
            this.cBTestType.TabIndex = 0;
            this.cBTestType.SelectedIndexChanged += new System.EventHandler(this.cBTestType_SelectedIndexChanged);
            // 
            // gBNets
            // 
            this.gBNets.Controls.Add(this.netCheckedListBox);
            this.gBNets.Location = new System.Drawing.Point(119, 12);
            this.gBNets.Name = "gBNets";
            this.gBNets.Size = new System.Drawing.Size(138, 40);
            this.gBNets.TabIndex = 2;
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
            this.netCheckedListBox.Size = new System.Drawing.Size(132, 21);
            this.netCheckedListBox.TabIndex = 0;
            this.netCheckedListBox.Text = "Не выбрана";
            this.netCheckedListBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTestWord
            // 
            this.lblTestWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTestWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTestWord.ForeColor = System.Drawing.Color.Green;
            this.lblTestWord.Location = new System.Drawing.Point(24, 55);
            this.lblTestWord.Name = "lblTestWord";
            this.lblTestWord.Size = new System.Drawing.Size(646, 233);
            this.lblTestWord.TabIndex = 6;
            this.lblTestWord.Text = "Сложение\r\n10\r\nПо образам";
            this.lblTestWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTestWord.Visible = false;
            // 
            // tBTestWord
            // 
            this.tBTestWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tBTestWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBTestWord.Location = new System.Drawing.Point(237, 294);
            this.tBTestWord.MaxLength = 2;
            this.tBTestWord.Name = "tBTestWord";
            this.tBTestWord.Size = new System.Drawing.Size(220, 29);
            this.tBTestWord.TabIndex = 0;
            this.tBTestWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBTestWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBTestWord_KeyDown);
            this.tBTestWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBTestWord_KeyPress);
            this.tBTestWord.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tBTestWord_PreviewKeyDown);
            // 
            // lblAnswer
            // 
            this.lblAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAnswer.ForeColor = System.Drawing.Color.Green;
            this.lblAnswer.Location = new System.Drawing.Point(24, 347);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(646, 94);
            this.lblAnswer.TabIndex = 7;
            this.lblAnswer.Text = "Ответ";
            this.lblAnswer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAnswer.Visible = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStQuestionCount,
            this.tStStatusCounter,
            this.tSSTotalTimer,
            this.tSSTestTimer});
            this.statusStrip.Location = new System.Drawing.Point(0, 456);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(695, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tStQuestionCount
            // 
            this.tStQuestionCount.Name = "tStQuestionCount";
            this.tStQuestionCount.Size = new System.Drawing.Size(0, 17);
            // 
            // tStStatusCounter
            // 
            this.tStStatusCounter.Name = "tStStatusCounter";
            this.tStStatusCounter.Size = new System.Drawing.Size(0, 17);
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
            // gBType
            // 
            this.gBType.Controls.Add(this.rBCalculation);
            this.gBType.Controls.Add(this.rBNumber);
            this.gBType.Location = new System.Drawing.Point(533, 12);
            this.gBType.Name = "gBType";
            this.gBType.Size = new System.Drawing.Size(150, 40);
            this.gBType.TabIndex = 4;
            this.gBType.TabStop = false;
            // 
            // rBCalculation
            // 
            this.rBCalculation.AutoSize = true;
            this.rBCalculation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rBCalculation.Location = new System.Drawing.Point(60, 16);
            this.rBCalculation.Name = "rBCalculation";
            this.rBCalculation.Size = new System.Drawing.Size(87, 21);
            this.rBCalculation.TabIndex = 1;
            this.rBCalculation.Text = "Вычисление";
            this.rBCalculation.UseVisualStyleBackColor = true;
            // 
            // rBNumber
            // 
            this.rBNumber.AutoSize = true;
            this.rBNumber.Checked = true;
            this.rBNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.rBNumber.Location = new System.Drawing.Point(3, 16);
            this.rBNumber.Name = "rBNumber";
            this.rBNumber.Size = new System.Drawing.Size(57, 21);
            this.rBNumber.TabIndex = 0;
            this.rBNumber.TabStop = true;
            this.rBNumber.Text = "Число";
            this.rBNumber.UseVisualStyleBackColor = true;
            this.rBNumber.CheckedChanged += new System.EventHandler(this.rBNumber_CheckedChanged);
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
            1000,
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
            // errorPictureBox
            // 
            this.errorPictureBox.Location = new System.Drawing.Point(199, 291);
            this.errorPictureBox.Name = "errorPictureBox";
            this.errorPictureBox.Size = new System.Drawing.Size(32, 32);
            this.errorPictureBox.TabIndex = 17;
            this.errorPictureBox.TabStop = false;
            // 
            // FormTrainNet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 478);
            this.Controls.Add(this.errorPictureBox);
            this.Controls.Add(this.gbVisibleTime);
            this.Controls.Add(this.gBType);
            this.Controls.Add(this.gbRange);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gBTestType);
            this.Controls.Add(this.gBNets);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.tBTestWord);
            this.Controls.Add(this.lblTestWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormTrainNet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Тренировка Сетки";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormNetTrain_KeyDown);
            this.gbRange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLeft)).EndInit();
            this.gBTestType.ResumeLayout(false);
            this.gBNets.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gBType.ResumeLayout(false);
            this.gBType.PerformLayout();
            this.gbVisibleTime.ResumeLayout(false);
            this.gbVisibleTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBNets;
        private System.Windows.Forms.GroupBox gBTestType;
        private System.Windows.Forms.ComboBox cBTestType;
        private System.Windows.Forms.Label lblTestWord;
        private System.Windows.Forms.TextBox tBTestWord;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.GroupBox gbRange;
        private System.Windows.Forms.CheckBox chbValueRange;
        private System.Windows.Forms.NumericUpDown nUDLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nUDRight;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tStStatusCounter;
        private System.Windows.Forms.ToolStripStatusLabel tStQuestionCount;
        private System.Windows.Forms.GroupBox gBType;
        private System.Windows.Forms.RadioButton rBNumber;
        private System.Windows.Forms.RadioButton rBCalculation;
        private System.Windows.Forms.GroupBox gbVisibleTime;
        private System.Windows.Forms.NumericUpDown nUDVisibleTime;
        private System.Windows.Forms.CheckBox chBVisionTime;
        private Controls.ToolStripStatusTimer tSSTestTimer;
        private Controls.ErrorPictureBox errorPictureBox;
        private Controls.NetCheckedListBox netCheckedListBox;
        private Controls.ToolStripStatusTimer tSSTotalTimer;
    }
}