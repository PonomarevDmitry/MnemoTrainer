using SAClasses.Collections;

namespace SAClasses
{
    public class SABlock
    {
        #region Атрибуты.

        private string name = string.Empty;
        public string Name { get { return this.name; } set { this.name = value; } }

        private string author = string.Empty;
        public string Author { get { return this.author; } set { this.author = value; } }

        public int Rank { get; set; }

        private SA parentSA;
        public SA ParentSA
        {
            get { return this.parentSA; }
            set
            {
                if (this.parentSA != value)
                {
                    if (this.parentSA != null)
                    {
                        this.parentSA.Blocks.Remove(this);
                    }

                    this.parentSA = value;
                    if (this.parentSA != null)
                    {
                        this.parentSA.Blocks.Add(this);
                    }
                }
            }
        }

        public BlockPartCollection Parts { get; private set; }

        public PoemCollection Poems { get; private set; }

        #endregion Атрибуты.

        public SABlock()
        {
            this.Parts = new BlockPartCollection(this);
            this.Poems = new PoemCollection(this);
        }

        public bool HasContent
        {
            get
            {
                if (this.Poems.Count > 0)
                {
                    return true;
                }

                foreach (SABlockPart item in this.Parts)
                {
                    if (item.HasContent)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public override string ToString()
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(this.author))
            {
                result = this.author + ". ";
            }

            result += this.name;

            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }
            else
            {
                return base.ToString();
            }
        }

        internal PoemLine GetFirstLine()
        {
            if (this.Parts.Count > 0)
            {
                return this.Parts[0].GetFirstLine();
            }
            else if (this.Poems.Count > 0)
            {
                return this.Poems[0].GetFirstLine();
            }

            return null;
        }

        internal PoemLine GetLastLine()
        {
            if (this.Parts.Count > 0)
            {
                return this.Parts[this.Parts.Count - 1].GetLastLine();
            }
            else if (this.Poems.Count > 0)
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

                if (this.Parts.Count > 0)
                {
                    foreach (SABlockPart item in this.Parts)
                    {
                        result += item.LinesCount;
                    }
                }
                else
                {
                    foreach (Poem item in this.Poems)
                    {
                        result += item.LinesCount;
                    }
                }

                return result;
            }
        }

        public int PoemCount
        {
            get
            {
                int result = 0;

                if (this.Parts.Count > 0)
                {
                    foreach (SABlockPart item in this.Parts)
                    {
                        result += item.PoemCount;
                    }
                }
                else
                {
                    result = this.Poems.Count;
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
                int indexPoem = 0;

                while (randomIndex >= this.Poems[indexPoem].LinesCount)
                {
                    randomIndex -= this.Poems[indexPoem].LinesCount;
                    indexPoem++;
                }

                return this.Poems[indexPoem].GetLineByIndex(randomIndex);
            }
        }

        internal Poem GetPoemByIndex(int randomPoemIndex)
        {
            if (this.Parts.Count > 0)
            {
                int indexPart = 0;

                while (randomPoemIndex >= this.Parts[indexPart].PoemCount)
                {
                    randomPoemIndex -= this.Parts[indexPart].PoemCount;
                    indexPart++;
                }

                return this.Parts[indexPart].GetPoemByIndex(randomPoemIndex);
            }
            else
            {
                return this.Poems[randomPoemIndex];
            }
        }

        internal Poem GetFirstPoem()
        {
            if (this.Parts.Count > 0)
            {
                return this.Parts[0].GetFirstPoem();
            }
            else if (this.Poems.Count > 0)
            {
                return this.Poems[0];
            }

            return null;
        }

        internal Poem GetLastPoem()
        {
            if (this.Parts.Count > 0)
            {
                return this.Parts[this.Parts.Count - 1].GetLastPoem();
            }
            else if (this.Poems.Count > 0)
            {
                return this.Poems[this.Poems.Count - 1];
            }

            return null;
        }

        internal bool IsFirstLine(PoemLine line)
        {
            return this.GetFirstLine() == line;
        }

        internal SABlockPart[] GetPartsByFirstLine(string firstLine)
        {
            int count = 0;

            foreach (SABlockPart item in this.Parts)
            {
                string itemFirstLine = item.GetFirstLine().Line;

                if (string.Compare(itemFirstLine, firstLine, true) == 0)
                {
                    count++;
                }
            }

            SABlockPart[] result = new SABlockPart[count];

            count = 0;

            foreach (SABlockPart item in this.Parts)
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
