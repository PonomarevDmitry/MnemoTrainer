using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.QuestionGenerator
{
    public class QuestionGeneratorCalculateSeries
    {
        #region Внутренние поля.

        Random rnd = new Random();

        private const int standartRepeatCount = 70;
        private const int standartRepeatCountRes = 50;

        private Collection<int> lastMultiply = new Collection<int>();

        private Collection<int> lastAddition = new Collection<int>();

        #endregion Внутренние поля.

        private string operationText = string.Empty;

        private int questionIndex = -1;
        public int QuestionIndex
        {
            get { return this.questionIndex; }
        }

        private string questionText = string.Empty;
        public string QuestionText
        {
            get { return this.questionText; }
        }

        private int answerValue = -1;
        public int AnswerValue
        {
            get { return this.answerValue; }
        }

        private int seriesCount = 5;
        public int SeriesCount
        {
            get { return this.seriesCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("SeriesCount");
                }

                this.seriesCount = value;

                this.serieValues = new int[this.seriesCount];

                this.Clear();
            }
        }

        /// <summary>
        /// Со сложением
        /// </summary>
        public virtual bool WithAddition { get; set; }

        /// <summary>
        /// С умножением
        /// </summary>
        public virtual bool WithMultiplication { get; set; }

        private int[] serieValues;

        #region Сложение.

        private int additionRange = 10;
        public int AdditionRange
        {
            get { return this.additionRange; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("AdditionRange");
                }

                this.additionRange = value;
            }
        }

        #endregion Сложение.

        #region Умножение.

        private int multiplyMin = 1;
        public int MultiplyMin
        {
            get { return this.multiplyMin; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MultiplyMin");
                }

                this.multiplyMin = value;
            }
        }

        private int multiplyMax = 10;
        public int MultiplyMax
        {
            get { return this.multiplyMax; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MultiplyMax");
                }

                this.multiplyMax = value;
            }
        }

        #endregion Умножение.

        public QuestionGeneratorCalculateSeries()
        {
            this.serieValues = new int[this.seriesCount];
        }

        #region Генерация нового вопроса.

        public void CreateNewQuestion()
        {
            this.questionIndex = rnd.Next(this.seriesCount);

            bool isAddition = true;

            if (this.serieValues[this.questionIndex] != 0)
            {
                if (this.WithAddition && this.WithMultiplication)
                {
                    isAddition = rnd.Next(2) == 0;
                }
                else if (this.WithAddition)
                {
                    isAddition = true;
                }
                else if (this.WithMultiplication)
                {
                    isAddition = false;
                }
            }

            int question = 0;

            do
            {
                if (isAddition)
                {
                    question = rnd.Next(this.additionRange * 2 + 1) - this.additionRange;
                }
                else
                {
                    int minValue = this.multiplyMin;
                    int maxValue = this.multiplyMax;

                    question = rnd.Next(maxValue - minValue + 1) + minValue;
                }
            } while (question == 0);

            string mathOperation = string.Empty;

            if (isAddition)
            {
                this.questionText = (question >= 0 ? "+" : string.Empty) + question.ToString();
                this.answerValue = this.serieValues[this.questionIndex] + question;

                mathOperation = question >= 0 ? "+" : "-";
            }
            else
            {
                this.questionText = string.Format("*{0}", question.ToString());
                this.answerValue = this.serieValues[this.questionIndex] * question;

                mathOperation = "*";
            }

            this.operationText = string.Format("{0} {1} {2} = {3}", this.serieValues[this.questionIndex].ToString(), mathOperation, Math.Abs(question).ToString(), this.answerValue.ToString());
        }

        #region Проверка повторов вопросов.

        private bool MultiplicationQuestionIsRepeat(int res1, int res2)
        {
            //if (res1 == 1 || res1 == 10 || res2 == 1 || res2 == 10)
            //{
            //    return true;
            //}

            //if (lastMultiplyRes1.Contains(res1)) return true;
            //if (lastMultiplyRes2.Contains(res2)) return true;

            //int maxRes1Count = (leftMultiplyMax - leftMultiplyMin) / 2;
            //int maxRes2Count = (rightMultiplyMax - rightMultiplyMin) / 2;

            //if (lastMultiplyRes1.Count == Math.Min(standartRepeatCountRes, maxRes1Count))
            //{
            //    lastMultiplyRes1.RemoveAt(0);
            //}

            //if (lastMultiplyRes2.Count == Math.Min(standartRepeatCountRes, maxRes2Count))
            //{
            //    lastMultiplyRes2.RemoveAt(0);
            //}

            //lastMultiplyRes1.Add(res1);
            //lastMultiplyRes2.Add(res2);

            return false;
        }

        private bool AdditionQuestionIsRepeat(int res1, int res2, bool addition)
        {
            //if ((res1 == 0 || res2 == 0) && addition)
            //{
            //    return true;
            //}

            //if (!addition && (res2 == 0))
            //{
            //    return true;
            //}

            //if (!addition && res1 == res2)
            //{
            //    return true;
            //}

            //if (lastAdditionRes1.Contains(res1)) return true;
            //if (lastAdditionRes2.Contains(res2)) return true;

            //int maxRes1Count = (leftMultiplyMax - leftMultiplyMin) / 2;
            //int maxRes2Count = (rightMultiplyMax - rightMultiplyMin) / 2;

            //maxRes1Count = Math.Min(standartRepeatCountRes, maxRes1Count);
            //maxRes2Count = Math.Min(standartRepeatCountRes, maxRes2Count);

            //while (lastAdditionRes1.Count >= maxRes1Count)
            //{
            //    lastAdditionRes1.RemoveAt(0);
            //}

            //while (lastAdditionRes2.Count >= maxRes2Count)
            //{
            //    lastAdditionRes2.RemoveAt(0);
            //}

            //lastAdditionRes1.Add(res1);
            //lastAdditionRes2.Add(res2);

            return false;
        }

        #endregion Проверка повторов вопросов.

        #endregion Генерация нового вопроса.

        public void Clear()
        {
            lastMultiply.Clear();
            lastAddition.Clear();

            for (int i = 0; i < this.serieValues.Length; i++)
            {
                serieValues[i] = 0;
            }
        }

        public void CheckAnswer(string userAnswer, out bool isAnswerRight, out string answerText, out string userAnswerText)
        {
            isAnswerRight = false;

            int? userAnswerInt = null;
            int tempInt = 0;

            if (int.TryParse(userAnswer, out tempInt))
            {
                userAnswerInt = tempInt;
            }

            userAnswerText = userAnswerInt.ToString();

            isAnswerRight = CompareAnswers(this.answerValue, userAnswerInt);

            answerText = this.operationText;

            this.serieValues[this.questionIndex] = answerValue;

            if (!isAnswerRight)
            {
                answerText += !string.IsNullOrEmpty(userAnswerText) ? " <> " + userAnswerText : string.Empty;
            }
        }

        private bool CompareAnswers(int rightAnswer, int? answer)
        {
            return answer.HasValue && rightAnswer == answer.Value;
        }
    }
}
