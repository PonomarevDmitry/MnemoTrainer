using System.Windows.Controls;
using MnemoTrainer.Properties;
using SAClasses;

namespace MnemoTrainer.Classes
{
    internal static class Common
    {
        internal static System.Drawing.Image GetImageByLine(PoemLine line)
        {
            LineIsStart lineStatus = line.LineStartStatus;

            if ((lineStatus & LineIsStart.OfBlock) != 0)
            {
                return Resources.SABlock;
            }
            else if ((lineStatus & LineIsStart.OfBlockPart) != 0)
            {
                return Resources.SABlockPart;
            }
            else if ((lineStatus & LineIsStart.OfPoem) != 0)
            {
                return Resources.Poem;
            }
            else if ((lineStatus & LineIsStart.OfPoemPart) != 0)
            {
                return Resources.PoemPart;
            }

            return null;
        }

        public static void SetLabelText(Label label, float baseFontSize, string text)
        {
            //Font font = new Font(label.FontFamily, baseFontSize, label.FontStyle);

            //Graphics grfx = label.
            //SizeF sizef = grfx.MeasureString(text, font);
            //grfx.Dispose();

            //if (sizef.Width > label.Width || sizef.Height > label.Height)
            //{
            //    float fScale = Math.Min(label.Width / sizef.Width, label.Height / sizef.Height);
            //    font = new Font(font.Name, fScale * font.SizeInPoints, label.Font.Style);
            //}

            label.Content = text;
            //label.FontSize =;
        }
    }
}
