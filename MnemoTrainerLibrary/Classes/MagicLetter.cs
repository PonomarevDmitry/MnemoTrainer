
namespace MnemoTrainerLibrary.Classes
{
    public class MagicLetter
    {
        public MagicLetter(string letter, string hand)
        {
            this.Letter = letter;
            this.Hand = hand;
        }

        public string Letter { get; private set; }
        public string Hand { get; private set; }

        public override string ToString()
        {
            return this.ToStringLine();
        }

        public string ToStringLine()
        {
            return string.Format("{0} - {1}", this.Letter, this.Hand);
        }

        public string ToStringColumn()
        {
            return string.Format("{0}\r\n{1}", this.Letter, this.Hand);
        }
    }
}
