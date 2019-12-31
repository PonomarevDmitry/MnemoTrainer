using System;
using System.Collections.ObjectModel;
using System.Text;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.QuestionGenerator
{
    public class QuestionGeneratorRecentMemory
    {
        #region Внутренние поля.

        Random rnd = new Random();

        private string charCollection = "0123456789АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЫЭЮЯ";

        private const int standartRepeatCount = 70;
        private Collection<string> lastQuestions = new Collection<string>();

        #endregion Внутренние поля.

        public string[] QuestionCollection { get; private set; }
        public string QuestionText
        {
            get
            {
                StringBuilder result = new StringBuilder();

                foreach (string item in QuestionCollection)
                {
                    result.Append(item);
                }

                return result.ToString();
            }
        }

        public TrainTypeStepanovAndRecentMemory TestType { get; set; }

        private int symbolsCount = 6;
        public int SymbolsCount
        {
            get { return this.symbolsCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("SymbolsCount");
                }

                this.symbolsCount = value;
            }
        }

        public QuestionGeneratorRecentMemory()
        {
            this.TestType = TrainTypeStepanovAndRecentMemory.None;
        }

        #region Генерация нового вопроса.

        public void CreateNewQuestion()
        {
            int length = 10;
            if (this.TestType == TrainTypeStepanovAndRecentMemory.NumbersAndSymbols)
            {
                length = charCollection.Length;
            }

            StringBuilder strBuilder;

            do
            {
                strBuilder = new StringBuilder();

                for (int i = 0; i < this.symbolsCount; i++)
                {
                    strBuilder.Append(charCollection[rnd.Next(length)]);
                }

            } while (QuestionIsRepeat(strBuilder.ToString()));

            string temp = strBuilder.ToString();

            this.QuestionCollection = new string[temp.Length];

            for (int index = 0; index < temp.Length; index++)
            {
                this.QuestionCollection[index] = temp[index].ToString();
            }
        }

        #region Проверка повторов вопросов.

        private bool QuestionIsRepeat(string text)
        {
            if (lastQuestions.Contains(text)) return true;

            // Не должно быть повторов в 3 символа.
            int repeatCount = 0;
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i - 1] == text[i])
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

            lastQuestions.Add(text);

            while (lastQuestions.Count > standartRepeatCount)
            {
                lastQuestions.RemoveAt(0);
            }

            return false;
        }

        #endregion Проверка повторов вопросов.

        #endregion Генерация нового вопроса.

        public void Clear()
        {
            lastQuestions.Clear();
        }

        public void CheckAnswer(string userAnswer, out bool isAnswerRight, out string answerText, out string userAnswerText)
        {
            isAnswerRight = CompareAnswers(this.QuestionText, userAnswer);

            userAnswerText = userAnswer;
            answerText = Common.FillSpaces(this.QuestionText);

            if (!isAnswerRight)
            {
                answerText += !string.IsNullOrEmpty(userAnswer) ? ("\r\n" + Common.FillSpaces(userAnswer)) : string.Empty;

            }
        }

        private bool CompareAnswers(string rightAnswer, string answer)
        {
            string temp1 = rightAnswer.Replace(" ", string.Empty);
            string temp2 = answer.Replace(" ", string.Empty);

            return string.Compare(temp1, temp2, true) == 0;
        }
    }
}
