using System.Collections.ObjectModel;
using System.Text;
using System.Xml;

namespace MnemoTrainerLibrary.Classes
{
    public class AssociationQuestion
    {
        public int Number { get; set; }
        public int ShowPosition { get; set; }

        private Collection<AssociationQuestionPart> questionSerie = new Collection<AssociationQuestionPart>();
        public Collection<AssociationQuestionPart> QuestionSerie { get { return this.questionSerie; } }

        public double Time { get; set; }

        public string Question
        {
            get
            {
                StringBuilder result = new StringBuilder();

                foreach (AssociationQuestionPart part in questionSerie)
                {
                    if (result.Length > 0)
                    {
                        result.Append(" - ");
                    }

                    result.Append(part.Word);
                }

                return result.ToString();
            }
        }

        public string NetName
        {
            get
            {
                string result = string.Empty;

                if (this.questionSerie.Count > 0)
                {
                    result = this.questionSerie[0].NetName;
                }

                return result;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0}.  {1}", this.Number.ToString(), this.Question);

            if (!string.IsNullOrEmpty(this.NetName))
            {
                result.AppendFormat("  -  {0}", this.NetName);
            }

            return result.ToString();
        }

        public string ToString(string format)
        {
            string result = string.Format("{0}.  {1}", this.Number.ToString(format), this.Question);

            return result;
        }

        public string ToStringColumn()
        {
            StringBuilder result = new StringBuilder();

            foreach (AssociationQuestionPart item in this.questionSerie)
            {
                if (result.Length > 0)
                {
                    result.AppendLine();
                }

                result.Append(item.Word);
            }

            return result.ToString();
        }

        #region Сохранение в xml.

        private const string xmlNodeNameAssociationQuestion = "AssociationQuestion";

        private const string xmlFieldQuestion = "Question";

        private const string xmlFieldNumber = "Number";
        private const string xmlFieldShowPosition = "ShowPosition";
        private const string xmlFieldTime = "Time";
        private const string xmlFieldWordCount = "WordCount";

        public virtual XmlNode CreateXmlNode(XmlDocument doc)
        {
            XmlNode result = doc.CreateElement(xmlNodeNameAssociationQuestion);

            XmlAttribute attr;

            attr = doc.CreateAttribute(xmlFieldNumber);
            attr.Value = this.Number.ToString();
            result.Attributes.Append(attr);

            attr = doc.CreateAttribute(xmlFieldShowPosition);
            attr.Value = this.ShowPosition.ToString();
            result.Attributes.Append(attr);

            attr = doc.CreateAttribute(xmlFieldTime);
            attr.Value = this.Time.ToString();
            result.Attributes.Append(attr);

            if (this.questionSerie.Count > 0)
            {
                attr = doc.CreateAttribute(xmlFieldWordCount);
                attr.Value = this.questionSerie.Count.ToString();
                result.Attributes.Append(attr);

                foreach (AssociationQuestionPart item in this.questionSerie)
                {
                    result.AppendChild(item.CreateXmlNode(doc));
                }
            }

            return result;
        }

        public static AssociationQuestion CreateFromXml(XmlNode xmlNode)
        {
            AssociationQuestion result = new AssociationQuestion();

            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldQuestion];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                result.questionSerie.Add(new AssociationQuestionPart(attr.Value));
            }

            attr = xmlNode.Attributes[xmlFieldNumber];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                int temp;
                if (int.TryParse(attr.Value, out temp))
                {
                    result.Number = temp;
                }
            }

            attr = xmlNode.Attributes[xmlFieldShowPosition];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                int temp;
                if (int.TryParse(attr.Value, out temp))
                {
                    result.ShowPosition = temp;
                }
            }

            attr = xmlNode.Attributes[xmlFieldTime];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                double temp;
                if (double.TryParse(attr.Value, out temp))
                {
                    result.Time = temp;
                }
            }

            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                result.questionSerie.Add(AssociationQuestionPart.CreateFromXml(node));
            }

            return result;
        }

        #endregion Сохранение в xml.
    }
}
