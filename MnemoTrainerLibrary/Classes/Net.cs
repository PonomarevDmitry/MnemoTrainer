using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

namespace MnemoTrainerLibrary.Classes
{
    public class Net
    {
        #region Свойства.

        [DefaultValueAttribute("")]
        public string Name { get; set; }

        [DefaultValueAttribute(false)]
        public bool NumberAlphabet { get; set; }

        public Net(string name)
        {
            this.Name = name;
        }

        private Collection<NetUnit> units = new Collection<NetUnit>();
        public Collection<NetUnit> Units
        {
            get { return units; }
        }

        #endregion Свойства.

        #region Методы.

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                return Name;
            }
            else
            {
                return string.Empty;
            }
        }

        public bool HasRepeats(out string repeats)
        {
            bool result = false;

            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < this.units.Count; i++)
            {
                NetUnit unit1 = this.units[i];

                for (int j = i + 1; j < this.units.Count; j++)
                {
                    NetUnit unit2 = this.units[j];

                    //if (unit1.Number == unit2.Number)
                    //{
                    //    result = true;
                    //    repeats += (!string.IsNullOrEmpty(repeats) ? "\r\n" : string.Empty) + string.Format("{0} и {1} по номеру", unit1.Number, unit2.Number);
                    //}

                    if (string.Compare(unit1.Pattern, unit2.Pattern, true) == 0)
                    {
                        result = true;
                        if (strBuilder.Length > 0)
                        {
                            strBuilder.AppendLine();
                        }

                        strBuilder.AppendFormat("{0} и {1} это {2}", unit1.Number, unit2.Number, unit1.Pattern);
                    }
                }
            }

            repeats = strBuilder.ToString();

            return result;
        }

        #endregion Методы.

        #region Сериализация.

        private const string xmlNodeNameNet = "Net";
        private const string xmlNodeNameUnit = "Unit";

        private const string xmlFieldName = "Name";
        private const string xmlFieldNumber = "Number";
        private const string xmlFieldPattern = "Pattern";
        private const string xmlFieldColor = "Color";

        public XmlNode CreateNode(XmlDocument doc)
        {
            XmlNode result = doc.CreateElement(xmlNodeNameNet);

            XmlAttribute attr;

            attr = doc.CreateAttribute(xmlFieldName);
            result.Attributes.Append(attr);
            attr.Value = this.Name;

            for (int i = 0; i < this.units.Count; i++)
            {
                NetUnit unit = this.units[i];

                XmlNode node = doc.CreateElement(xmlNodeNameUnit);
                result.AppendChild(node);

                if (!string.IsNullOrEmpty(unit.Pattern))
                {
                    attr = doc.CreateAttribute(xmlFieldNumber);
                    node.Attributes.Append(attr);
                    attr.Value = unit.Number;

                    attr = doc.CreateAttribute(xmlFieldPattern);
                    node.Attributes.Append(attr);
                    attr.Value = unit.Pattern;

                    if (unit.PatternColor.HasValue)
                    {
                        attr = doc.CreateAttribute(xmlFieldColor);
                        node.Attributes.Append(attr);
                        attr.Value = unit.PatternColor.Value.ToKnownColor().ToString();
                    }
                }
            }

            return result;
        }

        private static Net CreateFromXmlNode(XmlNode xmlNode)
        {
            string netName = xmlNode.Attributes[xmlFieldName].Value;

            Net result = new Net(netName);

            result.NumberAlphabet = netName.ToLower() == "цифровой алфавит";

            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                XmlNode node = xmlNode.ChildNodes[i];

                XmlAttribute attrNumber = node.Attributes[xmlFieldNumber];
                XmlAttribute attrPattern = node.Attributes[xmlFieldPattern];

                if (attrNumber != null && attrPattern != null && !string.IsNullOrEmpty(attrNumber.Value) && !string.IsNullOrEmpty(attrPattern.Value))
                {
                    int temp = 0;

                    if (int.TryParse(attrNumber.Value, out temp))
                    {
                        NetUnit netUnit;

                        XmlAttribute attr = node.Attributes[xmlFieldColor];

                        if (attr != null && !string.IsNullOrEmpty(attr.Value))
                        {
                            netUnit = new NetUnit(attrNumber.Value, attrPattern.Value, netName, Color.FromName(attr.Value));
                        }
                        else
                        {
                            netUnit = new NetUnit(attrNumber.Value, attrPattern.Value, netName);
                        }

                        result.Units.Add(netUnit);
                    }
                }
            }

            return result;
        }

        #endregion Сериализация.

        #region Статические методы.

        /// <summary>
        /// Все сетки
        /// </summary>
        public static ReadOnlyCollection<Net> Nets { get; private set; }

        /// <summary>
        /// Сетки без цифровой и цветной
        /// </summary>
        public static ReadOnlyCollection<Net> FilteredNets { get; private set; }

        /// <summary>
        /// Статический конструктор
        /// </summary>
        static Net()
        {
            Collection<Net> ordinalNets = new Collection<Net>();
            Collection<Net> filtredNets = new Collection<Net>();

            string fileName = Net.NetsFileName;

            if (File.Exists(fileName))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);

                XmlElement root = doc.DocumentElement;

                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    Net newNet = Net.CreateFromXmlNode(root.ChildNodes[i]);

                    ordinalNets.Add(newNet);

                    if (string.Compare(newNet.Name, "цифровой алфавит", true) != 0
                        && string.Compare(newNet.Name, "цифровые цвета", true) != 0)
                    {
                        filtredNets.Add(newNet);
                    }
                }
            }

            Nets = new ReadOnlyCollection<Net>(ordinalNets);
            FilteredNets = new ReadOnlyCollection<Net>(filtredNets);
        }

        public static string NetsFileName
        {
            get
            {
                return Path.Combine(Config.LocalSettingFolder, "Сетки.nets"); ;
            }
        }

        public static bool HasIntersection(Net net1, Net net2, out string repeats)
        {
            bool result = false;

            StringBuilder strBuilder = new StringBuilder();

            foreach (NetUnit unit1 in net1.units)
            {
                foreach (NetUnit unit2 in net2.units)
                {
                    if (string.Compare(unit1.Pattern, unit2.Pattern, true) == 0)
                    {
                        result = true;
                        if (strBuilder.Length > 0)
                        {
                            strBuilder.AppendLine();
                        }

                        strBuilder.AppendFormat("{0} из {1} и {2} из {3} это {4}", unit1.Number, net1.Name, unit2.Number, net2.Name, unit1.Pattern);
                    }
                }
            }

            repeats = strBuilder.ToString();

            return result;
        }

        #endregion Статические методы.
    }
}
