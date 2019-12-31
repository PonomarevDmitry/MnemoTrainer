using System;
using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Попытка выполнить упражнение.
    /// </summary>
    public class ExerciseAttempt
    {
        protected TrainType type = TrainType.None;
        /// <summary>
        /// Общий тип упражнения.
        /// </summary>
        public TrainType Type
        { get { return type; } set { type = value; } }

        /// <summary>
        /// Дата начала.
        /// </summary>
        public DateTime? DateStart { get; set; }

        /// <summary>
        /// Дата окончания теста.
        /// </summary>
        public DateTime? DateEnd { get; set; }

        /// <summary>
        /// Время выполения.
        /// </summary>
        public double Time { get; set; }

        /// <summary>
        /// Вопрос.
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// Правильный ответ.
        /// </summary>
        public string Answer { get; set; }

        protected bool answerIsRight = false;
        /// <summary>
        /// Был ли ответ пользователя правильным.
        /// </summary>
        public bool AnswerIsRight { get { return answerIsRight; } }

        /// <summary>
        /// Ответ пользователя.
        /// </summary>
        public string UserAnswer { get; set; }

        /// <summary>
        /// Количество вопросов в данной попытки, при автоматическом отображении.
        /// </summary>
        public int? TestCount { get; set; }

        /// <summary>
        /// Была ли проверка ответа выполнена из-за окончания отпущенного времени для ответа.
        /// </summary>
        public bool AutoAnswerCheck { get; set; }

        protected ExerciseAttempt() { }

        public ExerciseAttempt(TrainType type, DateTime dateStart, double time, bool autoCheck, string question, string answer, bool answerIsRight, string userAnswer)
        {
            this.type = type;
            this.DateStart = dateStart;
            this.Time = time;
            this.AutoAnswerCheck = autoCheck;

            this.Question = question;
            this.Answer = answer;
            this.answerIsRight = answerIsRight;

            if (!answerIsRight)
            {
                this.UserAnswer = userAnswer;
            }
        }

        public virtual double GetTotalTime
        {
            get { return this.Time; }
        }

        public virtual string GetErrorDesctiption()
        {
            return string.Format("{0} - {1} - {2}", this.Question, this.Answer, this.UserAnswer);
        }

        #region Сохранине в xml.

        private const string xmlNodeNameExerciseAttempt = "ExerciseAttempt";
        private const string xmlFieldTrainType = "TrainType";
        private const string xmlFieldDateStart = "DateStart";
        private const string xmlFieldDateEnd = "DateEnd";
        private const string xmlFieldTime = "Time";
        private const string xmlFieldQuestion = "Question";
        private const string xmlFieldAnswer = "Answer";
        private const string xmlFieldTestCount = "TestCount";
        private const string xmlFieldAnswerIsRight = "AnswerIsRight";
        private const string xmlFieldUserAnswer = "UserAnswer";
        private const string xmlFieldAutoAnswerCheck = "AutoAnswerCheck";

        /// <summary>
        /// Создание XmlNode по атрибутам объекта.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public virtual XmlNode CreateXmlNode(XmlDocument doc)
        {
            XmlNode result = doc.CreateElement(xmlNodeNameExerciseAttempt);

            XmlAttribute attr;

            attr = doc.CreateAttribute(xmlFieldTrainType);
            attr.Value = this.type.ToString();
            result.Attributes.Append(attr);

            if (this.DateStart.HasValue)
            {
                attr = doc.CreateAttribute(xmlFieldDateStart);
                attr.Value = this.DateStart.Value.ToString();
                result.Attributes.Append(attr);
            }

            if (this.DateEnd.HasValue)
            {
                attr = doc.CreateAttribute(xmlFieldDateEnd);
                attr.Value = this.DateEnd.Value.ToString();
                result.Attributes.Append(attr);
            }

            attr = doc.CreateAttribute(xmlFieldTime);
            attr.Value = this.Time.ToString();
            result.Attributes.Append(attr);

            if (!string.IsNullOrEmpty(this.Question))
            {
                attr = doc.CreateAttribute(xmlFieldQuestion);
                attr.Value = this.Question;
                result.Attributes.Append(attr);
            }

            if (!string.IsNullOrEmpty(this.Answer))
            {
                attr = doc.CreateAttribute(xmlFieldAnswer);
                attr.Value = this.Answer;
                result.Attributes.Append(attr);
            }

            if (this.TestCount.HasValue)
            {
                attr = doc.CreateAttribute(xmlFieldTestCount);
                attr.Value = this.TestCount.Value.ToString();
                result.Attributes.Append(attr);
            }

            attr = doc.CreateAttribute(xmlFieldAnswerIsRight);
            attr.Value = this.answerIsRight.ToString();
            result.Attributes.Append(attr);

            if (!this.answerIsRight)
            {
                attr = doc.CreateAttribute(xmlFieldUserAnswer);
                attr.Value = this.UserAnswer;
                result.Attributes.Append(attr);
            }

            if (this.AutoAnswerCheck)
            {
                attr = doc.CreateAttribute(xmlFieldAutoAnswerCheck);
                attr.Value = this.AutoAnswerCheck.ToString();
                result.Attributes.Append(attr);
            }

            return result;
        }

        /// <summary>
        /// Считывание атрибутов объекта из XmlNode.
        /// </summary>
        /// <param name="xmlNode"></param>
        public virtual void LoadAttributesFromXml(XmlNode xmlNode)
        {
            this.DateStart = null;
            this.DateEnd = null;
            this.Time = 0;
            this.AutoAnswerCheck = false;
            this.Question = string.Empty;
            this.Answer = string.Empty;
            this.answerIsRight = false;
            this.UserAnswer = string.Empty;

            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldTrainType];

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                this.type = (TrainType)Enum.Parse(typeof(TrainType), attr.Value);
            }

            attr = xmlNode.Attributes[xmlFieldQuestion];
            if (attr != null)
            {
                this.Question = attr.Value;
            }

            attr = xmlNode.Attributes[xmlFieldAnswer];
            if (attr != null)
            {
                this.Answer = attr.Value;
            }

            attr = xmlNode.Attributes[xmlFieldUserAnswer];
            if (attr != null)
            {
                this.UserAnswer = attr.Value;
            }

            attr = xmlNode.Attributes[xmlFieldDateStart];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                DateTime temp;
                if (DateTime.TryParse(attr.Value, out temp))
                {
                    this.DateStart = temp;
                }
            }

            attr = xmlNode.Attributes[xmlFieldDateEnd];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                DateTime temp;
                if (DateTime.TryParse(attr.Value, out temp))
                {
                    this.DateEnd = temp;
                }
            }

            attr = xmlNode.Attributes[xmlFieldTestCount];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                int temp;
                if (int.TryParse(attr.Value, out temp))
                {
                    this.TestCount = temp;
                }
            }

            attr = xmlNode.Attributes[xmlFieldTime];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                double temp;
                if (double.TryParse(attr.Value, out temp))
                {
                    this.Time = temp;
                }
            }

            attr = xmlNode.Attributes[xmlFieldAnswerIsRight];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                bool temp;
                if (bool.TryParse(attr.Value, out temp))
                {
                    this.answerIsRight = temp;
                }
            }

            attr = xmlNode.Attributes[xmlFieldAutoAnswerCheck];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                bool temp;
                if (bool.TryParse(attr.Value, out temp))
                {
                    this.AutoAnswerCheck = temp;
                }
            }
        }

        /// <summary>
        /// Создание экземпляра попытки по XmlNode.
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <returns></returns>
        public static ExerciseAttempt CreateFromXml(XmlNode xmlNode)
        {
            ExerciseAttempt result = new ExerciseAttempt();

            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldTrainType];

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                TrainType type = (TrainType)Enum.Parse(typeof(TrainType), attr.Value);

                switch (type)
                {
                    case TrainType.Date:
                        result = new ExerciseAttemptDate();
                        break;
                    case TrainType.NetTrain:
                        result = new ExerciseAttemptNetTrain();
                        break;
                    case TrainType.ConsecutiveAssociations:
                        result = new ExerciseAttemptAssociationsСonsecutive();
                        break;
                    case TrainType.NumberAssociations:
                        result = new ExerciseAttemptAssociationsNumber();
                        break;
                    case TrainType.AssociationsPair:
                        result = new ExerciseAttemptAssociationsPair();
                        break;

                    default:
                        result = new ExerciseAttempt();
                        break;
                }
            }

            result.LoadAttributesFromXml(xmlNode);

            return result;
        }

        #endregion Сохранине в xml.
    }
}
