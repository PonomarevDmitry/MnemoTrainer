using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Тип генератора чисел.
    /// </summary>
    public class ExerciseTypeNumberGenerator : ExerciseType
    {
        /// <summary>
        /// Количество слагаемых.
        /// </summary>
        public int? SymbolsCount { get; set; }

        public bool AutoShowingMode { get; set; }

        public ExerciseTypeNumberGenerator()
        {
            this.type = TrainType.NumberGenerator;
        }

        public override string GetDescription()
        {
            string result = string.Format("Тренировка по запоминанию чисел из {0} цифр", this.SymbolsCount.Value.ToString());

            if (this.AutoShowingMode)
            {
                result += string.Format(", автоматическое отображение чисел каждые {0} мс", this.ShowTime.Value.ToString());
            }
            else
            {
                result += string.Format(", вопрос отображается {0} мс", this.ShowTime.Value.ToString());

                if (this.AutoAnswerCheckTime.HasValue)
                {
                    result += string.Format(", на ответ дается {0} мс", this.AutoAnswerCheckTime.Value.ToString());
                }
            }

            result += ".";

            return result;
        }

        private const string xmlFieldSymbolsCount = "SymbolsCount";
        private const string xmlFieldAutoShowingMode = "AutoShowingMode";

        internal override void SaveTypeAttributes(XmlNode xmlNode)
        {
            base.SaveTypeAttributes(xmlNode);

            XmlAttribute attr;

            if (this.SymbolsCount.HasValue)
            {
                attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldSymbolsCount);
                attr.Value = this.SymbolsCount.Value.ToString();
                xmlNode.Attributes.Append(attr);
            }

            if (this.AutoShowingMode)
            {
                attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldAutoShowingMode);
                attr.Value = this.AutoShowingMode.ToString();
                xmlNode.Attributes.Append(attr);
            }
        }

        protected override void LoadTypeAttributes(XmlNode xmlNode)
        {
            base.LoadTypeAttributes(xmlNode);

            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldSymbolsCount];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                int temp;
                if (int.TryParse(attr.Value, out temp))
                {
                    this.SymbolsCount = temp;
                }
            }

            attr = xmlNode.Attributes[xmlFieldAutoShowingMode];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                bool temp;
                if (bool.TryParse(attr.Value, out temp))
                {
                    this.AutoShowingMode = temp;
                }
            }
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ExerciseTypeNumberGenerator))
            {
                return false;
            }

            ExerciseTypeNumberGenerator target = (ExerciseTypeNumberGenerator)obj;

            if (this.AutoShowingMode == target.AutoShowingMode && this.SymbolsCount == target.SymbolsCount)
            {
                if (this.AutoShowingMode)
                {
                    return this.ShowTime == target.ShowTime;
                }
                else
                {
                    return base.Equals(obj);
                }
            }

            return false;
        }
    }
}
