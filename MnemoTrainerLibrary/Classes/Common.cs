using System;
using System.Collections.ObjectModel;
using System.Text;

namespace MnemoTrainerLibrary.Classes
{
    internal static class Common
    {
        public static string FillSpaces(string text)
        {
            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                strBuilder.Append(text[i]);

                if (i != text.Length - 1)
                {
                    strBuilder.Append(" ");
                }
            }

            return strBuilder.ToString();
        }

        public static string ConfuseSymbols(string text)
        {
            if (text.Length > 4)
            {
                Collection<char> charCollection = new Collection<char>();

                for (int i = 1; i < text.Length - 1; i++)
                {
                    charCollection.Add(char.ToLower(text[i]));
                }

                Random rnd = new Random();

                StringBuilder result = new StringBuilder();

                result.Append(char.ToUpper(text[0]));

                while (charCollection.Count > 0)
                {
                    int nextInt = rnd.Next(charCollection.Count);

                    result.Append(charCollection[nextInt]);

                    charCollection.RemoveAt(nextInt);
                }

                result.Append(char.ToLower(text[text.Length - 1]));

                return result.ToString();
            }
            else
            {
                return text;
            }
        }
    }
}
