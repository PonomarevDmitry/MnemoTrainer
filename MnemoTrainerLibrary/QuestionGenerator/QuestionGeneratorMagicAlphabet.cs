using System;
using System.Collections.ObjectModel;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.QuestionGenerator
{
    public class QuestionGeneratorMagicAlphabet
    {
        Random rnd = new Random();

        public Order TestOrder { get; set; }

        public QuestionGeneratorMagicAlphabet()
        {
            this.TestOrder = Order.Normal;
        }

        #region Формирование вопросов.

        public Collection<MagicLetter> GenerateAlphabet()
        {
            Collection<MagicLetter> questionCollection = new Collection<MagicLetter>();

            string charCollection = "АБВГДЕЁЖЗИКЛМНОПРСТУФХЦЧШЩЫЭЮЯ";

            do
            {
                Collection<int> numbers = new Collection<int>();
                for (int i = 0; i < 30; i++)
                {
                    numbers.Add(i);
                }

                Collection<int> colL = new Collection<int>();
                Collection<int> colR = new Collection<int>();
                Collection<int> colO = new Collection<int>();

                // Л - 12, О - 15, П - 16
                numbers.Remove(charCollection.IndexOf('Л'));
                numbers.Remove(charCollection.IndexOf('О'));
                numbers.Remove(charCollection.IndexOf('П'));

                colR.Add(charCollection.IndexOf('Л'));
                colO.Add(charCollection.IndexOf('О'));
                colL.Add(charCollection.IndexOf('П'));

                int temp;
                for (int i = 0; i < 9; i++)
                {
                    temp = rnd.Next(numbers.Count);
                    colL.Add(numbers[temp]);
                    numbers.RemoveAt(temp);

                    temp = rnd.Next(numbers.Count);
                    colR.Add(numbers[temp]);
                    numbers.RemoveAt(temp);

                    temp = rnd.Next(numbers.Count);
                    colO.Add(numbers[temp]);
                    numbers.RemoveAt(temp);
                }

                Collection<MagicLetter> newAlphabel = new Collection<MagicLetter>();

                for (int i = 0; i < 30; i++)
                {
                    string handLitera = string.Empty;

                    if (colL.Contains(i))
                    {
                        handLitera = "Л";
                    }
                    else if (colR.Contains(i))
                    {
                        handLitera = "П";
                    }
                    else if (colO.Contains(i))
                    {
                        handLitera = "О";
                    }

                    MagicLetter newLetter = new MagicLetter(charCollection[i].ToString(), handLitera);

                    newAlphabel.Add(newLetter);
                }

                questionCollection.Clear();

                if (this.TestOrder == Order.Normal)
                {
                    for (int i = 0; i < newAlphabel.Count; i++)
                    {
                        questionCollection.Add(newAlphabel[i]);
                    }
                }
                else if (this.TestOrder == Order.Inverse)
                {
                    for (int i = newAlphabel.Count - 1; i >= 0; i--)
                    {
                        questionCollection.Add(newAlphabel[i]);
                    }
                }
                else if (this.TestOrder == Order.Random)
                {
                    while (newAlphabel.Count > 0)
                    {
                        int index = rnd.Next(newAlphabel.Count);

                        questionCollection.Add(newAlphabel[index]);
                        newAlphabel.RemoveAt(index);
                    }
                }

            } while (CheckQuestionCollection(questionCollection));

            return questionCollection;
        }

        private bool CheckQuestionCollection(Collection<MagicLetter> questionCollection)
        {
            int repeatCount = 0;

            // Нет тройных повторов.
            for (int i = 1; i < questionCollection.Count; i++)
            {
                if (questionCollection[i - 1].Hand == questionCollection[i].Hand)
                {
                    repeatCount++;
                }
                else
                {
                    repeatCount = 0;
                }

                if (repeatCount == 2)
                {
                    return true;
                }
            }

            repeatCount = 0;
            for (int i = 1; i < questionCollection.Count; i++)
            {
                if (questionCollection[i - 1].Hand == questionCollection[i].Hand)
                {
                    repeatCount++;
                }
            }

            // Не более трех двойных повторов.
            if (repeatCount > 3)
            {
                return true;
            }

            return false;
        }

        #endregion Формирование вопросов.
    }
}
