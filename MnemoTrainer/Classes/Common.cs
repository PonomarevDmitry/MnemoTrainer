using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MnemoTrainer.Properties;
using SAClasses;

namespace MnemoTrainer.Classes
{
    internal static class Common
    {
        internal static Image GetImageByLine(PoemLine line)
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
            Font font = new Font(label.Font.FontFamily, baseFontSize, label.Font.Style);

            Graphics grfx = label.CreateGraphics();
            SizeF sizef = grfx.MeasureString(text, font);
            grfx.Dispose();

            if (sizef.Width > label.Width || sizef.Height > label.Height)
            {
                float fScale = Math.Min(label.Width / sizef.Width, label.Height / sizef.Height);
                font = new Font(font.Name, fScale * font.SizeInPoints, label.Font.Style);
            }

            label.Text = text;
            label.Font = font;
        }

        #region Обработчики для TextBox.

        internal static void SetTextBoxOnlyNumbers(params TextBox[] boxes)
        {
            foreach (TextBox textBox in boxes)
            {
                textBox.TextChanged += new EventHandler(textBoxOnlyNumbers_TextChanged);
                textBox.KeyPress += new KeyPressEventHandler(textBoxOnlyNumbers_KeyPress);
            }
        }

        private static void textBoxOnlyNumbers_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            string tempString = Regex.Replace(textBox.Text, @"[^0-9]", string.Empty);

            if (tempString != textBox.Text)
            {
                int selected = textBox.SelectionStart;

                textBox.Text = tempString;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private static void textBoxOnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                return;
            }

            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion Обработчики для TextBox.
    }
}
