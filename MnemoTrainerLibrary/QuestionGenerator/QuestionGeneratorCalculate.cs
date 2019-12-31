using System;
using System.Collections.ObjectModel;
using System.Text;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.QuestionGenerator
{
    public class QuestionGeneratorCalculate
    {
        #region Внутренние поля.

        Random rnd = new Random();

        private const int standartRepeatCount = 70;
        private Collection<string> lastAdditionQuestions = new Collection<string>();

        private const int standartRepeatCountRes = 50;

        private Collection<int> lastMultiplyRes1 = new Collection<int>();
        private Collection<int> lastMultiplyRes2 = new Collection<int>();

        private Collection<int> lastAdditionRes1 = new Collection<int>();
        private Collection<int> lastAdditionRes2 = new Collection<int>();

        #endregion Внутренние поля.

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

        public TrainTypeCalculate TestType { get; set; }

        #region Сложение.

        public virtual bool WithNegativ { get; set; }

        private int summandCount = 5;
        public int SummandCount
        {
            get { return this.summandCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("SummandCount");
                }

                this.summandCount = value;
            }
        }

        #endregion Сложение.

        #region Умножение.

        private int leftMultiplyMin = 1;
        public int LeftMultiplyMin
        {
            get { return this.leftMultiplyMin; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("LeftMultiplyMin");
                }

                this.leftMultiplyMin = value;
            }
        }

        private int leftMultiplyMax = 99;
        public int LeftMultiplyMax
        {
            get { return this.leftMultiplyMax; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("LeftMultiplyMax");
                }

                this.leftMultiplyMax = value;
            }
        }

        private int rightMultiplyMin = 1;
        public int RightMultiplyMin
        {
            get { return this.rightMultiplyMin; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("RightMultiplyMin");
                }

                this.rightMultiplyMin = value;
            }
        }

        private int rightMultiplyMax = 99;
        public int RightMultiplyMax
        {
            get { return this.rightMultiplyMax; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("RightMultiplyMax");
                }

                this.rightMultiplyMax = value;
            }
        }

        #endregion Умножение.

        public QuestionGeneratorCalculate()
        {
            this.TestType = TrainTypeCalculate.None;
        }

        #region Генерация нового вопроса.

        public void CreateNewQuestion()
        {
            if (this.TestType == TrainTypeCalculate.Sum)
            {
                StringBuilder stringBuilder;

                do
                {
                    int result = 0;

                    stringBuilder = new StringBuilder();

                    for (int i = 0; i < this.summandCount; i++)
                    {
                        int temp = 0;

                        if (this.WithNegativ)
                        {
                            temp = rnd.Next(19) - 9;
                        }
                        else
                        {
                            temp = rnd.Next(10);
                        }

                        result += temp;
                        stringBuilder.Append(temp.ToString());
                    }

                    answerValue = result;

                } while (SummQuestionIsRepeat(stringBuilder.ToString()));

                questionText = stringBuilder.ToString();
            }
            else if (this.TestType == TrainTypeCalculate.Multiplication)
            {
                int res1, res2;

                do
                {
                    res1 = rnd.Next(leftMultiplyMax - leftMultiplyMin + 1) + leftMultiplyMin;
                    res2 = rnd.Next(rightMultiplyMax - rightMultiplyMin + 1) + rightMultiplyMin;

                } while (MultiplicationQuestionIsRepeat(res1, res2));

                questionText = string.Format("{0} * {1}", res1.ToString("D2"), res2.ToString("D2"));
                answerValue = res1 * res2;
            }
            else if (this.TestType == TrainTypeCalculate.Addition)
            {
                bool addition = true;

                int res1, res2;

                do
                {
                    addition = rnd.Next(2) == 0;

                    res1 = rnd.Next(leftMultiplyMax - leftMultiplyMin + 1) + leftMultiplyMin;
                    res2 = rnd.Next(rightMultiplyMax - rightMultiplyMin + 1) + rightMultiplyMin;

                } while (AdditionQuestionIsRepeat(res1, res2, addition));

                questionText = string.Format("{0} {1} {2}", res1.ToString("D2"), (addition ? "+" : "-"), res2.ToString("D2"));
                answerValue = addition ? res1 + res2 : res1 - res2;
            }
        }

        #region Проверка повторов вопросов.

        private bool SummQuestionIsRepeat(string text)
        {
            if (lastAdditionQuestions.Contains(text)) return true;

            if (lastAdditionQuestions.Count == standartRepeatCount)
            {
                lastAdditionQuestions.RemoveAt(0);
            }

            lastAdditionQuestions.Add(text);

            return false;
        }

        private bool MultiplicationQuestionIsRepeat(int res1, int res2)
        {
            if (res1 == 1 || res1 == 10 || res2 == 1 || res2 == 10)
            {
                return true;
            }

            if (lastMultiplyRes1.Contains(res1)) return true;
            if (lastMultiplyRes2.Contains(res2)) return true;

            int maxRes1Count = (leftMultiplyMax - leftMultiplyMin) / 2;
            int maxRes2Count = (rightMultiplyMax - rightMultiplyMin) / 2;

            if (lastMultiplyRes1.Count == Math.Min(standartRepeatCountRes, maxRes1Count))
            {
                lastMultiplyRes1.RemoveAt(0);
            }

            if (lastMultiplyRes2.Count == Math.Min(standartRepeatCountRes, maxRes2Count))
            {
                lastMultiplyRes2.RemoveAt(0);
            }

            lastMultiplyRes1.Add(res1);
            lastMultiplyRes2.Add(res2);

            return false;
        }

        private bool AdditionQuestionIsRepeat(int res1, int res2, bool addition)
        {
            if ((res1 == 0 || res2 == 0) && addition)
            {
                return true;
            }

            if (!addition && (res2 == 0))
            {
                return true;
            }

            if (!addition && res1 == res2)
            {
                return true;
            }

            if (lastAdditionRes1.Contains(res1)) return true;
            if (lastAdditionRes2.Contains(res2)) return true;

            int maxRes1Count = (leftMultiplyMax - leftMultiplyMin) / 2;
            int maxRes2Count = (rightMultiplyMax - rightMultiplyMin) / 2;

            maxRes1Count = Math.Min(standartRepeatCountRes, maxRes1Count);
            maxRes2Count = Math.Min(standartRepeatCountRes, maxRes2Count);

            while (lastAdditionRes1.Count >= maxRes1Count)
            {
                lastAdditionRes1.RemoveAt(0);
            }

            while (lastAdditionRes2.Count >= maxRes2Count)
            {
                lastAdditionRes2.RemoveAt(0);
            }

            lastAdditionRes1.Add(res1);
            lastAdditionRes2.Add(res2);

            return false;
        }

        #endregion Проверка повторов вопросов.

        #endregion Генерация нового вопроса.

        public void Clear()
        {
            lastAdditionQuestions.Clear();
            lastMultiplyRes1.Clear();
            lastMultiplyRes2.Clear();
            lastAdditionRes1.Clear();
            lastAdditionRes2.Clear();
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

            answerText = this.questionText + "\r\n" + this.answerValue.ToString();

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
