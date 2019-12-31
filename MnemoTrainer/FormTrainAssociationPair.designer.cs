namespace MnemoTrainer
{
    partial class FormTrainAssociationPair
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrainAssociationPair));
            this.btnStartStop = new System.Windows.Forms.Button();
            this.gBWords = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDWordsInPair = new System.Windows.Forms.NumericUpDown();
            this.nUDQuestionCount = new System.Windows.Forms.NumericUpDown();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tStStatusWords = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStStatusCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSTotalTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.tSSTestTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.gBTimeForWord = new System.Windows.Forms.GroupBox();
            this.nUDTimeForWord = new System.Windows.Forms.NumericUpDown();
            this.cBTimeForWord = new System.Windows.Forms.CheckBox();
            this.lblNextWord = new System.Windows.Forms.Label();
            this.cBWithNumber = new System.Windows.Forms.CheckBox();
            this.gBAnswers = new System.Windows.Forms.GroupBox();
            this.lBTestWords = new System.Windows.Forms.ListBox();
            this.gBSetup = new System.Windows.Forms.GroupBox();
            this.gBDictionary = new System.Windows.Forms.GroupBox();
            this.cBDictionary = new System.Windows.Forms.ComboBox();
            this.gBNumberSetup = new System.Windows.Forms.GroupBox();
            this.cBRandomPosition = new System.Windows.Forms.CheckBox();
            this.cBCounter = new System.Windows.Forms.CheckBox();
            this.gBWords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDWordsInPair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDQuestionCount)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.gBTimeForWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForWord)).BeginInit();
            this.gBAnswers.SuspendLayout();
            this.gBSetup.SuspendLayout();
            this.gBDictionary.SuspendLayout();
            this.gBNumberSetup.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(6, 19);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 40);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Новый тест";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // gBWords
            // 
            this.gBWords.Controls.Add(this.label1);
            this.gBWords.Controls.Add(this.nUDWordsInPair);
            this.gBWords.Controls.Add(this.nUDQuestionCount);
            this.gBWords.Location = new System.Drawing.Point(87, 19);
            this.gBWords.Name = "gBWords";
            this.gBWords.Size = new System.Drawing.Size(136, 40);
            this.gBWords.TabIndex = 1;
            this.gBWords.TabStop = false;
            this.gBWords.Text = "Количество вопросов";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(51, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = " по ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nUDWordsInPair
            // 
            this.nUDWordsInPair.Dock = System.Windows.Forms.DockStyle.Right;
            this.nUDWordsInPair.Location = new System.Drawing.Point(85, 16);
            this.nUDWordsInPair.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDWordsInPair.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nUDWordsInPair.Name = "nUDWordsInPair";
            this.nUDWordsInPair.Size = new System.Drawing.Size(48, 20);
            this.nUDWordsInPair.TabIndex = 3;
            this.nUDWordsInPair.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDWordsInPair.ValueChanged += new System.EventHandler(this.nUDWordsInPair_ValueChanged);
            // 
            // nUDQuestionCount
            // 
            this.nUDQuestionCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.nUDQuestionCount.Location = new System.Drawing.Point(3, 16);
            this.nUDQuestionCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDQuestionCount.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDQuestionCount.Name = "nUDQuestionCount";
            this.nUDQuestionCount.Size = new System.Drawing.Size(48, 20);
            this.nUDQuestionCount.TabIndex = 1;
            this.nUDQuestionCount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nUDQuestionCount.ValueChanged += new System.EventHandler(this.nUDQuestionCount_ValueChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStStatusWords,
            this.tStStatusCounter,
            this.tSSTotalTimer,
            this.tSSTestTimer});
            this.statusStrip.Location = new System.Drawing.Point(0, 622);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(785, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tStStatusWords
            // 
            this.tStStatusWords.Name = "tStStatusWords";
            this.tStStatusWords.Size = new System.Drawing.Size(0, 17);
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
            this.tSSTestTimer.Format = "Время теста: {0} с.";
            this.tSSTestTimer.Name = "tSSTestTimer";
            this.tSSTestTimer.Size = new System.Drawing.Size(0, 17);
            // 
            // gBTimeForWord
            // 
            this.gBTimeForWord.Controls.Add(this.nUDTimeForWord);
            this.gBTimeForWord.Controls.Add(this.cBTimeForWord);
            this.gBTimeForWord.Location = new System.Drawing.Point(229, 19);
            this.gBTimeForWord.Name = "gBTimeForWord";
            this.gBTimeForWord.Size = new System.Drawing.Size(86, 40);
            this.gBTimeForWord.TabIndex = 3;
            this.gBTimeForWord.TabStop = false;
            this.gBTimeForWord.Text = "На серию";
            // 
            // nUDTimeForWord
            // 
            this.nUDTimeForWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDTimeForWord.Enabled = false;
            this.nUDTimeForWord.Location = new System.Drawing.Point(21, 16);
            this.nUDTimeForWord.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nUDTimeForWord.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDTimeForWord.Name = "nUDTimeForWord";
            this.nUDTimeForWord.ReadOnly = true;
            this.nUDTimeForWord.Size = new System.Drawing.Size(62, 20);
            this.nUDTimeForWord.TabIndex = 3;
            this.nUDTimeForWord.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nUDTimeForWord.ValueChanged += new System.EventHandler(this.nUDTimeForWord_ValueChanged);
            // 
            // cBTimeForWord
            // 
            this.cBTimeForWord.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBTimeForWord.Location = new System.Drawing.Point(3, 16);
            this.cBTimeForWord.Name = "cBTimeForWord";
            this.cBTimeForWord.Size = new System.Drawing.Size(18, 21);
            this.cBTimeForWord.TabIndex = 0;
            this.cBTimeForWord.UseVisualStyleBackColor = true;
            this.cBTimeForWord.CheckedChanged += new System.EventHandler(this.cBTimeForWord_CheckedChanged);
            // 
            // lblNextWord
            // 
            this.lblNextWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNextWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNextWord.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblNextWord.Location = new System.Drawing.Point(0, 66);
            this.lblNextWord.Name = "lblNextWord";
            this.lblNextWord.Size = new System.Drawing.Size(785, 556);
            this.lblNextWord.TabIndex = 1;
            this.lblNextWord.Text = "Тест";
            this.lblNextWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNextWord.Visible = false;
            this.lblNextWord.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblNextWord_MouseClick);
            // 
            // cBWithNumber
            // 
            this.cBWithNumber.AutoSize = true;
            this.cBWithNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBWithNumber.Location = new System.Drawing.Point(69, 16);
            this.cBWithNumber.Name = "cBWithNumber";
            this.cBWithNumber.Size = new System.Drawing.Size(82, 21);
            this.cBWithNumber.TabIndex = 4;
            this.cBWithNumber.Text = "С номером";
            this.cBWithNumber.UseVisualStyleBackColor = true;
            this.cBWithNumber.CheckedChanged += new System.EventHandler(this.cBWithNumber_CheckedChanged);
            // 
            // gBAnswers
            // 
            this.gBAnswers.Controls.Add(this.lBTestWords);
            this.gBAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBAnswers.Location = new System.Drawing.Point(0, 66);
            this.gBAnswers.Name = "gBAnswers";
            this.gBAnswers.Size = new System.Drawing.Size(785, 556);
            this.gBAnswers.TabIndex = 7;
            this.gBAnswers.TabStop = false;
            this.gBAnswers.Visible = false;
            // 
            // lBTestWords
            // 
            this.lBTestWords.ColumnWidth = 150;
            this.lBTestWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBTestWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lBTestWords.FormattingEnabled = true;
            this.lBTestWords.HorizontalScrollbar = true;
            this.lBTestWords.ItemHeight = 18;
            this.lBTestWords.Location = new System.Drawing.Point(3, 16);
            this.lBTestWords.Name = "lBTestWords";
            this.lBTestWords.ScrollAlwaysVisible = true;
            this.lBTestWords.Size = new System.Drawing.Size(779, 537);
            this.lBTestWords.TabIndex = 0;
            // 
            // gBSetup
            // 
            this.gBSetup.Controls.Add(this.gBDictionary);
            this.gBSetup.Controls.Add(this.gBNumberSetup);
            this.gBSetup.Controls.Add(this.gBWords);
            this.gBSetup.Controls.Add(this.btnStartStop);
            this.gBSetup.Controls.Add(this.gBTimeForWord);
            this.gBSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBSetup.Location = new System.Drawing.Point(0, 0);
            this.gBSetup.Name = "gBSetup";
            this.gBSetup.Size = new System.Drawing.Size(785, 66);
            this.gBSetup.TabIndex = 1;
            this.gBSetup.TabStop = false;
            this.gBSetup.Text = "Настройки";
            // 
            // gBDictionary
            // 
            this.gBDictionary.Controls.Add(this.cBDictionary);
            this.gBDictionary.Location = new System.Drawing.Point(533, 19);
            this.gBDictionary.Name = "gBDictionary";
            this.gBDictionary.Size = new System.Drawing.Size(135, 40);
            this.gBDictionary.TabIndex = 9;
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
            // gBNumberSetup
            // 
            this.gBNumberSetup.Controls.Add(this.cBRandomPosition);
            this.gBNumberSetup.Controls.Add(this.cBWithNumber);
            this.gBNumberSetup.Controls.Add(this.cBCounter);
            this.gBNumberSetup.Location = new System.Drawing.Point(321, 19);
            this.gBNumberSetup.Name = "gBNumberSetup";
            this.gBNumberSetup.Size = new System.Drawing.Size(206, 40);
            this.gBNumberSetup.TabIndex = 8;
            this.gBNumberSetup.TabStop = false;
            // 
            // cBRandomPosition
            // 
            this.cBRandomPosition.AutoSize = true;
            this.cBRandomPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBRandomPosition.Enabled = false;
            this.cBRandomPosition.Location = new System.Drawing.Point(151, 16);
            this.cBRandomPosition.Name = "cBRandomPosition";
            this.cBRandomPosition.Size = new System.Drawing.Size(52, 21);
            this.cBRandomPosition.TabIndex = 5;
            this.cBRandomPosition.Text = "Случ";
            this.cBRandomPosition.UseVisualStyleBackColor = true;
            this.cBRandomPosition.CheckedChanged += new System.EventHandler(this.cBRandomPosition_CheckedChanged);
            // 
            // cBCounter
            // 
            this.cBCounter.AutoSize = true;
            this.cBCounter.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBCounter.Location = new System.Drawing.Point(3, 16);
            this.cBCounter.Name = "cBCounter";
            this.cBCounter.Size = new System.Drawing.Size(66, 21);
            this.cBCounter.TabIndex = 6;
            this.cBCounter.Text = "Счетчик";
            this.cBCounter.UseVisualStyleBackColor = true;
            // 
            // FormAssociationPairTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 644);
            this.Controls.Add(this.gBAnswers);
            this.Controls.Add(this.lblNextWord);
            this.Controls.Add(this.gBSetup);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormAssociationPairTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Тренировка \"Ассоциации пар\"";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormAssociationPairTrain_KeyDown);
            this.gBWords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDWordsInPair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDQuestionCount)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gBTimeForWord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForWord)).EndInit();
            this.gBAnswers.ResumeLayout(false);
            this.gBSetup.ResumeLayout(false);
            this.gBDictionary.ResumeLayout(false);
            this.gBNumberSetup.ResumeLayout(false);
            this.gBNumberSetup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.GroupBox gBWords;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.GroupBox gBTimeForWord;
        private System.Windows.Forms.CheckBox cBTimeForWord;
        private System.Windows.Forms.ToolStripStatusLabel tStStatusWords;
        private System.Windows.Forms.Label lblNextWord;
        private System.Windows.Forms.GroupBox gBAnswers;
        private System.Windows.Forms.ListBox lBTestWords;
        private System.Windows.Forms.CheckBox cBWithNumber;
        private System.Windows.Forms.GroupBox gBSetup;
        private System.Windows.Forms.NumericUpDown nUDQuestionCount;
        private System.Windows.Forms.NumericUpDown nUDTimeForWord;
        private System.Windows.Forms.GroupBox gBNumberSetup;
        private System.Windows.Forms.CheckBox cBRandomPosition;
        private System.Windows.Forms.CheckBox cBCounter;
        private System.Windows.Forms.ToolStripStatusLabel tStStatusCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDWordsInPair;
        private System.Windows.Forms.GroupBox gBDictionary;
        private System.Windows.Forms.ComboBox cBDictionary;
        private Controls.ToolStripStatusTimer tSSTotalTimer;
        private Controls.ToolStripStatusTimer tSSTestTimer;

    }
}

