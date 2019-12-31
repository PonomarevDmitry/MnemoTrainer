using System;
using System.Collections.Generic;
using System.Text;
using MnemoTrainerLibrary.Classes;
using System.Collections.ObjectModel;
using System.Drawing;

namespace MnemoTrainerLibrary.QuestionGenerator
{
    public class QuestionGeneratorNet
    {
        #region Внутренние поля.

        Random rnd = new Random();

        private RandomizeCollection randCol = new RandomizeCollection();

        private Collection<NetTest> allQuestions = new Collection<NetTest>();
        private Collection<CalculationType> lastTypes = new Collection<CalculationType>();

        private bool oneNet = false;

        private enum CalculationType
        {
            None = 0,
            Addition = 1,
            Subtraction = 2,
            Multiplication = 3
        }

        #endregion Внутренние поля.

        private string rightAnswer = string.Empty;

        private string answerText = string.Empty;
        public string AnswerText
        {
            get { return this.answerText; }
        }

        private string questionText = string.Empty;
        public string QuestionText
        {
            get { return this.questionText; }
        }

        public Color? ForeColor { get; private set; }

        public Color? BackColor { get; private set; }

        public int NetTestCount
        {
            get { return this.allQuestions.Count; }
        }

        public int LapsCount
        {
            get { return this.randCol.LapsCount; }
        }

        public int AskedQuestionsCount
        {
            get { return this.randCol.AskedQuestionsCount; }
        }

        private int currentElementIndex;

        private NetTest currentElement;
        public NetTest CurrentElement
        {
            get { return this.currentElement; }
        }

        #region Свойства.

        public NetTestType TestType { get; set; }

        public virtual bool WithCalculations { get; set; }

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

        public QuestionGeneratorNet()
        {
            this.SourceCheckState = new bool[SourceNets.Count];
        }

        static QuestionGeneratorNet()
        {
            SourceNets = Net.Nets;
        }

        #region Генерация нового вопроса.

        public void CreateNewQuestion()
        {
            this.ForeColor = null;
            this.BackColor = null;

            this.currentElementIndex = randCol.GetRandomIndex();
            this.currentElement = allQuestions[currentElementIndex];

            StringBuilder questionBuilder = new StringBuilder();

            if (currentElement.TestType == NetTestType.Pattern)
            {
                if (this.WithCalculations && currentElement.Answer.Length > 1)
                {
                    CalculationType type = GetCalculationType(currentElement.Answer);

                    string testName = ConvertToString(type);
                    if (!string.IsNullOrEmpty(testName))
                    {
                        questionBuilder.AppendLine(testName);
                    }

                    this.rightAnswer = GenerateAnswer(currentElement.Answer, out this.answerText, type);
                }
                else
                {
                    this.answerText = this.rightAnswer = currentElement.Answer;
                }

                questionBuilder.Append(currentElement.Question);
            }
            else if (currentElement.TestType == NetTestType.Number)
            {
                questionBuilder.Append(currentElement.Question);
                this.answerText = this.rightAnswer = currentElement.Answer;
            }

            if (!oneNet)
            {
                questionBuilder.AppendLine();
                questionBuilder.Append(currentElement.BaseUnit.NetName);
            }

            this.questionText = questionBuilder.ToString();

            if (currentElement.QuestionColor.HasValue)
            {
                if (currentElement.TestType == NetTestType.Pattern)
                {
                    this.questionText = string.Empty;
                    this.BackColor = currentElement.QuestionColor.Value;
                }
                else if (currentElement.TestType == NetTestType.Number)
                {
                    this.ForeColor = currentElement.QuestionColor.Value;
                }
            }
        }

        #region Функции отображения вопроса и ответа.

        private CalculationType GetCalculationType(string question)
        {
            if (question[1] == '0')
            {
                return CalculationType.None;
            }

            Array allTypes = Enum.GetValues(typeof(CalculationType));

            Collection<CalculationType> avalibleTypes = new Collection<CalculationType>();

            foreach (CalculationType item in allTypes)
            {
                avalibleTypes.Add(item);
            }

            if (question[0] == '0')
            {
                avalibleTypes.Remove(CalculationType.Addition);
                avalibleTypes.Remove(CalculationType.Multiplication);
            }

            if (question[0] == '1' || question[1] == '1')
            {
                avalibleTypes.Remove(CalculationType.Multiplication);
            }

            if (question[0] == question[1])
            {
                avalibleTypes.Remove(CalculationType.Subtraction);
            }

            if (avalibleTypes.Count == 0)
            {
                return CalculationType.None;
            }

            CalculationType result = CalculationType.None;

            for (int i = lastTypes.Count - 1; i >= 0; i--)
            {
                avalibleTypes.Remove(lastTypes[i]);

                if (avalibleTypes.Count == 1)
                {
                    result = avalibleTypes[0];

                    AddCalculationTypeInHistory(result);

                    return result;
                }
            }

            result = avalibleTypes[rnd.Next(avalibleTypes.Count)];

            AddCalculationTypeInHistory(result);

            return result;
        }

        private void AddCalculationTypeInHistory(CalculationType result)
        {
            lastTypes.Add(result);

            while (lastTypes.Count > 2)
            {
                lastTypes.RemoveAt(0);
            }
        }

        private string GenerateAnswer(string str, out string displayedAnswer, CalculationType type)
        {
            string result = string.Empty;
            displayedAnswer = string.Empty;

            if (str.Length == 1)
            {
                result = str;
                displayedAnswer = str;
            }
            else if (str.Length == 2)
            {
                int a = str[0] - '0';
                int b = str[1] - '0';

                string format = string.Empty;

                switch (type)
                {
                    case CalculationType.Addition:
                        result = (a + b).ToString();
                        format = "{0}: {1} + {2} = {3}";
                        break;
                    case CalculationType.Subtraction:
                        result = (a - b).ToString();
                        format = "{0}: {1} - {2} = {3}";
                        break;
                    case CalculationType.Multiplication:
                        result = (a * b).ToString();
                        format = "{0}: {1} * {2} = {3}";
                        break;
                    case CalculationType.None:
                    default:
                        result = str;
                        format = str;
                        break;
                }

                displayedAnswer = string.Format(format, str, str[0], str[1], result);
            }

            return result;
        }

        private string ConvertToString(CalculationType type)
        {
            string result = string.Empty;

            switch (type)
            {
                case CalculationType.Addition:
                    result = "Сложение";
                    break;
                case CalculationType.Subtraction:
                    result = "Вычитание";
                    break;
                case CalculationType.Multiplication:
                    result = "Умножение";
                    break;
                case CalculationType.None:
                default:
                    break;
            }

            return result;
        }

        #endregion Функции отображения вопроса и ответа.

        #region Создание новой коллекции вопросов.

        public void CreateQuestionCollection()
        {
            allQuestions.Clear();

            Collection<Net> selectedNets = GetSelectedNets();
            if (selectedNets.Count == 0)
            {
                return;
            }

            this.oneNet = selectedNets.Count == 1;

            int minValue = 0;
            int maxValue = 100;

            if (this.IsRangeEnabled && this.minNumber <= this.maxNumber)
            {
                minValue = this.minNumber;
                maxValue = this.maxNumber;
            }

            foreach (Net net in selectedNets)
            {
                foreach (NetUnit unit in net.Units)
                {
                    int unitNumber = 0;

                    if (int.TryParse(unit.Number, out unitNumber))
                    {
                        if (minValue <= unitNumber && unitNumber <= maxValue)
                        {
                            if ((this.TestType & NetTestType.Number) != 0)
                            {
                                allQuestions.Add(new NetTest(unit.Number, unit.Pattern, NetTestType.Number, unit, unit.PatternColor));
                            }

                            if ((this.TestType & NetTestType.Pattern) != 0)
                            {
                                if (unit.Pattern.Contains(" ") && net.NumberAlphabet)
                                {
                                    string[] tempQText = unit.Pattern.Split(' ');
                                    foreach (string splitItem in tempQText)
                                    {
                                        allQuestions.Add(new NetTest(splitItem, unit.Number, NetTestType.Pattern, unit));
                                    }
                                }
                                else
                                {
                                    allQuestions.Add(new NetTest(unit.Pattern, unit.Number, NetTestType.Pattern, unit, unit.PatternColor));
                                }
                            }
                        }
                    }
                }
            }

            this.randCol.Length = allQuestions.Count;
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

        #endregion Создание новой коллекции вопросов.

        #endregion Генерация нового вопроса.

        public void CheckAnswer(string userAnswer, out bool isAnswerRight)
        {
            isAnswerRight = CompareAnswers(this.rightAnswer, userAnswer);

            if (isAnswerRight)
            {
                randCol.CheckInIndex(allQuestions.IndexOf(currentElement), isAnswerRight);
            }
        }

        private bool CompareAnswers(string rightAnswer, string userAnswer)
        {
            return string.Compare(rightAnswer, userAnswer, true) == 0;
        }
    }
}
