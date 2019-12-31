namespace MnemoTrainer
{
    partial class FormTrainAssociationClosed
    {
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tStStatusWords;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripStatusLabel tStStatusCounter;
        private System.Windows.Forms.Label lblNextWord;
        private System.Windows.Forms.GroupBox gBAnswers;
        private System.Windows.Forms.ListBox listBoxTestWords;
        private System.Windows.Forms.GroupBox gBSetup;
        private System.Windows.Forms.GroupBox gBDictionary;
        private System.Windows.Forms.ComboBox cBDictionary;
        private System.Windows.Forms.GroupBox gBLists;
        private System.Windows.Forms.ComboBox cBList;
        private System.Windows.Forms.GroupBox gBNumberSetup;
        private System.Windows.Forms.CheckBox cBCounter;
        private System.Windows.Forms.GroupBox gBWords;
        private System.Windows.Forms.NumericUpDown nUDQuestionCount;
        private System.Windows.Forms.GroupBox gBTimeForWord;
        private System.Windows.Forms.NumericUpDown nUDTimeForWord;
        private System.Windows.Forms.CheckBox cBTimeForWord;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrainAssociationClosed));
            this.btnStartStop = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tStStatusWords = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSTotalTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.tStStatusCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSTestTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.lblNextWord = new System.Windows.Forms.Label();
            this.gBAnswers = new System.Windows.Forms.GroupBox();
            this.listBoxTestWords = new System.Windows.Forms.ListBox();
            this.gBSetup = new System.Windows.Forms.GroupBox();
            this.gBDictionary = new System.Windows.Forms.GroupBox();
            this.cBDictionary = new System.Windows.Forms.ComboBox();
            this.gBLists = new System.Windows.Forms.GroupBox();
            this.cBList = new System.Windows.Forms.ComboBox();
            this.gBNumberSetup = new System.Windows.Forms.GroupBox();
            this.cBCounter = new System.Windows.Forms.CheckBox();
            this.gBWords = new System.Windows.Forms.GroupBox();
            this.nUDQuestionCount = new System.Windows.Forms.NumericUpDown();
            this.gBTimeForWord = new System.Windows.Forms.GroupBox();
            this.nUDTimeForWord = new System.Windows.Forms.NumericUpDown();
            this.cBTimeForWord = new System.Windows.Forms.CheckBox();
            this.statusStrip.SuspendLayout();
            this.gBAnswers.SuspendLayout();
            this.gBSetup.SuspendLayout();
            this.gBDictionary.SuspendLayout();
            this.gBLists.SuspendLayout();
            this.gBNumberSetup.SuspendLayout();
            this.gBWords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDQuestionCount)).BeginInit();
            this.gBTimeForWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForWord)).BeginInit();
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
            // tSSTotalTimer
            // 
            this.tSSTotalTimer.Format = "Полное время: {0}.";
            this.tSSTotalTimer.Name = "tSSTotalTimer";
            this.tSSTotalTimer.Size = new System.Drawing.Size(0, 17);
            this.tSSTotalTimer.Type = MnemoTrainer.Controls.ToolStripStatusTimer.TimeStringType.Hours;
            // 
            // tStStatusCounter
            // 
            this.tStStatusCounter.Name = "tStStatusCounter";
            this.tStStatusCounter.Size = new System.Drawing.Size(0, 17);
            // 
            // tSSTestTimer
            // 
            this.tSSTestTimer.Format = "Время теста: {0} с.";
            this.tSSTestTimer.Name = "tSSTestTimer";
            this.tSSTestTimer.Size = new System.Drawing.Size(0, 17);
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
            // gBAnswers
            // 
            this.gBAnswers.Controls.Add(this.listBoxTestWords);
            this.gBAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBAnswers.Location = new System.Drawing.Point(0, 66);
            this.gBAnswers.Name = "gBAnswers";
            this.gBAnswers.Size = new System.Drawing.Size(785, 556);
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
            this.listBoxTestWords.Size = new System.Drawing.Size(779, 537);
            this.listBoxTestWords.TabIndex = 0;
            // 
            // gBSetup
            // 
            this.gBSetup.Controls.Add(this.gBDictionary);
            this.gBSetup.Controls.Add(this.gBLists);
            this.gBSetup.Controls.Add(this.gBNumberSetup);
            this.gBSetup.Controls.Add(this.gBWords);
            this.gBSetup.Controls.Add(this.gBTimeForWord);
            this.gBSetup.Controls.Add(this.btnStartStop);
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
            this.gBDictionary.Location = new System.Drawing.Point(502, 19);
            this.gBDictionary.Name = "gBDictionary";
            this.gBDictionary.Size = new System.Drawing.Size(135, 40);
            this.gBDictionary.TabIndex = 5;
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
            // gBLists
            // 
            this.gBLists.Controls.Add(this.cBList);
            this.gBLists.Location = new System.Drawing.Point(332, 19);
            this.gBLists.Name = "gBLists";
            this.gBLists.Size = new System.Drawing.Size(164, 40);
            this.gBLists.TabIndex = 4;
            this.gBLists.TabStop = false;
            this.gBLists.Text = "Списки";
            // 
            // cBList
            // 
            this.cBList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBList.FormattingEnabled = true;
            this.cBList.Location = new System.Drawing.Point(3, 16);
            this.cBList.Name = "cBList";
            this.cBList.Size = new System.Drawing.Size(158, 21);
            this.cBList.TabIndex = 0;
            // 
            // gBNumberSetup
            // 
            this.gBNumberSetup.Controls.Add(this.cBCounter);
            this.gBNumberSetup.Location = new System.Drawing.Point(250, 19);
            this.gBNumberSetup.Name = "gBNumberSetup";
            this.gBNumberSetup.Size = new System.Drawing.Size(76, 40);
            this.gBNumberSetup.TabIndex = 3;
            this.gBNumberSetup.TabStop = false;
            // 
            // cBCounter
            // 
            this.cBCounter.AutoSize = true;
            this.cBCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBCounter.Location = new System.Drawing.Point(3, 16);
            this.cBCounter.Name = "cBCounter";
            this.cBCounter.Size = new System.Drawing.Size(70, 21);
            this.cBCounter.TabIndex = 0;
            this.cBCounter.Text = "Счетчик";
            this.cBCounter.UseVisualStyleBackColor = true;
            // 
            // gBWords
            // 
            this.gBWords.Controls.Add(this.nUDQuestionCount);
            this.gBWords.Location = new System.Drawing.Point(87, 19);
            this.gBWords.Name = "gBWords";
            this.gBWords.Size = new System.Drawing.Size(65, 40);
            this.gBWords.TabIndex = 1;
            this.gBWords.TabStop = false;
            this.gBWords.Text = "Слов";
            // 
            // nUDQuestionCount
            // 
            this.nUDQuestionCount.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.nUDQuestionCount.Size = new System.Drawing.Size(59, 20);
            this.nUDQuestionCount.TabIndex = 1;
            this.nUDQuestionCount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nUDQuestionCount.ValueChanged += new System.EventHandler(this.nUDQuestionCount_ValueChanged);
            // 
            // gBTimeForWord
            // 
            this.gBTimeForWord.Controls.Add(this.nUDTimeForWord);
            this.gBTimeForWord.Controls.Add(this.cBTimeForWord);
            this.gBTimeForWord.Location = new System.Drawing.Point(158, 19);
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
            this.cBTimeForWord.CheckedChanged += new System.EventHandler(this.cBTimeForWord_CheckedChanged);
            // 
            // FormAssociationClosedTrain
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
            this.Name = "FormAssociationClosedTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Тренировка \"Закрытые ассоциации\"";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormClosedAssociationTrain_KeyDown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gBAnswers.ResumeLayout(false);
            this.gBSetup.ResumeLayout(false);
            this.gBDictionary.ResumeLayout(false);
            this.gBLists.ResumeLayout(false);
            this.gBNumberSetup.ResumeLayout(false);
            this.gBNumberSetup.PerformLayout();
            this.gBWords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDQuestionCount)).EndInit();
            this.gBTimeForWord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ToolStripStatusTimer tSSTotalTimer;
        private Controls.ToolStripStatusTimer tSSTestTimer;

    }
}

