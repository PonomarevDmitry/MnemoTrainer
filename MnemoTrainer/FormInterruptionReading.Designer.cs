namespace MnemoTrainer
{
    partial class FormInterruptionReading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInterruptionReading));
            this.gBInterruption = new System.Windows.Forms.GroupBox();
            this.gBTimePass = new System.Windows.Forms.GroupBox();
            this.lblTimePass = new System.Windows.Forms.Label();
            this.gBTimeRemain = new System.Windows.Forms.GroupBox();
            this.lblTimeRemain = new System.Windows.Forms.Label();
            this.lblProc = new System.Windows.Forms.Label();
            this.gBTimers = new System.Windows.Forms.GroupBox();
            this.dTPInerruptionTime1 = new System.Windows.Forms.DateTimePicker();
            this.dTPInerruptionTime2 = new System.Windows.Forms.DateTimePicker();
            this.cbTimer = new System.Windows.Forms.ComboBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lblBook = new System.Windows.Forms.Label();
            this.nIReading = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.timerBookTime = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.chBWithInterruption = new System.Windows.Forms.CheckBox();
            this.tSSTotalTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.gBInterruption.SuspendLayout();
            this.gBTimePass.SuspendLayout();
            this.gBTimeRemain.SuspendLayout();
            this.gBTimers.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBInterruption
            // 
            this.gBInterruption.Controls.Add(this.chBWithInterruption);
            this.gBInterruption.Controls.Add(this.gBTimePass);
            this.gBInterruption.Controls.Add(this.gBTimeRemain);
            this.gBInterruption.Controls.Add(this.lblProc);
            this.gBInterruption.Controls.Add(this.gBTimers);
            this.gBInterruption.Controls.Add(this.btnStartStop);
            this.gBInterruption.Controls.Add(this.lblBook);
            this.gBInterruption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBInterruption.Location = new System.Drawing.Point(0, 0);
            this.gBInterruption.Name = "gBInterruption";
            this.gBInterruption.Size = new System.Drawing.Size(178, 221);
            this.gBInterruption.TabIndex = 0;
            this.gBInterruption.TabStop = false;
            this.gBInterruption.Text = "Период чтения";
            // 
            // gBTimePass
            // 
            this.gBTimePass.Controls.Add(this.lblTimePass);
            this.gBTimePass.Location = new System.Drawing.Point(6, 179);
            this.gBTimePass.Name = "gBTimePass";
            this.gBTimePass.Size = new System.Drawing.Size(73, 35);
            this.gBTimePass.TabIndex = 9;
            this.gBTimePass.TabStop = false;
            this.gBTimePass.Text = "Прошло";
            // 
            // lblTimePass
            // 
            this.lblTimePass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimePass.Location = new System.Drawing.Point(3, 16);
            this.lblTimePass.Name = "lblTimePass";
            this.lblTimePass.Size = new System.Drawing.Size(67, 16);
            this.lblTimePass.TabIndex = 5;
            this.lblTimePass.Text = "0:00,0";
            this.lblTimePass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gBTimeRemain
            // 
            this.gBTimeRemain.Controls.Add(this.lblTimeRemain);
            this.gBTimeRemain.Location = new System.Drawing.Point(99, 179);
            this.gBTimeRemain.Name = "gBTimeRemain";
            this.gBTimeRemain.Size = new System.Drawing.Size(73, 35);
            this.gBTimeRemain.TabIndex = 8;
            this.gBTimeRemain.TabStop = false;
            this.gBTimeRemain.Text = "Осталось";
            // 
            // lblTimeRemain
            // 
            this.lblTimeRemain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimeRemain.Location = new System.Drawing.Point(3, 16);
            this.lblTimeRemain.Name = "lblTimeRemain";
            this.lblTimeRemain.Size = new System.Drawing.Size(67, 16);
            this.lblTimeRemain.TabIndex = 5;
            this.lblTimeRemain.Text = "0:00,0";
            this.lblTimeRemain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProc
            // 
            this.lblProc.Location = new System.Drawing.Point(139, 159);
            this.lblProc.Name = "lblProc";
            this.lblProc.Size = new System.Drawing.Size(33, 13);
            this.lblProc.TabIndex = 6;
            this.lblProc.Text = "100%";
            this.lblProc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gBTimers
            // 
            this.gBTimers.Controls.Add(this.dTPInerruptionTime1);
            this.gBTimers.Controls.Add(this.dTPInerruptionTime2);
            this.gBTimers.Controls.Add(this.cbTimer);
            this.gBTimers.Location = new System.Drawing.Point(6, 73);
            this.gBTimers.Name = "gBTimers";
            this.gBTimers.Size = new System.Drawing.Size(166, 75);
            this.gBTimers.TabIndex = 2;
            this.gBTimers.TabStop = false;
            this.gBTimers.Text = "Таймеры";
            // 
            // dTPInerruptionTime1
            // 
            this.dTPInerruptionTime1.CustomFormat = "    mm:ss";
            this.dTPInerruptionTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPInerruptionTime1.Location = new System.Drawing.Point(6, 46);
            this.dTPInerruptionTime1.Name = "dTPInerruptionTime1";
            this.dTPInerruptionTime1.ShowUpDown = true;
            this.dTPInerruptionTime1.Size = new System.Drawing.Size(70, 20);
            this.dTPInerruptionTime1.TabIndex = 2;
            this.dTPInerruptionTime1.Tag = "1";
            this.dTPInerruptionTime1.Value = new System.DateTime(2011, 11, 16, 0, 1, 30, 0);
            this.dTPInerruptionTime1.ValueChanged += new System.EventHandler(this.dTPInerruptionTime1_ValueChanged);
            // 
            // dTPInerruptionTime2
            // 
            this.dTPInerruptionTime2.CustomFormat = "    mm:ss";
            this.dTPInerruptionTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPInerruptionTime2.Location = new System.Drawing.Point(90, 46);
            this.dTPInerruptionTime2.Name = "dTPInerruptionTime2";
            this.dTPInerruptionTime2.ShowUpDown = true;
            this.dTPInerruptionTime2.Size = new System.Drawing.Size(70, 20);
            this.dTPInerruptionTime2.TabIndex = 3;
            this.dTPInerruptionTime2.Tag = "2";
            this.dTPInerruptionTime2.Value = new System.DateTime(2011, 11, 16, 0, 4, 0, 0);
            this.dTPInerruptionTime2.ValueChanged += new System.EventHandler(this.dTPInerruptionTime2_ValueChanged);
            // 
            // cbTimer
            // 
            this.cbTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimer.FormattingEnabled = true;
            this.cbTimer.Location = new System.Drawing.Point(6, 19);
            this.cbTimer.Name = "cbTimer";
            this.cbTimer.Size = new System.Drawing.Size(100, 21);
            this.cbTimer.TabIndex = 1;
            this.cbTimer.SelectedIndexChanged += new System.EventHandler(this.cbTimer_SelectedIndexChanged);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(6, 19);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(100, 25);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Начать";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Location = new System.Drawing.Point(6, 159);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(88, 13);
            this.lblBook.TabIndex = 4;
            this.lblBook.Text = "Книга 1  -  03:00";
            // 
            // nIReading
            // 
            this.nIReading.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nIReading.Icon = ((System.Drawing.Icon)(resources.GetObject("nIReading.Icon")));
            this.nIReading.Text = "Чтение с прерыванием";
            this.nIReading.Click += new System.EventHandler(this.nIReading_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSTotalTimer});
            this.statusStrip.Location = new System.Drawing.Point(0, 244);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(178, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // timerBookTime
            // 
            this.timerBookTime.Interval = 10;
            this.timerBookTime.Tick += new System.EventHandler(this.timerBookTime_Tick);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 221);
            this.progressBar.Maximum = 10000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(178, 23);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 7;
            // 
            // chBWithInterruption
            // 
            this.chBWithInterruption.AutoSize = true;
            this.chBWithInterruption.Location = new System.Drawing.Point(6, 50);
            this.chBWithInterruption.Name = "chBWithInterruption";
            this.chBWithInterruption.Size = new System.Drawing.Size(106, 17);
            this.chBWithInterruption.TabIndex = 10;
            this.chBWithInterruption.Text = "С прерыванием";
            this.chBWithInterruption.UseVisualStyleBackColor = true;
            this.chBWithInterruption.CheckedChanged += new System.EventHandler(this.chBWithInterruption_CheckedChanged);
            // 
            // tSSTotalTimer
            // 
            this.tSSTotalTimer.Format = "Время: {0}.";
            this.tSSTotalTimer.Name = "tSSTotalTimer";
            this.tSSTotalTimer.Size = new System.Drawing.Size(0, 0);
            this.tSSTotalTimer.Type = MnemoTrainer.Controls.ToolStripStatusTimer.TimeStringType.Hours;
            // 
            // FormInterruptionReading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 266);
            this.Controls.Add(this.gBInterruption);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormInterruptionReading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Чтение";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormInterruptionReading_KeyDown);
            this.gBInterruption.ResumeLayout(false);
            this.gBInterruption.PerformLayout();
            this.gBTimePass.ResumeLayout(false);
            this.gBTimeRemain.ResumeLayout(false);
            this.gBTimers.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBInterruption;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.NotifyIcon nIReading;
        private System.Windows.Forms.DateTimePicker dTPInerruptionTime1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Timer timerBookTime;
        private System.Windows.Forms.GroupBox gBTimers;
        private System.Windows.Forms.DateTimePicker dTPInerruptionTime2;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.Label lblTimeRemain;
        private System.Windows.Forms.ComboBox cbTimer;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProc;
        private System.Windows.Forms.GroupBox gBTimeRemain;
        private System.Windows.Forms.GroupBox gBTimePass;
        private System.Windows.Forms.Label lblTimePass;
        private Controls.ToolStripStatusTimer tSSTotalTimer;
        private System.Windows.Forms.CheckBox chBWithInterruption;
    }
}