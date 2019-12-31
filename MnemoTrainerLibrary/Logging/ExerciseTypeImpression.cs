using System;
using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Тип тренировки зрительной памяти.
    /// </summary>
    public class ExerciseTypeImpression : ExerciseType
    {
        protected TrainTypeImpression testType = TrainTypeImpression.None;
        /// <summary>
        /// Внутренний тип упражнения.
        /// </summary>
        public TrainTypeImpression TestType { get { return testType; } set { this.testType = value; } }

        /// <summary>
        /// Количество слагаемых.
        /// </summary>
        public int? SymbolsCount { get; set; }

        /// <summary>
        /// С цветом.
        /// </summary>
        public bool WithColor { get; set; }

        /// <summary>
        /// Со случайным порядком букв.
        /// </summary>
        public bool WithRandomLiters { get; set; }

        public ExerciseTypeImpression()
        {
            this.type = TrainType.Impression;
        }

        public override string GetDescription()
        {
            string result = "Тренировка зрительной памяти";

            if (this.testType == TrainTypeImpression.Symbols)
            {
                result += string.Format(", подтип \"восприятие числа\" с {0} цифрами", this.SymbolsCount.Value.ToString());

                if (this.WithColor)
                {
                    result += " и цветом";
                }
            }
            else if (this.testType == TrainTypeImpression.Dictionary)
            {
                result += ", подтип \"мгновенное чтение слова\"{0}";

                result += this.WithRandomLiters ? " с перемешенными буквами" : string.Empty;
            }

            if (this.ShowTime.HasValue)
            {
                result += string.Format(", вопрос отображается {0} мс", this.ShowTime.Value.ToString());
            }

            result += ".";

            return result;
        }

        private const string xmlFieldTestType = "TestType";
        private const string xmlFieldSymbolsCount = "SymbolsCount";
        private const string xmlFieldWithColor = "WithColor";
        private const string xmlFieldWithRandomLiters = "WithRandomLiters";

        internal override void SaveTypeAttributes(XmlNode xmlNode)
        {
            base.SaveTypeAttributes(xmlNode);

            XmlAttribute attr;

            attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldTestType);
            attr.Value = this.testType.ToString();
            xmlNode.Attributes.Append(attr);

            if (this.testType == TrainTypeImpression.Symbols)
            {
                if (this.SymbolsCount.HasValue)
                {
                    attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldSymbolsCount);
                    attr.Value = this.SymbolsCount.Value.ToString();
                    xmlNode.Attributes.Append(attr);
                }

                if (this.WithColor)
                {
                    attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldWithColor);
                    attr.Value = this.WithColor.ToString();
                    xmlNode.Attributes.Append(attr);
                }
            }
            else if (this.testType == TrainTypeImpression.Dictionary)
            {
                attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldWithRandomLiters);
                attr.Value = this.WithRandomLiters.ToString();
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
                this.testType = (TrainTypeImpression)Enum.Parse(typeof(TrainTypeImpression), attr.Value);

                if (this.testType == TrainTypeImpression.Symbols)
                {
                    attr = xmlNode.Attributes[xmlFieldSymbolsCount];
                    if (attr != null && !string.IsNullOrEmpty(attr.Value))
                    {
                        int temp;
                        if (int.TryParse(attr.Value, out temp))
                        {
                            this.SymbolsCount = temp;
                        }
                    }

                    attr = xmlNode.Attributes[xmlFieldWithColor];
                    if (attr != null && !string.IsNullOrEmpty(attr.Value))
                    {
                        bool temp;
                        if (bool.TryParse(attr.Value, out temp))
                        {
                            this.WithColor = temp;
                        }
                    }
                }
                else if (this.testType == TrainTypeImpression.Dictionary)
                {
                    attr = xmlNode.Attributes[xmlFieldWithRandomLiters];
                    if (attr != null && !string.IsNullOrEmpty(attr.Value))
                    {
                        bool temp;
                        if (bool.TryParse(attr.Value, out temp))
                        {
                            this.WithRandomLiters = temp;
                        }
                    }
                }
            }
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ExerciseTypeImpression) || !base.Equals(obj))
            {
                return false;
            }

            ExerciseTypeImpression target = (ExerciseTypeImpression)obj;

            if (this.testType == target.testType)
            {
                if (this.testType == TrainTypeImpression.Dictionary)
                {
                    return this.WithRandomLiters == target.WithRandomLiters;
                }
                else if (this.testType == TrainTypeImpression.Symbols)
                {
                    return this.WithColor == target.WithColor && this.SymbolsCount == this.SymbolsCount;
                }
            }

            return false;
        }
    }
}
