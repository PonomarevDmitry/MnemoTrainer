using System.Collections.ObjectModel;
using System.Drawing;

namespace MnemoTrainerLibrary.Classes
{
    public class ColorTest
    {
        public Color Color { get; set; }
        public string Text { get; set; }

        public ColorTest(Color color, string text)
        {
            this.Text = text;
            this.Color = color;
        }

        public override string ToString()
        {
            return this.Text + " - " + this.Color.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            ColorTest ct = obj as ColorTest;

            return this.Text == ct.Text && this.Color == ct.Color;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Collection<ColorTest> colorCollection = new Collection<ColorTest>() 
        { new ColorTest(Color.Red, "Красный"),
          new ColorTest(Color.Orange, "Оранжевый"),
          new ColorTest(Color.Yellow, "Желтый"),
          new ColorTest(Color.Green, "Зеленый"),
          new ColorTest(Color.DeepSkyBlue, "Голубой"),
          new ColorTest(Color.Blue, "Синий"),
          new ColorTest(Color.Purple, "Фиолетовый"), 
          new ColorTest(Color.Black, "Черный"), 
          new ColorTest(Color.White, "Белый"), 
          new ColorTest(Color.Gray, "Серый"), 
          new ColorTest(Color.HotPink, "Розовый"),
          new ColorTest(Color.Brown, "Коричневый")
        };
    }
}
