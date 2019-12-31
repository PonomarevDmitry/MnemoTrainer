using System.Xml;

namespace SAClasses
{
    public class PoemLineIdentifier
    {
        #region Константы.

        private const string objName = "PoemLineIdentifier";

        private const string attrBlockName = "BlockName";
        private const string attrBlockIndex = "BlockIndex";

        private const string attrBlockPartName = "BlockPartName";
        private const string attrBlockPartFirstLine = "BlockPartFirstLine";
        private const string attrBlockPartIndex = "BlockPartIndex";

        private const string attrPoemName = "PoemName";
        private const string attrPoemFirstLine = "PoemFirstLine";
        private const string attrPoemIndex = "PoemIndex";

        private const string attrPoemPartName = "PoemPartName";
        private const string attrPoemPartFirstLine = "PoemPartFirstLine";
        private const string attrPoemPartIndex = "PoemPartIndex";

        private const string attrLineString = "LineString";
        private const string attrLineIndex = "LineIndex";

        #endregion Константы.

        public string BlockName = string.Empty;
        public int? BlockIndex = null;

        public string BlockPartName = string.Empty;
        public string BlockPartFirstLine = string.Empty;
        public int? BlockPartIndex = null;

        public string PoemName = string.Empty;
        public string PoemFirstLine = string.Empty;
        public int? PoemIndex = null;

        public string PoemPartName = string.Empty;
        public string PoemPartFirstLine = string.Empty;
        public int? PoemPartIndex = null;

        public string LineString = string.Empty;
        public int? LineIndex = null;

        internal XmlNode CreateNode(XmlDocument xmlFile)
        {
            XmlNode result = xmlFile.CreateElement(objName);

            XmlAttribute attr;

            //atrBlockName
            //atrBlockIndex

            attr = xmlFile.CreateAttribute(attrBlockName);
            result.Attributes.Append(attr);
            attr.Value = this.BlockName;

            if (this.BlockIndex.HasValue)
            {
                attr = xmlFile.CreateAttribute(attrBlockIndex);
                result.Attributes.Append(attr);
                attr.Value = this.BlockIndex.Value.ToString();
            }

            //atrBlockPartName
            //atrBlockPartFirstLine
            //atrBlockPartIndex

            attr = xmlFile.CreateAttribute(attrBlockPartName);
            result.Attributes.Append(attr);
            attr.Value = this.BlockPartName;

            attr = xmlFile.CreateAttribute(attrBlockPartFirstLine);
            result.Attributes.Append(attr);
            attr.Value = this.BlockPartFirstLine;

            if (this.BlockPartIndex.HasValue)
            {
                attr = xmlFile.CreateAttribute(attrBlockPartIndex);
                result.Attributes.Append(attr);
                attr.Value = this.BlockPartIndex.Value.ToString();
            }

            //atrPoemName
            //atrPoemFirstLine
            //atrPoemIndex

            attr = xmlFile.CreateAttribute(attrPoemName);
            result.Attributes.Append(attr);
            attr.Value = this.PoemName;

            attr = xmlFile.CreateAttribute(attrPoemFirstLine);
            result.Attributes.Append(attr);
            attr.Value = this.PoemFirstLine;

            if (this.PoemIndex.HasValue)
            {
                attr = xmlFile.CreateAttribute(attrPoemIndex);
                result.Attributes.Append(attr);
                attr.Value = this.PoemIndex.Value.ToString();
            }

            //atrPoemPartName
            //atrPoemPartFirstLine 
            //atrPoemPartIndex

            attr = xmlFile.CreateAttribute(attrPoemPartName);
            result.Attributes.Append(attr);
            attr.Value = this.PoemPartName;

            attr = xmlFile.CreateAttribute(attrPoemPartFirstLine);
            result.Attributes.Append(attr);
            attr.Value = this.PoemPartFirstLine;

            if (this.PoemPartIndex.HasValue)
            {
                attr = xmlFile.CreateAttribute(attrPoemPartIndex);
                result.Attributes.Append(attr);
                attr.Value = this.PoemPartIndex.Value.ToString();
            }

            //atrLineString
            //atrLineIndex

            attr = xmlFile.CreateAttribute(attrLineString);
            result.Attributes.Append(attr);
            attr.Value = this.LineString;

            if (this.LineIndex.HasValue)
            {
                attr = xmlFile.CreateAttribute(attrLineIndex);
                result.Attributes.Append(attr);
                attr.Value = this.LineIndex.Value.ToString();
            }

            return result;
        }

        internal static PoemLineIdentifier CreateFromXmlNode(XmlNode node)
        {
            PoemLineIdentifier result = new PoemLineIdentifier();

            XmlAttribute attr;

            // Блок.
            attr = node.Attributes[attrBlockName];
            if (attr != null)
            {
                result.BlockName = attr.Value;
            }

            attr = node.Attributes[attrBlockIndex];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                int tempInt;
                if (int.TryParse(attr.Value, out tempInt))
                {
                    result.BlockIndex = tempInt;
                }
            }

            // Часть блока
            attr = node.Attributes[attrBlockPartName];
            if (attr != null)
            {
                result.BlockPartName = attr.Value;
            }

            attr = node.Attributes[attrBlockPartFirstLine];
            if (attr != null)
            {
                result.BlockPartFirstLine = attr.Value;
            }

            attr = node.Attributes[attrBlockPartIndex];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                int tempInt;
                if (int.TryParse(attr.Value, out tempInt))
                {
                    result.BlockPartIndex = tempInt;
                }
            }

            // Стих
            attr = node.Attributes[attrPoemName];
            if (attr != null)
            {
                result.PoemName = attr.Value;
            }

            attr = node.Attributes[attrPoemFirstLine];
            if (attr != null)
            {
                result.PoemFirstLine = attr.Value;
            }

            attr = node.Attributes[attrPoemIndex];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                int tempInt;
                if (int.TryParse(attr.Value, out tempInt))
                {
                    result.PoemIndex = tempInt;
                }
            }

            // Часть стиха
            attr = node.Attributes[attrPoemPartName];
            if (attr != null)
            {
                result.PoemPartName = attr.Value;
            }

            attr = node.Attributes[attrPoemPartFirstLine];
            if (attr != null)
            {
                result.PoemPartFirstLine = attr.Value;
            }

            attr = node.Attributes[attrPoemPartIndex];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                int tempInt;
                if (int.TryParse(attr.Value, out tempInt))
                {
                    result.PoemPartIndex = tempInt;
                }
            }

            // Строка
            attr = node.Attributes[attrLineString];
            if (attr != null)
            {
                result.LineString = attr.Value;
            }

            attr = node.Attributes[attrLineIndex];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                int tempInt;
                if (int.TryParse(attr.Value, out tempInt))
                {
                    result.LineIndex = tempInt;
                }
            }

            return result;
        }
    }
}
