using System;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using SAClasses;

namespace MnemoTrainer.Controls
{
    public partial class ControlPoemLine : UserControl
    {
        public PoemLine PoemLine { get; private set; }

        public ControlPoemLine()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.Selectable, true);

            //lblText.Text = string.Empty;
            //picBox.Image = null;
        }

        public ControlPoemLine(PoemLine line)
            : this()
        {
            this.PoemLine = line;

            this.lblText.Text = this.PoemLine.Line;

            LineIsStart lineStatus = line.LineStartStatus;

            int height = 0;

            if ((lineStatus & LineIsStart.OfBlock) != 0)
            {
                height = 50;
            }
            else if ((lineStatus & LineIsStart.OfBlockPart) != 0)
            {
                height = 40;
            }
            else if ((lineStatus & LineIsStart.OfPoem) != 0)
            {
                height = 30;
            }
            else if ((lineStatus & LineIsStart.OfPoemPart) != 0)
            {
                height = 20;
            }

            picBox.Image = Common.GetImageByLine(line);

            this.Padding = new Padding(0, height, 0, 0);
            this.Height += height;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.picBox.Width = picBox.Height;
        }
    }
}
