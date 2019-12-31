using System;
using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Попытка выполнить тренировку сетки
    /// </summary>
    public class ExerciseAttemptNetTrain : ExerciseAttempt
    {
        protected NetTestType testType = NetTestType.None;
        /// <summary>
        /// Тип вопроса.
        /// </summary>
        public NetTestType TestType { get { return testType; } set { this.testType = value; } }

        public string NetName { get; set; }

        public ExerciseAttemptNetTrain()
        {
            this.type = TrainType.Date;
        }

        public ExerciseAttemptNetTrain(NetTestType locType, DateTime dateStart, double time, bool autoCheck, string question, string answer, string netName, bool answerIsRight, string userAnswer)
        {
            this.type = TrainType.NetTrain;
            this.testType = locType;

            this.DateStart = dateStart;

            this.Time = time;
            this.AutoAnswerCheck = autoCheck;

            this.Question = question;
            this.Answer = answer;
            this.NetName = netName;

            this.answerIsRight = answerIsRight;

            if (!answerIsRight)
            {
                this.UserAnswer = userAnswer;
            }
        }

        private const string xmlFieldTestType = "TestType";
        private const string xmlFieldNetName = "NetName";

        /// <summary>
        /// Считывание атрибутов из XmlNode.
        /// </summary>
        /// <param name="xmlNode"></param>
        public override void LoadAttributesFromXml(XmlNode xmlNode)
        {
            base.LoadAttributesFromXml(xmlNode);

            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldTestType];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                this.testType = (NetTestType)Enum.Parse(typeof(NetTestType), attr.Value);
            }

            attr = xmlNode.Attributes[xmlFieldNetName];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                this.NetName = attr.Value;
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

            XmlAttribute attr;

            attr = doc.CreateAttribute(xmlFieldNetName);
            attr.Value = this.NetName;
            result.Attributes.Append(attr);

            attr = doc.CreateAttribute(xmlFieldTestType);
            attr.Value = this.TestType.ToString();
            result.Attributes.Append(attr);

            return result;
        }
    }
}
