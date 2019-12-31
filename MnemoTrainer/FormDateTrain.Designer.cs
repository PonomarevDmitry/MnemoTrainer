namespace MnemoTrainer
{
    partial class FormDateTrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDateTrain));
            this.tBTestWord = new System.Windows.Forms.TextBox();
            this.lblTestWord = new System.Windows.Forms.Label();
            this.lblCheckResult = new System.Windows.Forms.Label();
            this.gbVisibleTime = new System.Windows.Forms.GroupBox();
            this.nUDVisibleTime = new System.Windows.Forms.NumericUpDown();
            this.cBVisionTime = new System.Windows.Forms.CheckBox();
            this.gbRange = new System.Windows.Forms.GroupBox();
            this.nUDRight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nUDLeft = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dTPCheck = new System.Windows.Forms.DateTimePicker();
            this.gBTimeForAnswer = new System.Windows.Forms.GroupBox();
            this.nUDTimeForAnswer = new System.Windows.Forms.NumericUpDown();
            this.cBTimeForAnswer = new System.Windows.Forms.CheckBox();
            this.gBTestType = new System.Windows.Forms.GroupBox();
            this.rBYear12 = new System.Windows.Forms.RadioButton();
            this.rBYear = new System.Windows.Forms.RadioButton();
            this.rBMonth = new System.Windows.Forms.RadioButton();
            this.rBDayOfWeek = new System.Windows.Forms.RadioButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.errorPictureBox = new MnemoTrainer.Controls.ErrorPictureBox(this.components);
            this.tSSTotalTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.tSSTestTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.gbVisibleTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).BeginInit();
            this.gbRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLeft)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gBTimeForAnswer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForAnswer)).BeginInit();
            this.gBTestType.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tBTestWord
            // 
            this.tBTestWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tBTestWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBTestWord.Location = new System.Drawing.Point(168, 287);
            this.tBTestWord.MaxLength = 2;
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
            this.lblTestWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTestWord.ForeColor = System.Drawing.Color.Green;
            this.lblTestWord.Location = new System.Drawing.Point(12, 90);
            this.lblTestWord.Name = "lblTestWord";
            this.lblTestWord.Size = new System.Drawing.Size(762, 169);
            this.lblTestWord.TabIndex = 11;
            this.lblTestWord.Text = "31 января 2048 г.";
            this.lblTestWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTestWord.Visible = false;
            // 
            // lblCheckResult
            // 
            this.lblCheckResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCheckResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCheckResult.ForeColor = System.Drawing.Color.Green;
            this.lblCheckResult.Location = new System.Drawing.Point(70, 350);
            this.lblCheckResult.Name = "lblCheckResult";
            this.lblCheckResult.Size = new System.Drawing.Size(646, 110);
            this.lblCheckResult.TabIndex = 14;
            this.lblCheckResult.Text = "Ответ\r\n7,0 с";
            this.lblCheckResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCheckResult.Visible = false;
            // 
            // gbVisibleTime
            // 
            this.gbVisibleTime.Controls.Add(this.nUDVisibleTime);
            this.gbVisibleTime.Controls.Add(this.cBVisionTime);
            this.gbVisibleTime.Location = new System.Drawing.Point(7, 12);
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
            this.nUDVisibleTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nUD_KeyDown);
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
            // gbRange
            // 
            this.gbRange.Controls.Add(this.nUDRight);
            this.gbRange.Controls.Add(this.label2);
            this.gbRange.Controls.Add(this.nUDLeft);
            this.gbRange.Controls.Add(this.label1);
            this.gbRange.Location = new System.Drawing.Point(463, 12);
            this.gbRange.Name = "gbRange";
            this.gbRange.Size = new System.Drawing.Size(177, 40);
            this.gbRange.TabIndex = 4;
            this.gbRange.TabStop = false;
            this.gbRange.Text = "Диапазон годов";
            this.gbRange.Validating += new System.ComponentModel.CancelEventHandler(this.gbRange_Validating);
            // 
            // nUDRight
            // 
            this.nUDRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDRight.Location = new System.Drawing.Point(113, 16);
            this.nUDRight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDRight.Name = "nUDRight";
            this.nUDRight.Size = new System.Drawing.Size(61, 20);
            this.nUDRight.TabIndex = 4;
            this.nUDRight.Value = new decimal(new int[] {
            2080,
            0,
            0,
            0});
            this.nUDRight.ValueChanged += new System.EventHandler(this.nUDRight_ValueChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(83, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "до";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nUDLeft
            // 
            this.nUDLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.nUDLeft.Location = new System.Drawing.Point(23, 16);
            this.nUDLeft.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDLeft.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDLeft.Name = "nUDLeft";
            this.nUDLeft.Size = new System.Drawing.Size(60, 20);
            this.nUDLeft.TabIndex = 2;
            this.nUDLeft.Value = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            this.nUDLeft.ValueChanged += new System.EventHandler(this.nUDLeft_ValueChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "С";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dTPCheck);
            this.groupBox1.Location = new System.Drawing.Point(646, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 40);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Проверка дня";
            // 
            // dTPCheck
            // 
            this.dTPCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dTPCheck.Location = new System.Drawing.Point(3, 16);
            this.dTPCheck.Name = "dTPCheck";
            this.dTPCheck.Size = new System.Drawing.Size(127, 20);
            this.dTPCheck.TabIndex = 0;
            this.dTPCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dTPCheck_KeyDown);
            // 
            // gBTimeForAnswer
            // 
            this.gBTimeForAnswer.Controls.Add(this.nUDTimeForAnswer);
            this.gBTimeForAnswer.Controls.Add(this.cBTimeForAnswer);
            this.gBTimeForAnswer.Location = new System.Drawing.Point(114, 12);
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
            this.nUDTimeForAnswer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nUD_KeyDown);
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
            // gBTestType
            // 
            this.gBTestType.Controls.Add(this.rBYear12);
            this.gBTestType.Controls.Add(this.rBYear);
            this.gBTestType.Controls.Add(this.rBMonth);
            this.gBTestType.Controls.Add(this.rBDayOfWeek);
            this.gBTestType.Location = new System.Drawing.Point(223, 12);
            this.gBTestType.Name = "gBTestType";
            this.gBTestType.Size = new System.Drawing.Size(234, 40);
            this.gBTestType.TabIndex = 3;
            this.gBTestType.TabStop = false;
            this.gBTestType.Text = "Тип тренировки";
            // 
            // rBYear12
            // 
            this.rBYear12.AutoSize = true;
            this.rBYear12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rBYear12.Location = new System.Drawing.Point(156, 16);
            this.rBYear12.Name = "rBYear12";
            this.rBYear12.Size = new System.Drawing.Size(75, 21);
            this.rBYear12.TabIndex = 3;
            this.rBYear12.TabStop = true;
            this.rBYear12.Text = "Год до 12";
            this.rBYear12.UseVisualStyleBackColor = true;
            this.rBYear12.CheckedChanged += new System.EventHandler(this.rB_CheckedChanged);
            // 
            // rBYear
            // 
            this.rBYear.AutoSize = true;
            this.rBYear.Dock = System.Windows.Forms.DockStyle.Left;
            this.rBYear.Location = new System.Drawing.Point(113, 16);
            this.rBYear.Name = "rBYear";
            this.rBYear.Size = new System.Drawing.Size(43, 21);
            this.rBYear.TabIndex = 2;
            this.rBYear.TabStop = true;
            this.rBYear.Text = "Год";
            this.rBYear.UseVisualStyleBackColor = true;
            this.rBYear.CheckedChanged += new System.EventHandler(this.rB_CheckedChanged);
            // 
            // rBMonth
            // 
            this.rBMonth.AutoSize = true;
            this.rBMonth.Dock = System.Windows.Forms.DockStyle.Left;
            this.rBMonth.Location = new System.Drawing.Point(55, 16);
            this.rBMonth.Name = "rBMonth";
            this.rBMonth.Size = new System.Drawing.Size(58, 21);
            this.rBMonth.TabIndex = 1;
            this.rBMonth.TabStop = true;
            this.rBMonth.Text = "Месяц";
            this.rBMonth.UseVisualStyleBackColor = true;
            this.rBMonth.CheckedChanged += new System.EventHandler(this.rB_CheckedChanged);
            // 
            // rBDayOfWeek
            // 
            this.rBDayOfWeek.AutoSize = true;
            this.rBDayOfWeek.Checked = true;
            this.rBDayOfWeek.Dock = System.Windows.Forms.DockStyle.Left;
            this.rBDayOfWeek.Location = new System.Drawing.Point(3, 16);
            this.rBDayOfWeek.Name = "rBDayOfWeek";
            this.rBDayOfWeek.Size = new System.Drawing.Size(52, 21);
            this.rBDayOfWeek.TabIndex = 0;
            this.rBDayOfWeek.TabStop = true;
            this.rBDayOfWeek.Text = "День";
            this.rBDayOfWeek.UseVisualStyleBackColor = true;
            this.rBDayOfWeek.CheckedChanged += new System.EventHandler(this.rB_CheckedChanged);
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
            this.statusStrip.TabIndex = 15;
            this.statusStrip.Text = "statusStrip1";
            // 
            // errorPictureBox
            // 
            this.errorPictureBox.Location = new System.Drawing.Point(130, 284);
            this.errorPictureBox.Name = "errorPictureBox";
            this.errorPictureBox.Size = new System.Drawing.Size(32, 32);
            this.errorPictureBox.TabIndex = 16;
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
            this.tSSTestTimer.Format = "Время теста: {0} с.";
            this.tSSTestTimer.Name = "tSSTestTimer";
            this.tSSTestTimer.Size = new System.Drawing.Size(0, 17);
            // 
            // FormDateTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 541);
            this.Controls.Add(this.errorPictureBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gBTestType);
            this.Controls.Add(this.gBTimeForAnswer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbRange);
            this.Controls.Add(this.gbVisibleTime);
            this.Controls.Add(this.lblCheckResult);
            this.Controls.Add(this.tBTestWord);
            this.Controls.Add(this.lblTestWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormDateTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Тренировка \"День недели\"";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormDateTrain_KeyDown);
            this.gbVisibleTime.ResumeLayout(false);
            this.gbVisibleTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).EndInit();
            this.gbRange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLeft)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gBTimeForAnswer.ResumeLayout(false);
            this.gBTimeForAnswer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForAnswer)).EndInit();
            this.gBTestType.ResumeLayout(false);
            this.gBTestType.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBTestWord;
        private System.Windows.Forms.Label lblTestWord;
        private System.Windows.Forms.Label lblCheckResult;
        private System.Windows.Forms.GroupBox gbVisibleTime;
        private System.Windows.Forms.NumericUpDown nUDVisibleTime;
        private System.Windows.Forms.CheckBox cBVisionTime;
        private System.Windows.Forms.GroupBox gbRange;
        private System.Windows.Forms.NumericUpDown nUDRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDLeft;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dTPCheck;
        private System.Windows.Forms.GroupBox gBTimeForAnswer;
        private System.Windows.Forms.NumericUpDown nUDTimeForAnswer;
        private System.Windows.Forms.CheckBox cBTimeForAnswer;
        private System.Windows.Forms.GroupBox gBTestType;
        private System.Windows.Forms.RadioButton rBYear12;
        private System.Windows.Forms.RadioButton rBYear;
        private System.Windows.Forms.RadioButton rBDayOfWeek;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.RadioButton rBMonth;
        private Controls.ToolStripStatusTimer tSSTestTimer;
        private Controls.ErrorPictureBox errorPictureBox;
        private Controls.ToolStripStatusTimer tSSTotalTimer;
    }
}