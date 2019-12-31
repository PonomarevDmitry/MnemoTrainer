using SAClasses.Collections;

namespace SAClasses
{
    public class PoemPart
    {
        private string name = string.Empty;
        public string Name { get { return this.name; } set { this.name = value; } }

        private Poem parentPoem;
        public Poem ParentPoem
        {
            get { return this.parentPoem; }
            internal set
            {
                if (this.parentPoem != value)
                {
                    if (this.parentPoem != null)
                    {
                        this.parentPoem.Parts.Remove(this);
                    }

                    this.parentPoem = value;
                    if (this.parentPoem != null)
                    {
                        this.parentPoem.Parts.Add(this);
                    }
                }
            }
        }

        public PoemLinesCollection Lines { get; private set; }

        public PoemPart()
        {
            this.Lines = new PoemLinesCollection(this);
        }

        internal PoemLine GetFirstLine()
        {
            if (this.Lines.Count > 0)
            {
                return this.Lines[0];
            }

            return null;
        }

        internal PoemLine GetLastLine()
        {
            if (this.Lines.Count > 0)
            {
                return this.Lines[this.Lines.Count - 1];
            }

            return null;
        }

        public override string ToString()
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(this.Name))
            {
                result = this.Name;
            }

            if (this.Lines.Count > 0)
            {
                result += (!string.IsNullOrEmpty(result) ? " - " : string.Empty) + this.Lines[0].ToString();
            }

            return result;
        }

        public int LinesCount
        {
            get
            {
                return this.Lines.Count;
            }
        }

        internal PoemLine GetLineByIndex(int randomIndex)
        {
            return this.Lines[randomIndex];
        }

        internal bool IsFirstLine(PoemLine line)
        {
            return this.GetFirstLine() == line;
        }
    }
}
