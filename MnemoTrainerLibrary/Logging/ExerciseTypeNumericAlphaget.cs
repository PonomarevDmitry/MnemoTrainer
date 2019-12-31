using System;
using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Тип упражнения "Цифровой алфавит".
    /// </summary>
    public class ExerciseTypeNumericAlphaget : ExerciseType
    {
        protected TrainTypeNumericAlphaget testType = TrainTypeNumericAlphaget.None;
        /// <summary>
        /// Внутренний тип упражнения.
        /// </summary>
        public TrainTypeNumericAlphaget TestType { get { return testType; } set { this.testType = value; } }

        public ExerciseTypeNumericAlphaget()
        {
            this.type = TrainType.NumericAlphabet;
        }

        public override string GetDescription()
        {
            string result = "Тренировка цифрового алфавита";

            if (this.testType == TrainTypeNumericAlphaget.Number)
            {
                result += ", ответ - само число";
            }
            else if (this.testType == TrainTypeNumericAlphaget.Sum)
            {
                result += ", ответ - сумма цифр числа";
            }

            if (this.ShowTime.HasValue)
            {
                result += string.Format(", вопрос отображается {0} мс", this.ShowTime.Value.ToString());
            }

            if (this.AutoAnswerCheckTime.HasValue)
            {
                result += string.Format(", на ответ дается {0} мс", this.AutoAnswerCheckTime.Value.ToString());
            }

            result += ".";

            return result;
        }

        private const string xmlFieldTestType = "TestType";

        internal override void SaveTypeAttributes(XmlNode xmlNode)
        {
            base.SaveTypeAttributes(xmlNode);

            XmlAttribute attr;

            attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldTestType);
            attr.Value = this.testType.ToString();
            xmlNode.Attributes.Append(attr);
        }

        protected override void LoadTypeAttributes(XmlNode xmlNode)
        {
            base.LoadTypeAttributes(xmlNode);

            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldTestType];

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                this.testType = (TrainTypeNumericAlphaget)Enum.Parse(typeof(TrainTypeNumericAlphaget), attr.Value);
            }
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ExerciseTypeNumericAlphaget) || !base.Equals(obj))
            {
                return false;
            }

            ExerciseTypeNumericAlphaget target = (ExerciseTypeNumericAlphaget)obj;

            return target.testType == this.testType;
        }
    }
}
