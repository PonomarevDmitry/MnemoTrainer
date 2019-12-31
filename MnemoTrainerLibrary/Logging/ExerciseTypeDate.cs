using System;
using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Потомок класса ExerciseType - расширенный тип для упражнения "Вычисление дня недели".
    /// </summary>
    public class ExerciseTypeDate : ExerciseType
    {
        protected TrainTypeDate testType = TrainTypeDate.None;
        /// <summary>
        /// Внутренний тип "вычисления дня недели".
        /// </summary>
        public TrainTypeDate TestType { get { return testType; } set { this.testType = value; } }

        public ExerciseTypeDate()
        {
            this.type = TrainType.Date;
        }

        public override string GetDescription()
        {
            string result = "Упражнение \"Вычисление дня недели\"";

            if (this.testType == TrainTypeDate.DayOfWeek)
            {
                result += ", подтип \"день недели по дате\"";
            }
            else if (this.testType == TrainTypeDate.MonthDate)
            {
                result += ", подтип \"индекс дня и месяца\"";
            }
            else if (this.testType == TrainTypeDate.IndexOfYear)
            {
                result += ", подтип \"индекс года\"";
            }
            else if (this.testType == TrainTypeDate.IndexOf12)
            {
                result += ", подтип \"индекс года двенадцатилетки\"";
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

        /// <summary>
        /// Дополняем метод сохранения атрибутов в XmlNode.
        /// </summary>
        /// <param name="xmlNode"></param>
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
                this.testType = (TrainTypeDate)Enum.Parse(typeof(TrainTypeDate), attr.Value);
            }
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        /// <summary>
        /// Доопределяем метод проверки эквивалентности.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ExerciseTypeDate) || !base.Equals(obj))
            {
                return false;
            }

            ExerciseTypeDate target = (ExerciseTypeDate)obj;

            return target.testType == this.testType;
        }
    }
}
