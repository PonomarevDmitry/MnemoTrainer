using System.Collections.ObjectModel;
using System.IO;
using System.Xml;

namespace MnemoTrainerLibrary.Classes
{
    public class ClosedList
    {
        public string Name { get; private set; }

        private Collection<string> words = new Collection<string>();
        public Collection<string> Words { get { return words; } }

        public ClosedList(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }

        #region Сериализация.

        public static ClosedList CreateFromXmlNode(XmlNode xmlNode)
        {
            string netName = xmlNode.Attributes["Name"].Value;

            ClosedList result = new ClosedList(netName);

            XmlAttribute attr;

            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                XmlNode node = xmlNode.ChildNodes[i];

                attr = node.Attributes["Word"];

                if (attr != null && !string.IsNullOrEmpty(attr.Value))
                {
                    result.words.Add(attr.Value);
                }
            }

            return result;
        }

        #endregion Сериализация.

        public static ReadOnlyCollection<ClosedList> ClosedLists;

        private static readonly string listsFile = Path.Combine(Config.LocalSettingFolder, "Списки.lst");

        static ClosedList()
        {
            Collection<ClosedList> coll = new Collection<ClosedList>();

            if (File.Exists(listsFile))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(listsFile);

                XmlElement root = doc.DocumentElement;

                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    coll.Add(ClosedList.CreateFromXmlNode(root.ChildNodes[i]));
                }
            }

            ClosedLists = new ReadOnlyCollection<ClosedList>(coll);
        }
    }
}
