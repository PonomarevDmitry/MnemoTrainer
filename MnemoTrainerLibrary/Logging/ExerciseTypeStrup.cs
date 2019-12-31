using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Тип теста Струпа.
    /// </summary>
    public class ExerciseTypeStrup : ExerciseType
    {
        public bool AutoShowingMode { get; set; }

        public ExerciseTypeStrup()
        {
            this.type = TrainType.Strup;
        }

        public override string GetDescription()
        {
            string result = "Тест Струпа";

            if (this.AutoShowingMode)
            {
                result += string.Format(", автоматическое отображение вопроса каждые {0} мс", this.ShowTime.Value.ToString());
            }

            result += ".";

            return result;
        }

        private const string xmlFieldAutoShowingMode = "AutoShowingMode";

        internal override void SaveTypeAttributes(XmlNode xmlNode)
        {
            base.SaveTypeAttributes(xmlNode);

            XmlAttribute attr;

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
            if (obj == null || !(obj is ExerciseTypeStrup))
            {
                return false;
            }

            ExerciseTypeStrup target = (ExerciseTypeStrup)obj;

            if (this.AutoShowingMode == target.AutoShowingMode)
            {
                if (this.AutoShowingMode)
                {
                    return this.ShowTime == target.ShowTime;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
