using System;
using System.Collections.ObjectModel;
using System.Text;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.QuestionGenerator
{
    public class QuestionGeneratorStepanov
    {
        #region Внутренние поля.

        Random rnd = new Random();

        private const string charCollection = "0123456789АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЫЭЮЯ";

        private const string questionFormat = "{0}\r\n{1}";
        private const int questionFormatSpaceCount = 3;

        private readonly string questionFormatWithUserAnswer;

        private const int standartRepeatCount2 = 70;
        private const int standartRepeatCount3 = 500;
        private Collection<string> lastQuestions2 = new Collection<string>();
        private Collection<string> lastQuestions3 = new Collection<string>();

        #endregion Внутренние поля.

        private string questionText = string.Empty;
        public string QuestionText
        {
            get { return this.questionText; }
        }

        private string answerText = string.Empty;
        public string AnswerText
        {
            get { return this.answerText; }
        }

        private string[] questionPart = new string[2];

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

        public QuestionGeneratorStepanov()
        {
            questionFormatWithUserAnswer = "{0}" + new string(' ', questionFormatSpaceCount) + "{2}\r\n{1}" + new string(' ', questionFormatSpaceCount) + "{3}";
        }

        #region Генерация нового вопроса.

        public void CreateNewQuestion()
        {
            questionPart[0] = string.Empty;
            questionPart[1] = string.Empty;

            int length = 10;
            if (this.TestType == TrainTypeStepanovAndRecentMemory.NumbersAndSymbols)
            {
                length = charCollection.Length;
            }

            do
            {
                for (int j = 0; j < 2; j++)
                {
                    StringBuilder strBuilder = new StringBuilder();

                    for (int i = 0; i < this.symbolsCount; i++)
                    {
                        strBuilder.Append(charCollection[rnd.Next(length)]);
                    }

                    questionPart[j] = strBuilder.ToString();
                }

            } while (QuestionIsRepeat(questionPart[0], questionPart[1]));

            this.questionText = string.Format(questionFormat, Common.FillSpaces(questionPart[0]), Common.FillSpaces(questionPart[1]));

            this.answerText = questionPart[0] + questionPart[1];
        }

        #region Проверка повторов вопросов.

        private bool QuestionIsRepeat(string text1, string text2)
        {
            if (text1 == text2) return true;

            Collection<string> coll1 = GeneraneNumberCollection(text1);
            Collection<string> coll2 = GeneraneNumberCollection(text2);

            for (int i = 0; i < coll1.Count; i++)
            {
                if (coll2.Contains(coll1[i]) || coll1.Contains(coll2[i]))
                {
                    return true;
                }

                if (coll1[i].Length == 2)
                {
                    if (lastQuestions2.Contains(coll1[i]))
                    {
                        return true;
                    }
                }
                else
                {
                    if (lastQuestions3.Contains(coll1[i]))
                    {
                        return true;
                    }
                }

                if (coll2[i].Length == 2)
                {
                    if (lastQuestions2.Contains(coll2[i]))
                    {
                        return true;
                    }
                }
                else
                {
                    if (lastQuestions3.Contains(coll2[i]))
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < coll1.Count; i++)
            {
                if (coll1[i].Length == 2)
                {
                    lastQuestions2.Add(coll1[i]);
                }
                else
                {
                    lastQuestions3.Add(coll1[i]);
                }

                if (coll2[i].Length == 2)
                {
                    lastQuestions2.Add(coll2[i]);
                }
                else
                {
                    lastQuestions3.Add(coll2[i]);
                }
            }

            while (lastQuestions3.Count > standartRepeatCount3)
            {
                lastQuestions3.RemoveAt(0);
            }

            while (lastQuestions2.Count > standartRepeatCount2)
            {
                lastQuestions2.RemoveAt(0);
            }

            return false;
        }

        private Collection<string> GeneraneNumberCollection(string text1)
        {
            Collection<string> result = new Collection<string>();

            int length = text1.Length % 3;
            if (length == 1)
            {
                result.Add(text1.Substring(0, 2));
                text1 = text1.Substring(2);

                result.Add(text1.Substring(0, 2));
                text1 = text1.Substring(2);
            }
            else if (length == 2)
            {
                result.Add(text1.Substring(0, 2));
                text1 = text1.Substring(2);
            }

            while (text1 != string.Empty)
            {
                result.Add(text1.Substring(0, 3));
                text1 = text1.Substring(3);
            }

            return result;
        }

        #endregion Проверка повторов вопросов.

        #endregion Генерация нового вопроса.

        public void Clear()
        {
            lastQuestions2.Clear();
            lastQuestions3.Clear();
        }

        public void CheckAnswer(string userAnswer, out bool isAnswerRight, out string answerText, out string userAnswerText)
        {
            isAnswerRight = CompareAnswers(this.answerText, userAnswer);

            userAnswerText = userAnswer;

            answerText = string.Empty;

            if (isAnswerRight)
            {
                answerText = this.questionText;
            }
            else
            {
                answerText = GenerateCheckingText(userAnswer);
            }
        }

        private bool CompareAnswers(string rightAnswer, string answer)
        {
            return string.Compare(rightAnswer, answer, true) == 0;
        }

        private string GenerateCheckingText(string userAnswer)
        {
            if (!string.IsNullOrEmpty(userAnswer))
            {
                string text = userAnswer.PadRight(symbolsCount * 2, '_');

                string userAnswerPart1 = text.Substring(0, symbolsCount);
                string userAnswerPart2 = text.Substring(symbolsCount);

                return string.Format(questionFormatWithUserAnswer, Common.FillSpaces(questionPart[0]), Common.FillSpaces(questionPart[1]), Common.FillSpaces(userAnswerPart1), Common.FillSpaces(userAnswerPart2));
            }
            else
            {
                return string.Format(questionFormat, Common.FillSpaces(questionPart[0]), Common.FillSpaces(questionPart[1]));
            }
        }
    }
}
