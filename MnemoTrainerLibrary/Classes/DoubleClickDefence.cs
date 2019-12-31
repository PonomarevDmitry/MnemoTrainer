using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MnemoTrainerLibrary.Classes
{
    public class DoubleClickDefence
    {
        private Timer lockTimer;
        public int Interval
        {
            get { return this.lockTimer.Interval; }
            set { this.lockTimer.Interval = value; }
        }

        public DoubleClickDefence(IContainer container)
        {
            lockTimer = new Timer(container);
            lockTimer.Interval = 200;

            lockTimer.Tick += new EventHandler(lockTimer_Tick);
        }

        private void lockTimer_Tick(object sender, EventArgs e)
        {
            lockTimer.Enabled = false;
            lockTimer.Stop();
        }

        public bool IsUnlocked()
        {
            return !lockTimer.Enabled;
        }

        public void StartLock()
        {
            lockTimer.Start();
        }
    }
}
