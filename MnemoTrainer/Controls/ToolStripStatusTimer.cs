using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MnemoTrainer.Controls
{
    [DefaultProperty("Interval")]
    public class ToolStripStatusTimer : ToolStripStatusLabel
    {
        public enum TimeStringType
        {
            Seconds,
            Hours
        }

        #region Свойства.

        private Timer timer;
        [Browsable(true), DefaultValue(100), Category("Behavior")]
        public int Interval
        {
            get { return this.timer.Interval; }
            set { this.timer.Interval = value; }
        }

        public bool IsTimerEnabled
        {
            get { return this.timer.Enabled; }
        }

        private DateTime? startTime = null;
        [Browsable(false)]
        public DateTime? StartTime
        {
            get { return this.startTime; }
        }

        private DateTime? stopTime = null;
        [Browsable(false)]
        public DateTime? StopTime
        {
            get { return this.stopTime; }
        }

        private string format = "Время: {0} с.";
        [Browsable(true), DefaultValue("Время: {0} с."), Category("Behavior")]
        public string Format
        {
            get { return this.format; }
            set { this.format = value; }
        }

        private TimeStringType type = TimeStringType.Seconds;
        [Browsable(true), DefaultValue(TimeStringType.Seconds), Category("Behavior")]
        public TimeStringType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        #endregion Свойства.

        #region Конструкторы и деструкторы.

        public ToolStripStatusTimer()
        {
            timer = new Timer();
            timer.Interval = 100;

            timer.Tick += new EventHandler(timer_Tick);
        }

        public ToolStripStatusTimer(IContainer container)
            : this()
        {
            container.Add(this);
        }

        ~ToolStripStatusTimer()
        {
            Dispose(false);
        }

        #endregion Конструкторы и деструкторы.

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.timer.Dispose();
            }

            base.Dispose(disposing);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan t = DateTime.Now - this.startTime.Value;
            SetTimerText(t);
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                
            }
        }

        #region Включение и выключение таймера.

        public void StartNew()
        {
            timer.Stop();

            SetTimerText(new TimeSpan());

            this.startTime = DateTime.Now;
            this.stopTime = null;

            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();

            if (this.startTime.HasValue)
            {
                this.stopTime = DateTime.Now;
                TimeSpan t = this.stopTime.Value - this.startTime.Value;
                SetTimerText(t);
            }
        }

        #endregion Включение и выключение таймера.

        public TimeSpan TimeInterval()
        {
            if (timer.Enabled)
            {
                return DateTime.Now - this.startTime.Value;
            }
            else if (this.startTime.HasValue && this.stopTime.HasValue)
            {
                return this.stopTime.Value - this.startTime.Value;
            }

            return new TimeSpan();
        }

        public void SetTimerText(TimeSpan span)
        {
            string timeString = string.Empty;
            if (this.type == TimeStringType.Seconds)
            {
                timeString = span.TotalSeconds.ToString("F1");
            }
            else
            {
                DateTime temp = new DateTime().Add(span);
                timeString = temp.ToLongTimeString();
            }

            base.Text = string.Format(this.format, timeString);
        }

        public void ClearTimerText()
        {
            base.Text = string.Empty;
        }
    }
}
