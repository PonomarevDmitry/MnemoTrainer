using System.Collections.ObjectModel;
using SAClasses.Collections;

namespace SAClasses
{
    public class SA
    {
        #region Свойства.

        private string name = string.Empty;
        public string Name { get { return this.name; } set { this.name = value; } }

        public BlockCollection Blocks { get; private set; }

        #endregion Свойства.

        public SA()
        {
            Blocks = new BlockCollection(this);
        }

        public override string ToString()
        {
            return this.Name;
        }

        public PoemLine GetFirstLine()
        {
            if (this.Blocks.Count > 0)
            {
                return this.Blocks[0].GetFirstLine();
            }

            return null;
        }

        public PoemLine GetLastLine()
        {
            if (this.Blocks.Count > 0)
            {
                return this.Blocks[this.Blocks.Count - 1].GetLastLine();
            }

            return null;
        }

        public int LinesCount
        {
            get
            {
                int result = 0;

                foreach (SABlock item in this.Blocks)
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
                int result = 0;

                foreach (SABlock item in this.Blocks)
                {

                    result += item.PoemCount;
                }

                return result;
            }
        }

        internal PoemLine GetLineByIndex(int randomIndex)
        {
            int indexBlock = 0;

            while (randomIndex >= this.Blocks[indexBlock].LinesCount)
            {
                randomIndex -= this.Blocks[indexBlock].LinesCount;
                indexBlock++;
            }

            return this.Blocks[indexBlock].GetLineByIndex(randomIndex);
        }

        internal Poem GetPoemByIndex(int randomPoemIndex)
        {
            int indexBlock = 0;

            while (randomPoemIndex >= this.Blocks[indexBlock].PoemCount)
            {
                randomPoemIndex -= this.Blocks[indexBlock].PoemCount;
                indexBlock++;
            }

            return this.Blocks[indexBlock].GetPoemByIndex(randomPoemIndex);
        }

        internal SABlock GetFirstBlock()
        {
            if (this.Blocks.Count > 0)
            {
                return this.Blocks[0];
            }

            return null;
        }

        internal SABlock GetLastBlock()
        {
            if (this.Blocks.Count > 0)
            {
                return this.Blocks[this.Blocks.Count - 1];
            }

            return null;
        }

        internal SABlock[] GetBlockByName(string name)
        {
            int count = 0;

            foreach (SABlock block in this.Blocks)
            {
                if (string.Compare(block.Name, name, true) == 0)
                {
                    count++;
                }
            }

            SABlock[] result = new SABlock[count];

            count = 0;

            foreach (SABlock block in this.Blocks)
            {
                if (string.Compare(block.Name, name, true) == 0)
                {
                    result[count] = block;
                    count++;
                }
            }

            return result;
        }

        public Collection<PoemLine> Find(string searchPattern)
        {
            Collection<PoemLine> result = new Collection<PoemLine>();

            foreach (SABlock block in this.Blocks)
            {
                foreach (SABlockPart blockPart in block.Parts)
                {
                    SearchInPoemCollection(searchPattern, blockPart.Poems, result);
                }

                SearchInPoemCollection(searchPattern, block.Poems, result);
            }

            return result;
        }

        private void SearchInPoemCollection(string searchPattern, PoemCollection poemColl, Collection<PoemLine> result)
        {
            foreach (Poem poem in poemColl)
            {
                foreach (PoemPart poemPart in poem.Parts)
                {
                    SearchInLineCollection(searchPattern, poemPart.Lines, result);
                }

                SearchInLineCollection(searchPattern, poem.Lines, result);
            }
        }

        private void SearchInLineCollection(string searchPattern, PoemLinesCollection poemLines, Collection<PoemLine> result)
        {
            foreach (PoemLine item in poemLines)
            {
                string line = item.Line;

                if (CommonOperations.MatchPattern(line, searchPattern))
                {
                    result.Add(item);
                }
            }
        }

        internal PoemLine GetLineByID(PoemLineIdentifier lineId)
        {
            SABlock block = null;

            if (!string.IsNullOrEmpty(lineId.BlockName))
            {
                SABlock[] searchBlocks = this.GetBlockByName(lineId.BlockName);

                if (searchBlocks.Length == 1)
                {
                    block = searchBlocks[0];
                }
                else if (searchBlocks.Length > 1)
                {
                    foreach (SABlock item in searchBlocks)
                    {
                        if (this.Blocks.IndexOf(item) == lineId.BlockIndex)
                        {
                            block = item;
                            break;
                        }
                    }
                }
            }

            if (block == null)
            {
                return null;
            }

            PoemCollection poemColl = null;

            if (!string.IsNullOrEmpty(lineId.BlockPartFirstLine) && lineId.BlockPartIndex.HasValue)
            {
                SABlockPart[] searchBlockParts = block.GetPartsByFirstLine(lineId.BlockPartFirstLine);

                if (searchBlockParts.Length == 1)
                {
                    poemColl = searchBlockParts[0].Poems;
                }
                else if (searchBlockParts.Length > 1)
                {
                    foreach (SABlockPart item in searchBlockParts)
                    {
                        if (block.Parts.IndexOf(item) == lineId.BlockPartIndex)
                        {
                            poemColl = item.Poems;
                            break;
                        }
                    }
                }
            }
            else
            {
                poemColl = block.Poems;
            }

            if (poemColl == null)
            {
                return null;
            }

            Poem poem = null;

            if (!string.IsNullOrEmpty(lineId.PoemFirstLine) && lineId.PoemIndex.HasValue)
            {
                Poem[] searchBlockParts = poemColl.GetPoemsByFirstLine(lineId.PoemFirstLine);

                if (searchBlockParts.Length == 1)
                {
                    poem = searchBlockParts[0];
                }
                else if (searchBlockParts.Length > 1)
                {
                    foreach (Poem item in searchBlockParts)
                    {
                        if (poemColl.IndexOf(item) == lineId.PoemIndex)
                        {
                            poem = item;
                            break;
                        }
                    }
                }
            }

            if (poem == null)
            {
                return null;
            }


            PoemLinesCollection linesColl = null;

            if (!string.IsNullOrEmpty(lineId.PoemPartFirstLine) && lineId.PoemPartIndex.HasValue)
            {
                PoemPart[] searchBlockParts = poem.GetPartsByFirstLine(lineId.PoemPartFirstLine);

                if (searchBlockParts.Length == 1)
                {
                    linesColl = searchBlockParts[0].Lines;
                }
                else if (searchBlockParts.Length > 1)
                {
                    foreach (PoemPart item in searchBlockParts)
                    {
                        if (poem.Parts.IndexOf(item) == lineId.PoemPartIndex)
                        {
                            linesColl = item.Lines;
                            break;
                        }
                    }
                }
            }
            else
            {
                linesColl = poem.Lines;
            }

            if (linesColl == null)
            {
                return null;
            }


            PoemLine line = null;

            if (!string.IsNullOrEmpty(lineId.LineString) && lineId.LineIndex.HasValue)
            {
                PoemLine[] searchBlockParts = linesColl.GetPoemsByFirstLine(lineId.LineString);

                if (searchBlockParts.Length == 1)
                {
                    line = searchBlockParts[0];
                }
                else if (searchBlockParts.Length > 1)
                {
                    foreach (PoemLine item in searchBlockParts)
                    {
                        if (linesColl.IndexOf(item) == lineId.LineIndex)
                        {
                            line = item;
                            break;
                        }
                    }
                }
            }

            if (line == null)
            {
                return null;
            }

            return line;
        }
    }
}
