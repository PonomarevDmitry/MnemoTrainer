using System;
using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Тип упражнения "Устный счет".
    /// </summary>
    public class ExerciseTypeCalculate : ExerciseType
    {
        protected TrainTypeCalculate testType = TrainTypeCalculate.None;
        /// <summary>
        /// Внутренний тип упражнения "Устный счет".
        /// </summary>
        public TrainTypeCalculate TestType { get { return testType; } set { this.testType = value; } }

        /// <summary>
        /// Количество слагаемых.
        /// </summary>
        public int? SummandCount { get; set; }

        /// <summary>
        /// Использование отрицательных слагаемых.
        /// </summary>
        public bool WithNegativ { get; set; }

        public ExerciseTypeCalculate()
        {
            this.type = TrainType.Calculate;
        }

        public override string GetDescription()
        {
            string result = "Упражнение \"Устный счет\"";

            if (this.testType == TrainTypeCalculate.Multiplication)
            {
                result += ", умножение чисел";

            }
            else if (this.testType == TrainTypeCalculate.Sum)
            {
                string negativ = this.WithNegativ ? " с отрицательными значениями" : string.Empty;

                result += string.Format(", сложение {0} цифр{1}", this.SummandCount, negativ);
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
        private const string xmlFieldSummandCount = "SummandCount";
        private const string xmlFieldWithNegativ = "WithNegativ";

        internal override void SaveTypeAttributes(XmlNode xmlNode)
        {
            base.SaveTypeAttributes(xmlNode);

            XmlAttribute attr;

            attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldTestType);
            attr.Value = this.testType.ToString();
            xmlNode.Attributes.Append(attr);

            if (this.testType == TrainTypeCalculate.Sum)
            {
                if (this.SummandCount.HasValue)
                {
                    attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldSummandCount);
                    attr.Value = this.SummandCount.Value.ToString();
                    xmlNode.Attributes.Append(attr);
                }

                if (this.WithNegativ)
                {
                    attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldWithNegativ);
                    attr.Value = this.WithNegativ.ToString();
                    xmlNode.Attributes.Append(attr);
                }
            }
        }

        protected override void LoadTypeAttributes(XmlNode xmlNode)
        {
            base.LoadTypeAttributes(xmlNode);

            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldTestType];

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                this.testType = (TrainTypeCalculate)Enum.Parse(typeof(TrainTypeCalculate), attr.Value);

                if (this.testType == TrainTypeCalculate.Sum)
                {
                    attr = xmlNode.Attributes[xmlFieldSummandCount];
                    if (attr != null && !string.IsNullOrEmpty(attr.Value))
                    {
                        int temp;
                        if (int.TryParse(attr.Value, out temp))
                        {
                            this.SummandCount = temp;
                        }
                    }

                    attr = xmlNode.Attributes[xmlFieldWithNegativ];
                    if (attr != null && !string.IsNullOrEmpty(attr.Value))
                    {
                        bool temp;
                        if (bool.TryParse(attr.Value, out temp))
                        {
                            this.WithNegativ = temp;
                        }
                    }
                }
            }
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ExerciseTypeCalculate) || !base.Equals(obj))
            {
                return false;
            }

            ExerciseTypeCalculate target = (ExerciseTypeCalculate)obj;

            if (this.testType == target.testType)
            {
                if (this.testType == TrainTypeCalculate.Multiplication)
                {
                    return true;
                }
                else if (this.testType == TrainTypeCalculate.Sum)
                {
                    return this.SummandCount == target.SummandCount && this.WithNegativ == target.WithNegativ;
                }
            }

            return false;
        }
    }
}
