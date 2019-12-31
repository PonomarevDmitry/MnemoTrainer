namespace MnemoTrainer
{
    partial class FormAssociationTrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAssociationTrain));
            this.btnStartStop = new System.Windows.Forms.Button();
            this.gBWords = new System.Windows.Forms.GroupBox();
            this.cBWordsRepeat = new System.Windows.Forms.CheckBox();
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
            this.listBoxTestWords = new System.Windows.Forms.ListBox();
            this.gBSetup = new System.Windows.Forms.GroupBox();
            this.gBOldTest = new System.Windows.Forms.GroupBox();
            this.cBWithoutOldTest = new System.Windows.Forms.CheckBox();
            this.nUDOldTestWords = new System.Windows.Forms.NumericUpDown();
            this.gBNumberSetup = new System.Windows.Forms.GroupBox();
            this.cBRandomPosition = new System.Windows.Forms.CheckBox();
            this.cBCounter = new System.Windows.Forms.CheckBox();
            this.gBDictionary = new System.Windows.Forms.GroupBox();
            this.cBDictionary = new System.Windows.Forms.ComboBox();
            this.gBWords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDQuestionCount)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.gBTimeForWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForWord)).BeginInit();
            this.gBAnswers.SuspendLayout();
            this.gBSetup.SuspendLayout();
            this.gBOldTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDOldTestWords)).BeginInit();
            this.gBNumberSetup.SuspendLayout();
            this.gBDictionary.SuspendLayout();
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
            this.gBWords.Controls.Add(this.cBWordsRepeat);
            this.gBWords.Controls.Add(this.nUDQuestionCount);
            this.gBWords.Location = new System.Drawing.Point(87, 19);
            this.gBWords.Name = "gBWords";
            this.gBWords.Size = new System.Drawing.Size(123, 40);
            this.gBWords.TabIndex = 1;
            this.gBWords.TabStop = false;
            this.gBWords.Text = "Количество слов";
            // 
            // cBWordsRepeat
            // 
            this.cBWordsRepeat.AutoSize = true;
            this.cBWordsRepeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBWordsRepeat.Location = new System.Drawing.Point(51, 16);
            this.cBWordsRepeat.Name = "cBWordsRepeat";
            this.cBWordsRepeat.Size = new System.Drawing.Size(69, 21);
            this.cBWordsRepeat.TabIndex = 1;
            this.cBWordsRepeat.Text = "повторы";
            this.cBWordsRepeat.UseVisualStyleBackColor = true;
            this.cBWordsRepeat.CheckedChanged += new System.EventHandler(this.cBWordsRepeat_CheckedChanged);
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
            this.nUDQuestionCount.TabIndex = 0;
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
            this.tSSTotalTimer,
            this.tStStatusCounter,
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
            this.gBTimeForWord.Location = new System.Drawing.Point(213, 19);
            this.gBTimeForWord.Name = "gBTimeForWord";
            this.gBTimeForWord.Size = new System.Drawing.Size(86, 40);
            this.gBTimeForWord.TabIndex = 2;
            this.gBTimeForWord.TabStop = false;
            this.gBTimeForWord.Text = "На слово";
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
            this.nUDTimeForWord.TabIndex = 1;
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
            this.cBTimeForWord.CheckedChanged += new System.EventHandler(this.chcBTimeForWord_CheckedChanged);
            // 
            // lblNextWord
            // 
            this.lblNextWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNextWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNextWord.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblNextWord.Location = new System.Drawing.Point(0, 111);
            this.lblNextWord.Name = "lblNextWord";
            this.lblNextWord.Size = new System.Drawing.Size(785, 511);
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
            this.cBWithNumber.TabIndex = 1;
            this.cBWithNumber.Text = "С номером";
            this.cBWithNumber.UseVisualStyleBackColor = true;
            this.cBWithNumber.CheckedChanged += new System.EventHandler(this.cBWithNumber_CheckedChanged);
            // 
            // gBAnswers
            // 
            this.gBAnswers.Controls.Add(this.listBoxTestWords);
            this.gBAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBAnswers.Location = new System.Drawing.Point(0, 111);
            this.gBAnswers.Name = "gBAnswers";
            this.gBAnswers.Size = new System.Drawing.Size(785, 511);
            this.gBAnswers.TabIndex = 7;
            this.gBAnswers.TabStop = false;
            this.gBAnswers.Visible = false;
            // 
            // listBoxTestWords
            // 
            this.listBoxTestWords.ColumnWidth = 150;
            this.listBoxTestWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTestWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxTestWords.FormattingEnabled = true;
            this.listBoxTestWords.HorizontalScrollbar = true;
            this.listBoxTestWords.ItemHeight = 18;
            this.listBoxTestWords.Location = new System.Drawing.Point(3, 16);
            this.listBoxTestWords.MultiColumn = true;
            this.listBoxTestWords.Name = "listBoxTestWords";
            this.listBoxTestWords.Size = new System.Drawing.Size(779, 492);
            this.listBoxTestWords.TabIndex = 0;
            // 
            // gBSetup
            // 
            this.gBSetup.Controls.Add(this.gBOldTest);
            this.gBSetup.Controls.Add(this.gBNumberSetup);
            this.gBSetup.Controls.Add(this.gBDictionary);
            this.gBSetup.Controls.Add(this.gBWords);
            this.gBSetup.Controls.Add(this.btnStartStop);
            this.gBSetup.Controls.Add(this.gBTimeForWord);
            this.gBSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBSetup.Location = new System.Drawing.Point(0, 0);
            this.gBSetup.Name = "gBSetup";
            this.gBSetup.Size = new System.Drawing.Size(785, 111);
            this.gBSetup.TabIndex = 0;
            this.gBSetup.TabStop = false;
            this.gBSetup.Text = "Настройки";
            // 
            // gBOldTest
            // 
            this.gBOldTest.Controls.Add(this.cBWithoutOldTest);
            this.gBOldTest.Controls.Add(this.nUDOldTestWords);
            this.gBOldTest.Location = new System.Drawing.Point(87, 65);
            this.gBOldTest.Name = "gBOldTest";
            this.gBOldTest.Size = new System.Drawing.Size(212, 40);
            this.gBOldTest.TabIndex = 5;
            this.gBOldTest.TabStop = false;
            // 
            // cBWithoutOldTest
            // 
            this.cBWithoutOldTest.AutoSize = true;
            this.cBWithoutOldTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBWithoutOldTest.Location = new System.Drawing.Point(3, 16);
            this.cBWithoutOldTest.Name = "cBWithoutOldTest";
            this.cBWithoutOldTest.Size = new System.Drawing.Size(158, 21);
            this.cBWithoutOldTest.TabIndex = 0;
            this.cBWithoutOldTest.Text = "Без слов прошлых тестов";
            this.cBWithoutOldTest.UseVisualStyleBackColor = true;
            this.cBWithoutOldTest.CheckedChanged += new System.EventHandler(this.cBWithoutOldTest_CheckedChanged);
            // 
            // nUDOldTestWords
            // 
            this.nUDOldTestWords.Dock = System.Windows.Forms.DockStyle.Right;
            this.nUDOldTestWords.Enabled = false;
            this.nUDOldTestWords.Location = new System.Drawing.Point(161, 16);
            this.nUDOldTestWords.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDOldTestWords.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDOldTestWords.Name = "nUDOldTestWords";
            this.nUDOldTestWords.ReadOnly = true;
            this.nUDOldTestWords.Size = new System.Drawing.Size(48, 20);
            this.nUDOldTestWords.TabIndex = 1;
            this.nUDOldTestWords.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nUDOldTestWords.ValueChanged += new System.EventHandler(this.nUDOldTestWords_ValueChanged);
            // 
            // gBNumberSetup
            // 
            this.gBNumberSetup.Controls.Add(this.cBRandomPosition);
            this.gBNumberSetup.Controls.Add(this.cBWithNumber);
            this.gBNumberSetup.Controls.Add(this.cBCounter);
            this.gBNumberSetup.Location = new System.Drawing.Point(305, 19);
            this.gBNumberSetup.Name = "gBNumberSetup";
            this.gBNumberSetup.Size = new System.Drawing.Size(206, 40);
            this.gBNumberSetup.TabIndex = 3;
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
            this.cBRandomPosition.TabIndex = 2;
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
            this.cBCounter.TabIndex = 0;
            this.cBCounter.Text = "Счетчик";
            this.cBCounter.UseVisualStyleBackColor = true;
            // 
            // gBDictionary
            // 
            this.gBDictionary.Controls.Add(this.cBDictionary);
            this.gBDictionary.Location = new System.Drawing.Point(517, 19);
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
            // FormAssociationTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 644);
            this.Controls.Add(this.lblNextWord);
            this.Controls.Add(this.gBAnswers);
            this.Controls.Add(this.gBSetup);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormAssociationTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Тренировка \"Последовательные ассоциации\"";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormAssociationTrain_KeyDown);
            this.gBWords.ResumeLayout(false);
            this.gBWords.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDQuestionCount)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gBTimeForWord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForWord)).EndInit();
            this.gBAnswers.ResumeLayout(false);
            this.gBSetup.ResumeLayout(false);
            this.gBOldTest.ResumeLayout(false);
            this.gBOldTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDOldTestWords)).EndInit();
            this.gBNumberSetup.ResumeLayout(false);
            this.gBNumberSetup.PerformLayout();
            this.gBDictionary.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.GroupBox gBWords;
        private System.Windows.Forms.CheckBox cBWordsRepeat;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.GroupBox gBTimeForWord;
        private System.Windows.Forms.CheckBox cBTimeForWord;
        private System.Windows.Forms.ToolStripStatusLabel tStStatusWords;
        private System.Windows.Forms.Label lblNextWord;
        private System.Windows.Forms.GroupBox gBAnswers;
        private System.Windows.Forms.ListBox listBoxTestWords;
        private System.Windows.Forms.CheckBox cBWithNumber;
        private System.Windows.Forms.GroupBox gBSetup;
        private System.Windows.Forms.NumericUpDown nUDQuestionCount;
        private System.Windows.Forms.NumericUpDown nUDTimeForWord;
        private System.Windows.Forms.GroupBox gBDictionary;
        private System.Windows.Forms.GroupBox gBNumberSetup;
        private System.Windows.Forms.CheckBox cBRandomPosition;
        private System.Windows.Forms.CheckBox cBCounter;
        private System.Windows.Forms.ToolStripStatusLabel tStStatusCounter;
        private System.Windows.Forms.GroupBox gBOldTest;
        private System.Windows.Forms.CheckBox cBWithoutOldTest;
        private System.Windows.Forms.NumericUpDown nUDOldTestWords;
        private System.Windows.Forms.ComboBox cBDictionary;
        private Controls.ToolStripStatusTimer tSSTotalTimer;
        private Controls.ToolStripStatusTimer tSSTestTimer;

    }
}

