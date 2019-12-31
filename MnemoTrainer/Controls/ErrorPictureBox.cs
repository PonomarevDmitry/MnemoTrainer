using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MnemoTrainer.Controls
{
    [DefaultEvent("EndShowing")]
    public partial class ErrorPictureBox : UserControl
    {
        #region Свойства.

        [Browsable(true), Category("Behavior"), DefaultValue(800)]
        public int Interval
        {
            get { return this.timer.Interval; }
            set { this.timer.Interval = value; }
        }

        #endregion Свойства.

        #region События.

        //public event EventHandler BeginShowing;
        //public event EventHandler EndShowing;

        //protected void OnBeginShowing(EventArgs args)
        //{
        //    if (BeginShowing != null)
        //    {
        //        BeginShowing(this, args);
        //    }
        //}

        //protected void OnEndShowing(EventArgs args)
        //{
        //    if (EndShowing != null)
        //    {
        //        EndShowing(this, args);
        //    }
        //}

        #endregion События.

        #region Конструкторы.

        public ErrorPictureBox()
        {
            InitializeComponent();

            pictureBox.Image = SystemIcons.Error.ToBitmap();

            this.TabStop = false;
        }

        public ErrorPictureBox(IContainer container)
            : this()
        {
            container.Add(this);
        }

        #endregion Конструкторы.

        public void StartShowing()
        {
            pictureBox.Visible = true;

            //OnBeginShowing(new EventArgs());

            timer.Start();
        }

        public void StopShowing()
        {
            if (timer.Enabled)
            {
                timer.Stop();
                pictureBox.Visible = false;

                //OnEndShowing(new EventArgs());
            }
        }

        private void timerError_Tick(object sender, EventArgs e)
        {
            this.StopShowing();
        }
    }
}
