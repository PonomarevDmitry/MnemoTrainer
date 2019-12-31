using System.Drawing;

namespace MnemoTrainerLibrary.Classes
{
    public class NetUnit
    {
        public string Number { get; private set; }
        public string Pattern { get; private set; }
        public string NetName { get; private set; }

        public Color? PatternColor { get; private set; }

        public NetUnit(string number, string pattern, string netName)
        {
            this.Number = number;
            this.Pattern = pattern;
            this.NetName = netName;
        }

        public NetUnit(string number, string pattern, string netName, Color? patternColor)
            : this(number, pattern, netName)
        {
            this.PatternColor = patternColor;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Pattern) && !string.IsNullOrEmpty(NetName))
            {
                return string.Format("{0} - {1} из {2}", Number.ToString(), Pattern, NetName);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
