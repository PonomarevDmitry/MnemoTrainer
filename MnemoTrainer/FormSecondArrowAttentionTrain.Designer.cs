namespace MnemoTrainer
{
    partial class FormSecondArrowAttentionTrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSecondArrowAttentionTrain));
            this.clock = new Analog.Controls.Clock();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tSSTestTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // clock
            // 
            this.clock.Current = new System.DateTime(2011, 9, 14, 10, 31, 2, 80);
            this.clock.Dot = System.Drawing.Color.Red;
            this.clock.DotNeed = true;
            this.clock.Hour = System.Drawing.Color.Green;
            this.clock.LineWidth = 3F;
            this.clock.Location = new System.Drawing.Point(12, 12);
            this.clock.Minute = System.Drawing.Color.Blue;
            this.clock.Name = "clock";
            this.clock.Second = System.Drawing.Color.Red;
            this.clock.Shadow = System.Drawing.Color.DarkGray;
            this.clock.ShadowNeed = true;
            this.clock.Size = new System.Drawing.Size(679, 679);
            this.clock.Skin = Analog.Controls.Faces.Vista;
            this.clock.TabIndex = 0;
            this.clock.Visible = false;
            this.clock.Click += new System.EventHandler(this.clock_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSTestTimer});
            this.statusStrip.Location = new System.Drawing.Point(0, 700);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(706, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 16;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tSSTestTimer
            // 
            this.tSSTestTimer.Format = "Время теста: {0} с.";
            this.tSSTestTimer.Name = "tSSTestTimer";
            this.tSSTestTimer.Size = new System.Drawing.Size(0, 0);
            // 
            // FormSecondArrowAttentionTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 722);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.clock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormSecondArrowAttentionTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Тренировка Внимания - Секундная стрелка";
            this.Click += new System.EventHandler(this.clock_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSecondArrowAttentionTrain_KeyDown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Analog.Controls.Clock clock;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private Controls.ToolStripStatusTimer tSSTestTimer;

    }
}