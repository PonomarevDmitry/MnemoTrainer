using System;
using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Потомок класса ExerciseAttempt. Попытка выполнить упражнение "Вычисление дня недели".
    /// </summary>
    public class ExerciseAttemptDate : ExerciseAttempt
    {
        DateTime? QuestionDate { get; set; }

        public ExerciseAttemptDate()
        {
            this.type = TrainType.Date;
        }

        public ExerciseAttemptDate(DateTime? questionDate, DateTime dateStart, double time, bool autoCheck, string question, string answer, bool answerIsRight, string userAnswer)
        {
            this.type = TrainType.Date;
            this.DateStart = dateStart;
            this.Time = time;
            this.AutoAnswerCheck = autoCheck;

            this.QuestionDate = questionDate;

            this.Question = question;
            this.Answer = answer;
            this.answerIsRight = answerIsRight;

            if (!answerIsRight)
            {
                this.UserAnswer = userAnswer;
            }
        }

        private const string xmlFieldQuestionDate = "QuestionDate";

        /// <summary>
        /// Считывание атрибутов из XmlNode.
        /// </summary>
        /// <param name="xmlNode"></param>
        public override void LoadAttributesFromXml(XmlNode xmlNode)
        {
            base.LoadAttributesFromXml(xmlNode);

            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldQuestionDate];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                DateTime temp;
                if (DateTime.TryParse(attr.Value, out temp))
                {
                    this.QuestionDate = temp;
                }
            }
        }

        /// <summary>
        /// Создание XmlNode по экземпляру класса.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public override XmlNode CreateXmlNode(XmlDocument doc)
        {
            XmlNode result = base.CreateXmlNode(doc);

            if (this.QuestionDate.HasValue)
            {
                XmlAttribute attr;

                attr = doc.CreateAttribute(xmlFieldQuestionDate);
                attr.Value = this.QuestionDate.Value.ToString();
                result.Attributes.Append(attr);
            }

            return result;
        }
    }
}
