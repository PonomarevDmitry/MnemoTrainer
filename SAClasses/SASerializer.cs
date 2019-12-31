using System.IO;
using System.Xml;

namespace SAClasses
{
    public static class SASerializer
    {
        private const string xmlNodeNameSA = "SA";
        private const string xmlNodeNameSABlock = "SABlock";

        private const string xmlNodeNameSABlockPart = "SABlockPart";
        private const string xmlNodeNameSABlockPartCollection = "BlockParts";

        private const string xmlNodeNamePoem = "Poem";
        private const string xmlNodeNamePoemCollection = "Poems";

        private const string xmlNodeNamePoemPart = "PoemPart";
        private const string objNamePoemPartCollection = "PoemParts";

        private const string xmlNodeNamePoemLine = "PoemLine";
        private const string xmlNodeNamePoemLineCollection = "Lines";

        private const string xmlFieldName = "Name";
        private const string xmlFieldAuthor = "Author";

        #region Сериализация.

        public static void CreateSAFile(string fileName, SA sa)
        {
            XmlDocument saXmlFile = new XmlDocument();

            saXmlFile.AppendChild(saXmlFile.CreateXmlDeclaration("1.0", "utf-8", "yes"));

            XmlNode root = CreateSANode(sa, saXmlFile);
            saXmlFile.AppendChild(root);

            foreach (SABlock item in sa.Blocks)
            {
                XmlNode node = CreateBlockNode(item, saXmlFile);

                root.AppendChild(node);
            }

            saXmlFile.Save(fileName);
        }

        private static XmlNode CreateSANode(SA sa, XmlDocument saXmlFile)
        {
            XmlNode result = saXmlFile.CreateElement(xmlNodeNameSA);

            XmlAttribute attr;

            attr = saXmlFile.CreateAttribute(xmlFieldName);
            result.Attributes.Append(attr);
            attr.Value = sa.Name;

            return result;
        }

        private static XmlNode CreateBlockNode(SABlock block, XmlDocument saXmlFile)
        {
            XmlNode result = saXmlFile.CreateElement(xmlNodeNameSABlock);

            XmlAttribute attr;

            attr = saXmlFile.CreateAttribute(xmlFieldName);
            result.Attributes.Append(attr);
            attr.Value = block.Name;

            attr = saXmlFile.CreateAttribute(xmlFieldAuthor);
            result.Attributes.Append(attr);
            attr.Value = block.Author;

            if (block.Parts.Count > 0)
            {
                XmlNode nodeParts = saXmlFile.CreateElement(xmlNodeNameSABlockPartCollection);
                result.AppendChild(nodeParts);

                foreach (SABlockPart part in block.Parts)
                {
                    XmlNode node = CreateBlockPartNode(part, saXmlFile);

                    nodeParts.AppendChild(node);
                }
            }
            else if (block.Poems.Count > 0)
            {
                XmlNode nodePoems = saXmlFile.CreateElement(xmlNodeNamePoemCollection);
                result.AppendChild(nodePoems);

                foreach (Poem poem in block.Poems)
                {
                    XmlNode node = CreatePoemNode(poem, saXmlFile);

                    nodePoems.AppendChild(node);
                }
            }

            return result;
        }

        private static XmlNode CreateBlockPartNode(SABlockPart part, XmlDocument saXmlFile)
        {
            XmlNode result = saXmlFile.CreateElement(xmlNodeNameSABlockPart);

            XmlAttribute attr;

            attr = saXmlFile.CreateAttribute(xmlFieldName);
            result.Attributes.Append(attr);
            attr.Value = part.Name;

            XmlNode nodePoems = saXmlFile.CreateElement(xmlNodeNamePoemCollection);
            result.AppendChild(nodePoems);

            foreach (Poem poem in part.Poems)
            {
                XmlNode node = CreatePoemNode(poem, saXmlFile);

                nodePoems.AppendChild(node);
            }

            return result;
        }

        private static XmlNode CreatePoemNode(Poem poem, XmlDocument saXmlFile)
        {
            XmlNode result = saXmlFile.CreateElement(xmlNodeNamePoem);

            XmlAttribute attr;

            attr = saXmlFile.CreateAttribute(xmlFieldName);
            result.Attributes.Append(attr);
            attr.Value = poem.Name;

            if (poem.Parts.Count > 0)
            {
                XmlNode nodeParts = saXmlFile.CreateElement(objNamePoemPartCollection);
                result.AppendChild(nodeParts);

                foreach (PoemPart part in poem.Parts)
                {
                    XmlNode node = CreatePoemPartNode(part, saXmlFile);

                    nodeParts.AppendChild(node);
                }
            }
            else if (poem.Lines.Count > 0)
            {
                XmlNode nodeLines = saXmlFile.CreateElement(xmlNodeNamePoemLineCollection);
                result.AppendChild(nodeLines);

                foreach (PoemLine poemLine in poem.Lines)
                {
                    XmlNode node = CreatePoemLineNode(poemLine, saXmlFile);

                    nodeLines.AppendChild(node);
                }
            }

            return result;
        }

        private static XmlNode CreatePoemPartNode(PoemPart part, XmlDocument saXmlFile)
        {
            XmlNode result = saXmlFile.CreateElement(xmlNodeNamePoemPart);

            XmlAttribute attr;

            attr = saXmlFile.CreateAttribute(xmlFieldName);
            result.Attributes.Append(attr);
            attr.Value = part.Name;

            XmlNode nodeLines = saXmlFile.CreateElement(xmlNodeNamePoemLineCollection);
            result.AppendChild(nodeLines);

            foreach (PoemLine poemLine in part.Lines)
            {
                XmlNode node = CreatePoemLineNode(poemLine, saXmlFile);

                nodeLines.AppendChild(node);
            }

            return result;
        }

        private static XmlNode CreatePoemLineNode(PoemLine poemLine, XmlDocument saXmlFile)
        {
            XmlNode result = saXmlFile.CreateElement(xmlNodeNamePoemLine);

            result.InnerText = poemLine.Line;

            return result;
        }

        #endregion Сериализация.

        #region Десериализация.

        public static SA CreateSAFromXml(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            SA result = new SA();

            XmlDocument saXmlFile = new XmlDocument();
            saXmlFile.Load(fileName);

            XmlNode node = saXmlFile[xmlNodeNameSA];

            if (node != null)
            {
                XmlAttribute attr;

                attr = node.Attributes[xmlFieldName];
                if (attr != null)
                {
                    result.Name = attr.Value;

                    foreach (XmlNode item in node.ChildNodes)
                    {
                        SABlock block = CreateBlockFromXml(item);

                        result.Blocks.Add(block);
                    }
                }
            }

            return result;
        }

        private static SABlock CreateBlockFromXml(XmlNode node)
        {
            SABlock result = new SABlock();

            XmlAttribute attr;

            attr = node.Attributes[xmlFieldName];
            if (attr != null)
            {
                result.Name = attr.Value;
            }

            attr = node.Attributes[xmlFieldAuthor];
            if (attr != null)
            {
                result.Author = attr.Value;
            }

            XmlNode nodeParts = node[xmlNodeNameSABlockPartCollection];
            if (nodeParts != null)
            {
                foreach (XmlNode itemPart in nodeParts)
                {
                    SABlockPart part = CreateBlockPartFromXml(itemPart);

                    result.Parts.Add(part);
                }
            }
            else
            {
                XmlNode nodePoems = node[xmlNodeNamePoemCollection];
                if (nodePoems != null)
                {
                    foreach (XmlNode itemPoem in nodePoems)
                    {
                        Poem poem = CreatePoemFromXml(itemPoem);

                        result.Poems.Add(poem);
                    }
                }
            }

            return result;
        }

        private static SABlockPart CreateBlockPartFromXml(XmlNode itemPart)
        {
            SABlockPart result = new SABlockPart();

            XmlAttribute attr;

            attr = itemPart.Attributes[xmlFieldName];
            if (attr != null)
            {
                result.Name = attr.Value;
            }

            XmlNode nodePoems = itemPart[xmlNodeNamePoemCollection];
            if (nodePoems != null)
            {
                foreach (XmlNode itemPoem in nodePoems)
                {
                    Poem poem = CreatePoemFromXml(itemPoem);

                    result.Poems.Add(poem);
                }
            }

            return result;
        }

        private static Poem CreatePoemFromXml(XmlNode itemPoem)
        {
            Poem result = new Poem();

            XmlAttribute attr;

            attr = itemPoem.Attributes[xmlFieldName];
            if (attr != null)
            {
                result.Name = attr.Value;
            }

            XmlNode nodeParts = itemPoem[objNamePoemPartCollection];
            if (nodeParts != null)
            {
                foreach (XmlNode itemPart in nodeParts)
                {
                    PoemPart poemPart = CreatePoemPartFromXml(itemPart);

                    result.Parts.Add(poemPart);
                }
            }
            else
            {
                XmlNode nodeLines = itemPoem[xmlNodeNamePoemLineCollection];
                if (nodeLines != null)
                {
                    foreach (XmlNode itemLine in nodeLines)
                    {
                        PoemLine poemLine = CreatePoemLineFromXml(itemLine);

                        result.Lines.Add(poemLine);
                    }
                }
            }

            return result;
        }

        private static PoemPart CreatePoemPartFromXml(XmlNode itemPart)
        {
            PoemPart result = new PoemPart();

            XmlAttribute attr;

            attr = itemPart.Attributes[xmlFieldName];
            if (attr != null)
            {
                result.Name = attr.Value;
            }

            XmlNode nodePoems = itemPart[xmlNodeNamePoemLineCollection];
            if (nodePoems != null)
            {
                foreach (XmlNode itemPoem in nodePoems)
                {
                    PoemLine lines = CreatePoemLineFromXml(itemPoem);

                    result.Lines.Add(lines);
                }
            }

            return result;
        }

        private static PoemLine CreatePoemLineFromXml(XmlNode itemLine)
        {
            return new PoemLine(itemLine.InnerText);
        }

        #endregion Десериализация.
    }
}
