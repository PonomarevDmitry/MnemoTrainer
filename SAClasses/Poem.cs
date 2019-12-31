using SAClasses.Collections;

namespace SAClasses
{
    public class Poem
    {
        #region Атрибуты.

        private string name = string.Empty;
        public string Name { get { return this.name; } set { this.name = value; } }

        private SABlock parentBlock;
        public SABlock ParentBlock
        {
            get
            {
                if (this.parentBlockPart != null)
                {
                    return this.parentBlockPart.ParentBlock;
                }

                return this.parentBlock;
            }

            internal set
            {
                if (this.parentBlockPart == null)
                {
                    if (this.parentBlock != value)
                    {
                        if (this.parentBlock != null)
                        {
                            this.parentBlock.Poems.Remove(this);
                        }

                        this.parentBlock = value;
                        if (this.parentBlock != null)
                        {
                            this.parentBlock.Poems.Add(this);
                        }
                    }
                }
            }
        }

        private SABlockPart parentBlockPart;
        public SABlockPart ParentBlockPart
        {
            get { return this.parentBlockPart; }

            internal set
            {
                if (this.parentBlockPart != value)
                {
                    if (this.parentBlockPart != null)
                    {
                        this.parentBlockPart.Poems.Remove(this);
                    }

                    this.parentBlockPart = value;
                    if (this.parentBlockPart != null)
                    {
                        this.parentBlockPart.Poems.Add(this);
                    }
                }
            }
        }

        public PoemPartCollection Parts { get; private set; }

        public PoemLinesCollection Lines { get; private set; }

        #endregion Атрибуты.

        public Poem()
        {
            this.Parts = new PoemPartCollection(this);
            this.Lines = new PoemLinesCollection(this);
        }

        #region Методы.

        internal PoemLine GetFirstLine()
        {
            if (this.Parts.Count > 0)
            {
                return this.Parts[0].GetFirstLine();
            }
            else if (this.Lines.Count > 0)
            {
                return this.Lines[0];
            }

            return null;
        }

        internal PoemLine GetLastLine()
        {
            if (this.Parts.Count > 0)
            {
                return this.Parts[this.Parts.Count - 1].GetLastLine();
            }
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

            PoemLine line = null;
            if (this.Lines.Count > 0)
            {
                line = this.Lines[0];
            }
            else if (this.Parts.Count > 0 && this.Parts[0].Lines.Count > 0)
            {
                line = this.Parts[0].Lines[0];
            }

            if (line != null)
            {
                result += (!string.IsNullOrEmpty(result) ? " - " : string.Empty) + line.ToString();
            }

            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }
            else
            {
                return base.ToString();
            }
        }

        #endregion Методы.

        public int LinesCount
        {
            get
            {
                int result = 0;

                if (this.Parts.Count > 0)
                {
                    foreach (PoemPart item in this.Parts)
                    {
                        result += item.LinesCount;
                    }
                }
                else
                {
                    result += this.Lines.Count;
                }

                return result;
            }
        }

        internal PoemLine GetLineByIndex(int randomIndex)
        {
            if (this.Parts.Count > 0)
            {
                int indexPart = 0;

                while (randomIndex >= this.Parts[indexPart].LinesCount)
                {
                    randomIndex -= this.Parts[indexPart].LinesCount;
                    indexPart++;
                }

                return this.Parts[indexPart].GetLineByIndex(randomIndex);
            }
            else
            {
                return this.Lines[randomIndex];
            }
        }

        internal bool IsFirstLine(PoemLine line)
        {
            return this.GetFirstLine() == line;
        }

        internal PoemPart[] GetPartsByFirstLine(string firstLine)
        {
            int count = 0;

            foreach (PoemPart item in this.Parts)
            {
                string itemFirstLine = item.GetFirstLine().Line;

                if (string.Compare(itemFirstLine, firstLine, true) == 0)
                {
                    count++;
                }
            }

            PoemPart[] result = new PoemPart[count];

            count = 0;

            foreach (PoemPart item in this.Parts)
            {
                string itemFirstLine = item.GetFirstLine().Line;

                if (string.Compare(itemFirstLine, firstLine, true) == 0)
                {
                    result[count] = item;
                    count++;
                }
            }

            return result;
        }
    }
}
