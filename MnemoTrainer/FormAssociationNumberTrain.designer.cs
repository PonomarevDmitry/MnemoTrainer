namespace MnemoTrainer
{
    partial class FormAssociationNumberTrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAssociationNumberTrain));
            this.btnStartStop = new System.Windows.Forms.Button();
            this.gBNumberCount = new System.Windows.Forms.GroupBox();
            this.nUDNumberCount = new System.Windows.Forms.NumericUpDown();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tSSTotalTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.tStStatusCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSTestTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.gBTimeForNumber = new System.Windows.Forms.GroupBox();
            this.nUDTimeForNumber = new System.Windows.Forms.NumericUpDown();
            this.cBTimeForNumber = new System.Windows.Forms.CheckBox();
            this.lblNextWord = new System.Windows.Forms.Label();
            this.gBAnswers = new System.Windows.Forms.GroupBox();
            this.listBoxTestNumbers = new System.Windows.Forms.ListBox();
            this.gBSetup = new System.Windows.Forms.GroupBox();
            this.gBNets = new System.Windows.Forms.GroupBox();
            this.netCheckedListBox = new MnemoTrainer.Controls.NetCheckedListBox();
            this.gBNumberSetup = new System.Windows.Forms.GroupBox();
            this.cBRandomPosition = new System.Windows.Forms.CheckBox();
            this.cBWithNumber = new System.Windows.Forms.CheckBox();
            this.cBCounter = new System.Windows.Forms.CheckBox();
            this.gBNumberCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNumberCount)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.gBTimeForNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForNumber)).BeginInit();
            this.gBAnswers.SuspendLayout();
            this.gBSetup.SuspendLayout();
            this.gBNets.SuspendLayout();
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
            // gBNumberCount
            // 
            this.gBNumberCount.Controls.Add(this.nUDNumberCount);
            this.gBNumberCount.Location = new System.Drawing.Point(92, 19);
            this.gBNumberCount.Name = "gBNumberCount";
            this.gBNumberCount.Size = new System.Drawing.Size(70, 40);
            this.gBNumberCount.TabIndex = 1;
            this.gBNumberCount.TabStop = false;
            this.gBNumberCount.Text = "Цифр";
            // 
            // nUDNumberCount
            // 
            this.nUDNumberCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDNumberCount.Location = new System.Drawing.Point(3, 16);
            this.nUDNumberCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDNumberCount.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDNumberCount.Name = "nUDNumberCount";
            this.nUDNumberCount.Size = new System.Drawing.Size(64, 20);
            this.nUDNumberCount.TabIndex = 2;
            this.nUDNumberCount.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nUDNumberCount.ValueChanged += new System.EventHandler(this.nUDNumberCount_ValueChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            // gBTimeForNumber
            // 
            this.gBTimeForNumber.Controls.Add(this.nUDTimeForNumber);
            this.gBTimeForNumber.Controls.Add(this.cBTimeForNumber);
            this.gBTimeForNumber.Location = new System.Drawing.Point(168, 19);
            this.gBTimeForNumber.Name = "gBTimeForNumber";
            this.gBTimeForNumber.Size = new System.Drawing.Size(91, 40);
            this.gBTimeForNumber.TabIndex = 3;
            this.gBTimeForNumber.TabStop = false;
            this.gBTimeForNumber.Text = "На число";
            // 
            // nUDTimeForNumber
            // 
            this.nUDTimeForNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDTimeForNumber.Enabled = false;
            this.nUDTimeForNumber.Location = new System.Drawing.Point(21, 16);
            this.nUDTimeForNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nUDTimeForNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDTimeForNumber.Name = "nUDTimeForNumber";
            this.nUDTimeForNumber.ReadOnly = true;
            this.nUDTimeForNumber.Size = new System.Drawing.Size(67, 20);
            this.nUDTimeForNumber.TabIndex = 4;
            this.nUDTimeForNumber.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nUDTimeForNumber.ValueChanged += new System.EventHandler(this.nUDTimeForNumber_ValueChanged);
            // 
            // cBTimeForNumber
            // 
            this.cBTimeForNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBTimeForNumber.Location = new System.Drawing.Point(3, 16);
            this.cBTimeForNumber.Name = "cBTimeForNumber";
            this.cBTimeForNumber.Size = new System.Drawing.Size(18, 21);
            this.cBTimeForNumber.TabIndex = 0;
            this.cBTimeForNumber.UseVisualStyleBackColor = true;
            this.cBTimeForNumber.CheckedChanged += new System.EventHandler(this.cBTimeForNumber_CheckedChanged);
            // 
            // lblNextWord
            // 
            this.lblNextWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNextWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNextWord.ForeColor = System.Drawing.Color.Green;
            this.lblNextWord.Location = new System.Drawing.Point(0, 64);
            this.lblNextWord.Name = "lblNextWord";
            this.lblNextWord.Size = new System.Drawing.Size(785, 558);
            this.lblNextWord.TabIndex = 1;
            this.lblNextWord.Text = "Тест";
            this.lblNextWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNextWord.Visible = false;
            this.lblNextWord.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblNextWord_MouseClick);
            // 
            // gBAnswers
            // 
            this.gBAnswers.Controls.Add(this.listBoxTestNumbers);
            this.gBAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBAnswers.Location = new System.Drawing.Point(0, 64);
            this.gBAnswers.Name = "gBAnswers";
            this.gBAnswers.Size = new System.Drawing.Size(785, 558);
            this.gBAnswers.TabIndex = 7;
            this.gBAnswers.TabStop = false;
            this.gBAnswers.Visible = false;
            // 
            // listBoxTestNumbers
            // 
            this.listBoxTestNumbers.ColumnWidth = 150;
            this.listBoxTestNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTestNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxTestNumbers.HorizontalScrollbar = true;
            this.listBoxTestNumbers.ItemHeight = 18;
            this.listBoxTestNumbers.Location = new System.Drawing.Point(3, 16);
            this.listBoxTestNumbers.MultiColumn = true;
            this.listBoxTestNumbers.Name = "listBoxTestNumbers";
            this.listBoxTestNumbers.Size = new System.Drawing.Size(779, 539);
            this.listBoxTestNumbers.TabIndex = 1;
            // 
            // gBSetup
            // 
            this.gBSetup.Controls.Add(this.gBNets);
            this.gBSetup.Controls.Add(this.gBNumberSetup);
            this.gBSetup.Controls.Add(this.btnStartStop);
            this.gBSetup.Controls.Add(this.gBNumberCount);
            this.gBSetup.Controls.Add(this.gBTimeForNumber);
            this.gBSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBSetup.Location = new System.Drawing.Point(0, 0);
            this.gBSetup.Name = "gBSetup";
            this.gBSetup.Size = new System.Drawing.Size(785, 64);
            this.gBSetup.TabIndex = 2;
            this.gBSetup.TabStop = false;
            this.gBSetup.Text = "Настройки";
            // 
            // gBNets
            // 
            this.gBNets.Controls.Add(this.netCheckedListBox);
            this.gBNets.Location = new System.Drawing.Point(477, 19);
            this.gBNets.Name = "gBNets";
            this.gBNets.Size = new System.Drawing.Size(138, 40);
            this.gBNets.TabIndex = 7;
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
            this.netCheckedListBox.TabIndex = 1;
            this.netCheckedListBox.Text = "Не выбрана";
            this.netCheckedListBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gBNumberSetup
            // 
            this.gBNumberSetup.Controls.Add(this.cBRandomPosition);
            this.gBNumberSetup.Controls.Add(this.cBWithNumber);
            this.gBNumberSetup.Controls.Add(this.cBCounter);
            this.gBNumberSetup.Location = new System.Drawing.Point(265, 19);
            this.gBNumberSetup.Name = "gBNumberSetup";
            this.gBNumberSetup.Size = new System.Drawing.Size(206, 40);
            this.gBNumberSetup.TabIndex = 9;
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
            // FormAssociationNumberTrain
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
            this.Name = "FormAssociationNumberTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Тренировка \"Ассоциации чисел\"";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.gBNumberCount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDNumberCount)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gBTimeForNumber.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeForNumber)).EndInit();
            this.gBAnswers.ResumeLayout(false);
            this.gBSetup.ResumeLayout(false);
            this.gBNets.ResumeLayout(false);
            this.gBNumberSetup.ResumeLayout(false);
            this.gBNumberSetup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.GroupBox gBNumberCount;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.GroupBox gBTimeForNumber;
        private System.Windows.Forms.CheckBox cBTimeForNumber;
        private System.Windows.Forms.Label lblNextWord;
        private System.Windows.Forms.GroupBox gBAnswers;
        private System.Windows.Forms.ListBox listBoxTestNumbers;
        private System.Windows.Forms.NumericUpDown nUDNumberCount;
        private System.Windows.Forms.GroupBox gBSetup;
        private System.Windows.Forms.NumericUpDown nUDTimeForNumber;
        private System.Windows.Forms.GroupBox gBNumberSetup;
        private System.Windows.Forms.CheckBox cBRandomPosition;
        private System.Windows.Forms.CheckBox cBWithNumber;
        private System.Windows.Forms.CheckBox cBCounter;
        private System.Windows.Forms.ToolStripStatusLabel tStStatusCounter;
        private System.Windows.Forms.GroupBox gBNets;
        private Controls.NetCheckedListBox netCheckedListBox;
        private Controls.ToolStripStatusTimer tSSTotalTimer;
        private Controls.ToolStripStatusTimer tSSTestTimer;

    }
}

