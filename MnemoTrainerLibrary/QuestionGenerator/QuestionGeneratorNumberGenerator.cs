using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.QuestionGenerator
{
    public class QuestionGeneratorNumberGenerator
    {
        #region Внутренние поля.

        Random rnd = new Random();

        public static readonly int MaxNetLength;

        private const int standartRepeatCount = 60;

        private Collection<AssociationQuestionPart> lastQuestions = new Collection<AssociationQuestionPart>();

        #endregion Внутренние поля.

        private string questionText = string.Empty;
        public string QuestionText
        {
            get { return this.questionText; }
        }

        private string answerValue = string.Empty;
        public string AnswerValue
        {
            get { return this.answerValue; }
        }

        private int RepeatCount
        {
            get
            {
                if (this.IsRangeEnabled)
                {
                    int numbersCount = this.maxNumber - this.minNumber + 1;
                    int patternCount = this.symbolsCount / 2;

                    if (numbersCount - patternCount > 0)
                    {
                        return (numbersCount - patternCount) * standartRepeatCount / 100;
                    }
                    else
                    {
                        return 0;
                    }
                }

                return standartRepeatCount;
            }
        }

        #region Свойства.

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

        #region Диапазон значений.

        public virtual bool IsRangeEnabled { get; set; }

        private int minNumber = 0;
        public int MinNumber
        {
            get { return this.minNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MinNumber");
                }

                this.minNumber = value;
            }
        }

        private int maxNumber = 99;
        public int MaxNumber
        {
            get { return this.maxNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MaxNumber");
                }

                this.maxNumber = value;
            }
        }

        #endregion Диапазон значений.

        #region Сетки.

        private bool[] SourceCheckState;

        public static ReadOnlyCollection<Net> SourceNets { get; private set; }

        public void SetCheckState(int index, bool state)
        {
            SourceCheckState[index] = state;
        }

        public bool GetCheckState(int index)
        {
            return SourceCheckState[index];
        }

        public void SetCheckState(Net net, bool state)
        {
            int index = SourceNets.IndexOf(net);
            if (index != -1)
            {
                SourceCheckState[index] = state;
            }
        }

        public bool GetCheckState(Net net)
        {
            int index = SourceNets.IndexOf(net);
            if (index != -1)
            {
                return SourceCheckState[index];
            }

            return false;
        }

        #endregion Сетки.

        #endregion Свойства.

        public QuestionGeneratorNumberGenerator()
        {
            this.SourceCheckState = new bool[SourceNets.Count];
        }

        static QuestionGeneratorNumberGenerator()
        {
            SourceNets = Net.FilteredNets;

            int length = 0;
            foreach (Net item in SourceNets)
            {
                length = Math.Max(length, item.Name.Length);
            }

            MaxNetLength = length + 2;
        }

        #region Генерация нового вопроса.

        public void CreateNewQuestion()
        {
            int patternCount = this.symbolsCount / 2 + this.symbolsCount % 2;

            bool hasSingleNumber = this.symbolsCount % 2 != 0;

            Collection<Net> selectedNets = GetSelectedNets();

            Collection<AssociationQuestionPart> numbers = new Collection<AssociationQuestionPart>();

            int singleNumber = -1;

            do
            {
                numbers.Clear();

                if (hasSingleNumber)
                {
                    singleNumber = rnd.Next(patternCount);
                }

                for (int i = 0; i < patternCount; i++)
                {
                    string nextNumber = string.Empty;
                    if (i == singleNumber)
                    {
                        nextNumber = rnd.Next(10).ToString();
                    }
                    else if (this.IsRangeEnabled)
                    {
                        nextNumber = (rnd.Next(this.maxNumber - this.minNumber + 1) + this.minNumber).ToString("D2");
                    }
                    else
                    {
                        nextNumber = rnd.Next(100).ToString("D2");
                    }

                    AssociationQuestionPart quest = new AssociationQuestionPart(nextNumber);
                    if (selectedNets.Count > 1)
                    {
                        quest.NetName = selectedNets[rnd.Next(selectedNets.Count)].Name;
                    }

                    numbers.Add(quest);
                }

            } while (QuestionIsRepeat(numbers));


            StringBuilder questionBuilder = new StringBuilder();
            StringBuilder answerBuilder = new StringBuilder();

            if (selectedNets.Count > 1)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (questionBuilder.Length > 0)
                    {
                        if (i % 2 == 0)
                        {
                            questionBuilder.Append("\r\n");
                        }
                        else
                        {
                            questionBuilder.Append("   ");
                        }
                    }

                    AssociationQuestionPart item = numbers[i];

                    questionBuilder.AppendFormat("{0} {1}", item.Word.PadLeft(2), ("\"" + item.NetName + "\"").PadRight(MaxNetLength));
                    answerBuilder.Append(item.Word);
                }
            }
            else
            {
                foreach (AssociationQuestionPart item in numbers)
                {
                    if (questionBuilder.Length > 0)
                    {
                        questionBuilder.Append(" ");
                    }

                    questionBuilder.Append(item.Word);
                    answerBuilder.Append(item.Word);
                }
            }

            this.questionText = questionBuilder.ToString();
            this.answerValue = answerBuilder.ToString();
        }

        private Collection<Net> GetSelectedNets()
        {
            Collection<Net> result = new Collection<Net>();

            for (int i = 0; i < SourceNets.Count; i++)
            {
                if (this.SourceCheckState[i])
                {
                    result.Add(SourceNets[i]);
                }
            }

            return result;
        }

        #region Проверка повторов вопросов.

        private bool QuestionIsRepeat(Collection<AssociationQuestionPart> numbers)
        {
            int countRepeat = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (i != j && numbers[i].Equals(numbers[j]))
                    {
                        countRepeat++;
                    }
                }
            }

            if (countRepeat > 1)
            {
                return true;
            }

            foreach (AssociationQuestionPart item in numbers)
            {
                if (lastQuestions.Contains(item))
                {
                    return true;
                }
            }

            foreach (AssociationQuestionPart item in numbers)
            {
                if (item.Word.Length > 1 && !lastQuestions.Contains(item))
                {
                    lastQuestions.Add(item);
                }
            }

            while (lastQuestions.Count > this.RepeatCount)
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
            isAnswerRight = false;

            userAnswerText = userAnswer;

            isAnswerRight = CompareAnswers(this.answerValue, userAnswerText);

            answerText = this.questionText;

            if (!isAnswerRight)
            {
                answerText += !string.IsNullOrEmpty(userAnswerText) ? "\r\n\r\n" + userAnswerText : string.Empty;
            }
        }

        private bool CompareAnswers(string rightAnswer, string answer)
        {
            return string.Compare(rightAnswer, answer) == 0;
        }
    }
}
