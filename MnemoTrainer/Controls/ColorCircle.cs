using System;
using System.Drawing;
using System.Windows.Forms;

namespace MnemoTrainer.Controls
{
    public class ColorCircle : Control
    {
        private Brush brush;

        private Color circleColor;
        public Color CircleColor
        {
            get { return this.circleColor; }
            set
            {
                this.circleColor = value;
                brush = new SolidBrush(circleColor);

                this.Invalidate();
            }
        }

        private bool showCircle = false;
        public bool ShowCircle
        {
            get { return this.showCircle; }
            set
            {
                this.showCircle = value;
                this.Invalidate();
            }
        }

        public ColorCircle()
        {
            this.ResizeRedraw = true;

            circleColor = this.ForeColor;

            brush = new SolidBrush(circleColor);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.showCircle)
            {
                Rectangle rect = this.DisplayRectangle;

                int length = Math.Min(rect.Width, rect.Height);

                e.Graphics.FillEllipse(this.brush, (rect.Width - length) / 2, (rect.Height - length) / 2, length, length);
            }
            else
            {
                Rectangle rect = this.DisplayRectangle;

                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), rect.Width / 2, rect.Height / 2, format);
            }
        }
    }
}
