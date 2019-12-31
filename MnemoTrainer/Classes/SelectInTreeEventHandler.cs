using SAClasses;

namespace MnemoTrainer
{
    public delegate void SelectInTreeEventHandler(object sender, SelectInTreeEventArgs e);

    public class SelectInTreeEventArgs
    {
        public PoemLine Line { get; private set; }

        public SelectInTreeEventArgs(PoemLine line)
        {
            this.Line = line;
        }
    }
}
