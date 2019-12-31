using System;
using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Тип упражнения Степанова и тренировки Кратковременной памяти.
    /// </summary>
    public class ExerciseTypeStepanovAndRecentMemory : ExerciseType
    {
        protected TrainTypeStepanovAndRecentMemory testType = TrainTypeStepanovAndRecentMemory.None;
        /// <summary>
        /// Внутренний тип упражнения.
        /// </summary>
        public TrainTypeStepanovAndRecentMemory TestType { get { return testType; } set { this.testType = value; } }

        /// <summary>
        /// Количество слагаемых.
        /// </summary>
        public int? SymbolsCount { get; set; }

        public ExerciseTypeStepanovAndRecentMemory(TrainType locType)
        {
            if (locType != TrainType.RecentMemory && locType != TrainType.Stepanov)
            {
                this.type = TrainType.None;
            }
            else
            {
                this.type = locType;
            }
        }

        public override string GetDescription()
        {
            string result = string.Empty;

            if (this.type == TrainType.Stepanov)
            {
                result = "Упражнение Степанова два числа по {0}";
            }
            else if (this.type == TrainType.RecentMemory)
            {
                result = "Тренировака кратковременной памяти серией из {0}";
            }

            result = string.Format(result, this.SymbolsCount.Value.ToString());

            if (this.testType == TrainTypeStepanovAndRecentMemory.Numbers)
            {
                result += " цифр";
            }
            else if (this.testType == TrainTypeStepanovAndRecentMemory.NumbersAndSymbols)
            {
                result += " цифр и символов";
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
        private const string xmlFieldSymbolsCount = "SymbolsCount";

        internal override void SaveTypeAttributes(XmlNode xmlNode)
        {
            base.SaveTypeAttributes(xmlNode);

            XmlAttribute attr;

            attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldTestType);
            attr.Value = this.testType.ToString();
            xmlNode.Attributes.Append(attr);

            if (this.SymbolsCount.HasValue)
            {
                attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldSymbolsCount);
                attr.Value = this.SymbolsCount.Value.ToString();
                xmlNode.Attributes.Append(attr);
            }
        }

        protected override void LoadTypeAttributes(XmlNode xmlNode)
        {
            base.LoadTypeAttributes(xmlNode);

            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldTestType];

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                this.testType = (TrainTypeStepanovAndRecentMemory)Enum.Parse(typeof(TrainTypeStepanovAndRecentMemory), attr.Value);
            }

            attr = xmlNode.Attributes[xmlFieldSymbolsCount];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                int temp;
                if (int.TryParse(attr.Value, out temp))
                {
                    this.SymbolsCount = temp;
                }
            }
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ExerciseTypeStepanovAndRecentMemory) || !base.Equals(obj))
            {
                return false;
            }

            ExerciseTypeStepanovAndRecentMemory target = (ExerciseTypeStepanovAndRecentMemory)obj;

            return this.testType == target.testType && this.SymbolsCount == target.SymbolsCount;
        }

    }
}
