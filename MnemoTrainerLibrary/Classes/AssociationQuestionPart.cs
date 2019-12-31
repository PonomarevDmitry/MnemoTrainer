using System.Xml;

namespace MnemoTrainerLibrary.Classes
{
    public class AssociationQuestionPart
    {
        public string Word { get; private set; }
        public string NetName { get; set; }

        private AssociationQuestionPart()
        {
            this.Word = string.Empty;
            this.NetName = string.Empty;
        }

        public AssociationQuestionPart(string word)
            : this()
        {
            this.Word = word;
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override bool Equals(object obj)
        {
            return obj != null && obj is AssociationQuestionPart && ((AssociationQuestionPart)obj).NetName == this.NetName && ((AssociationQuestionPart)obj).Word == this.Word;
        }

        public override string ToString()
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(this.Word))
            {
                result = this.Word;
            }

            if (!string.IsNullOrEmpty(this.NetName))
            {
                result += string.Format(" \"{0}\"", this.NetName);
            }

            return result;
        }

        #region Сохранение в xml.

        private const string xmlNodeName = "QuestionPart";
        private const string xmlFieldWord = "Word";
        private const string xmlFieldNetName = "NetName";

        public virtual XmlNode CreateXmlNode(XmlDocument doc)
        {
            XmlNode result = doc.CreateElement(xmlNodeName);

            XmlAttribute attr;

            if (!string.IsNullOrEmpty(this.Word))
            {
                attr = doc.CreateAttribute(xmlFieldWord);
                attr.Value = this.Word;
                result.Attributes.Append(attr);
            }

            if (!string.IsNullOrEmpty(this.NetName))
            {
                attr = doc.CreateAttribute(xmlFieldNetName);
                attr.Value = this.NetName;
                result.Attributes.Append(attr);
            }

            return result;
        }

        public static AssociationQuestionPart CreateFromXml(XmlNode xmlNode)
        {
            AssociationQuestionPart result = new AssociationQuestionPart();

            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldWord];
            if (attr != null)
            {
                result.Word = attr.Value;
            }

            attr = xmlNode.Attributes[xmlFieldNetName];
            if (attr != null)
            {
                result.NetName = attr.Value;
            }

            return result;
        }

        #endregion Сохранение в xml.
    }
}
