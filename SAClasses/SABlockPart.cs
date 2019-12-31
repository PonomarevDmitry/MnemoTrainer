using SAClasses.Collections;

namespace SAClasses
{
    public class SABlockPart
    {
        private string name = string.Empty;
        public string Name { get { return this.name; } set { this.name = value; } }

        private SABlock parentBlock;
        public SABlock ParentBlock
        {
            get { return this.parentBlock; }
            set
            {
                if (this.parentBlock != value)
                {
                    if (this.parentBlock != null)
                    {
                        this.parentBlock.Parts.Remove(this);
                    }

                    this.parentBlock = value;
                    if (this.parentBlock != null)
                    {
                        this.parentBlock.Parts.Add(this);
                    }
                }
            }
        }

        public PoemCollection Poems { get; private set; }

        public SABlockPart()
        {
            this.Poems = new PoemCollection(this);
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return this.Name;
            }
            else
            {
                return base.ToString();
            }
        }

        public bool HasContent
        {
            get { return this.Poems.Count > 0; }
        }

        internal PoemLine GetFirstLine()
        {
            if (this.Poems.Count > 0)
            {
                return this.Poems[0].GetFirstLine();
            }

            return null;
        }

        internal PoemLine GetLastLine()
        {
            if (this.Poems.Count > 0)
            {
                return this.Poems[this.Poems.Count - 1].GetLastLine();
            }

            return null;
        }

        public int LinesCount
        {
            get
            {
                int result = 0;

                foreach (Poem item in this.Poems)
                {
                    result += item.LinesCount;
                }

                return result;
            }
        }

        public int PoemCount
        {
            get
            {
                return this.Poems.Count;
            }
        }

        internal PoemLine GetLineByIndex(int randomIndex)
        {
            int indexPoem = 0;

            while (randomIndex >= this.Poems[indexPoem].LinesCount)
            {
                randomIndex -= this.Poems[indexPoem].LinesCount;
                indexPoem++;
            }

            return this.Poems[indexPoem].GetLineByIndex(randomIndex);
        }

        internal Poem GetPoemByIndex(int randomPoemIndex)
        {
            return this.Poems[randomPoemIndex];
        }

        internal Poem GetFirstPoem()
        {
            if (this.Poems.Count > 0)
            {
                return this.Poems[0];
            }

            return null;
        }

        internal Poem GetLastPoem()
        {
            if (this.Poems.Count > 0)
            {
                return this.Poems[this.Poems.Count - 1];
            }

            return null;
        }

        internal bool IsFirstLine(PoemLine line)
        {
            return this.GetFirstLine() == line;
        }
    }
}