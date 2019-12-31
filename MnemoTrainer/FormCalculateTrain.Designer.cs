namespace MnemoTrainer
{
    partial class FormCalculateTrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalculateTrain));
            this.tBTestWord = new System.Windows.Forms.TextBox();
            this.lblTestWord = new System.Windows.Forms.Label();
            this.lblCheckResult = new System.Windows.Forms.Label();
            this.gbVisibleTime = new System.Windows.Forms.GroupBox();
            this.nUDVisibleTime = new System.Windows.Forms.NumericUpDown();
            this.cBVisionTime = new System.Windows.Forms.CheckBox();
            this.gBTrainType = new System.Windows.Forms.GroupBox();
            this.rbAddition = new System.Windows.Forms.RadioButton();
            this.rbMultiplication = new System.Windows.Forms.RadioButton();
            this.gBAdditionOptions = new System.Windows.Forms.GroupBox();
            this.nUDNumberCount = new System.Windows.Forms.NumericUpDown();
            this.cBAddMinus = new System.Windows.Forms.CheckBox();
            this.gBMultiplication = new System.Windows.Forms.GroupBox();
            this.nUDx2Right = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nUDx2Left = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nUDx1Right = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDx1Left = new System.Windows.Forms.NumericUpDown();
            this.gBTimeForAnswer = new System.Windows.Forms.GroupBox();
            this.nUDTimeForAnswer = new System.Windows.Forms.NumericUpDown();
            this.cBTimeForAnswer = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tSSTotalTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.tSSTestTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.errorPictureBox = new MnemoTrainer.Controls.ErrorPictureBox(this.components);
            this.gbVisibleTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).BeginInit();
            this.gBTrainType.SuspendLayout();
            this.gBAdditionOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNumberCount)).BeginInit();
            this.gBMultiplication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDx2Right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDx2Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDx1Right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDx1Left)).BeginInit();
            this.gBTimeForAnswer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForAnswer)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.lblTestWord.Text = "Тест";
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
            // gBTrainType
            // 
            this.gBTrainType.Controls.Add(this.rbAddition);
            this.gBTrainType.Controls.Add(this.rbMultiplication);
            this.gBTrainType.Location = new System.Drawing.Point(228, 12);
            this.gBTrainType.Name = "gBTrainType";
            this.gBTrainType.Size = new System.Drawing.Size(172, 40);
            this.gBTrainType.TabIndex = 3;
            this.gBTrainType.TabStop = false;
            this.gBTrainType.Text = "Тип тренировки";
            // 
            // rbAddition
            // 
            this.rbAddition.AutoSize = true;
            this.rbAddition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbAddition.Location = new System.Drawing.Point(88, 16);
            this.rbAddition.Name = "rbAddition";
            this.rbAddition.Size = new System.Drawing.Size(81, 21);
            this.rbAddition.TabIndex = 1;
            this.rbAddition.Text = "Сложение";
            this.rbAddition.UseVisualStyleBackColor = true;
            this.rbAddition.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbMultiplication
            // 
            this.rbMultiplication.AutoSize = true;
            this.rbMultiplication.Checked = true;
            this.rbMultiplication.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbMultiplication.Location = new System.Drawing.Point(3, 16);
            this.rbMultiplication.Name = "rbMultiplication";
            this.rbMultiplication.Size = new System.Drawing.Size(85, 21);
            this.rbMultiplication.TabIndex = 0;
            this.rbMultiplication.TabStop = true;
            this.rbMultiplication.Text = "Умножение";
            this.rbMultiplication.UseVisualStyleBackColor = true;
            this.rbMultiplication.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // gBAdditionOptions
            // 
            this.gBAdditionOptions.Controls.Add(this.nUDNumberCount);
            this.gBAdditionOptions.Controls.Add(this.cBAddMinus);
            this.gBAdditionOptions.Location = new System.Drawing.Point(658, 12);
            this.gBAdditionOptions.Name = "gBAdditionOptions";
            this.gBAdditionOptions.Size = new System.Drawing.Size(103, 40);
            this.gBAdditionOptions.TabIndex = 5;
            this.gBAdditionOptions.TabStop = false;
            this.gBAdditionOptions.Text = "Сложение";
            // 
            // nUDNumberCount
            // 
            this.nUDNumberCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDNumberCount.Location = new System.Drawing.Point(3, 16);
            this.nUDNumberCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDNumberCount.Name = "nUDNumberCount";
            this.nUDNumberCount.Size = new System.Drawing.Size(52, 20);
            this.nUDNumberCount.TabIndex = 0;
            this.nUDNumberCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDNumberCount.ValueChanged += new System.EventHandler(this.nUDNumberCount_ValueChanged);
            // 
            // cBAddMinus
            // 
            this.cBAddMinus.AutoSize = true;
            this.cBAddMinus.Dock = System.Windows.Forms.DockStyle.Right;
            this.cBAddMinus.Location = new System.Drawing.Point(55, 16);
            this.cBAddMinus.Name = "cBAddMinus";
            this.cBAddMinus.Size = new System.Drawing.Size(45, 21);
            this.cBAddMinus.TabIndex = 1;
            this.cBAddMinus.Text = "Отр";
            this.cBAddMinus.UseVisualStyleBackColor = true;
            this.cBAddMinus.CheckedChanged += new System.EventHandler(this.cBAddMinus_CheckedChanged);
            // 
            // gBMultiplication
            // 
            this.gBMultiplication.Controls.Add(this.nUDx2Right);
            this.gBMultiplication.Controls.Add(this.label3);
            this.gBMultiplication.Controls.Add(this.nUDx2Left);
            this.gBMultiplication.Controls.Add(this.label2);
            this.gBMultiplication.Controls.Add(this.nUDx1Right);
            this.gBMultiplication.Controls.Add(this.label1);
            this.gBMultiplication.Controls.Add(this.nUDx1Left);
            this.gBMultiplication.Location = new System.Drawing.Point(406, 12);
            this.gBMultiplication.Name = "gBMultiplication";
            this.gBMultiplication.Size = new System.Drawing.Size(246, 40);
            this.gBMultiplication.TabIndex = 4;
            this.gBMultiplication.TabStop = false;
            this.gBMultiplication.Text = "Умножение";
            // 
            // nUDx2Right
            // 
            this.nUDx2Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDx2Right.Location = new System.Drawing.Point(198, 16);
            this.nUDx2Right.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nUDx2Right.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDx2Right.Name = "nUDx2Right";
            this.nUDx2Right.Size = new System.Drawing.Size(45, 20);
            this.nUDx2Right.TabIndex = 3;
            this.nUDx2Right.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nUDx2Right.ValueChanged += new System.EventHandler(this.nUDx2Right_ValueChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(183, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "-";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nUDx2Left
            // 
            this.nUDx2Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.nUDx2Left.Location = new System.Drawing.Point(138, 16);
            this.nUDx2Left.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nUDx2Left.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDx2Left.Name = "nUDx2Left";
            this.nUDx2Left.Size = new System.Drawing.Size(45, 20);
            this.nUDx2Left.TabIndex = 2;
            this.nUDx2Left.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDx2Left.ValueChanged += new System.EventHandler(this.nUDx2Left_ValueChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(108, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "X";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nUDx1Right
            // 
            this.nUDx1Right.Dock = System.Windows.Forms.DockStyle.Left;
            this.nUDx1Right.Location = new System.Drawing.Point(63, 16);
            this.nUDx1Right.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nUDx1Right.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDx1Right.Name = "nUDx1Right";
            this.nUDx1Right.Size = new System.Drawing.Size(45, 20);
            this.nUDx1Right.TabIndex = 1;
            this.nUDx1Right.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nUDx1Right.ValueChanged += new System.EventHandler(this.nUDx1Right_ValueChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(48, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "-";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nUDx1Left
            // 
            this.nUDx1Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.nUDx1Left.Location = new System.Drawing.Point(3, 16);
            this.nUDx1Left.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nUDx1Left.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDx1Left.Name = "nUDx1Left";
            this.nUDx1Left.Size = new System.Drawing.Size(45, 20);
            this.nUDx1Left.TabIndex = 0;
            this.nUDx1Left.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDx1Left.ValueChanged += new System.EventHandler(this.nUDx1Left_ValueChanged);
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
            // errorPictureBox
            // 
            this.errorPictureBox.Location = new System.Drawing.Point(130, 284);
            this.errorPictureBox.Name = "errorPictureBox";
            this.errorPictureBox.Size = new System.Drawing.Size(32, 32);
            this.errorPictureBox.TabIndex = 17;
            this.errorPictureBox.TabStop = false;
            // 
            // FormCalculateTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 541);
            this.Controls.Add(this.errorPictureBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gBTimeForAnswer);
            this.Controls.Add(this.gBMultiplication);
            this.Controls.Add(this.gBAdditionOptions);
            this.Controls.Add(this.gBTrainType);
            this.Controls.Add(this.gbVisibleTime);
            this.Controls.Add(this.lblCheckResult);
            this.Controls.Add(this.tBTestWord);
            this.Controls.Add(this.lblTestWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormCalculateTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Тренировка \"Устный счет\"";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormCalculateTrain_KeyDown);
            this.gbVisibleTime.ResumeLayout(false);
            this.gbVisibleTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).EndInit();
            this.gBTrainType.ResumeLayout(false);
            this.gBTrainType.PerformLayout();
            this.gBAdditionOptions.ResumeLayout(false);
            this.gBAdditionOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNumberCount)).EndInit();
            this.gBMultiplication.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDx2Right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDx2Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDx1Right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDx1Left)).EndInit();
            this.gBTimeForAnswer.ResumeLayout(false);
            this.gBTimeForAnswer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForAnswer)).EndInit();
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
        private System.Windows.Forms.GroupBox gBTrainType;
        private System.Windows.Forms.RadioButton rbMultiplication;
        private System.Windows.Forms.RadioButton rbAddition;
        private System.Windows.Forms.GroupBox gBAdditionOptions;
        private System.Windows.Forms.NumericUpDown nUDNumberCount;
        private System.Windows.Forms.GroupBox gBMultiplication;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDx1Right;
        private System.Windows.Forms.NumericUpDown nUDx1Left;
        private System.Windows.Forms.NumericUpDown nUDx2Right;
        private System.Windows.Forms.NumericUpDown nUDx2Left;
        private System.Windows.Forms.GroupBox gBTimeForAnswer;
        private System.Windows.Forms.NumericUpDown nUDTimeForAnswer;
        private System.Windows.Forms.CheckBox cBTimeForAnswer;
        private System.Windows.Forms.CheckBox cBAddMinus;
        private System.Windows.Forms.StatusStrip statusStrip;
        private Controls.ToolStripStatusTimer tSSTestTimer;
        private Controls.ErrorPictureBox errorPictureBox;
        private Controls.ToolStripStatusTimer tSSTotalTimer;
    }
}