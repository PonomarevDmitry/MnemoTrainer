using System.Text;
using SAClasses.Collections;

namespace SAClasses
{
    public class PoemLine
    {
        private Poem parentPoem;
        public Poem ParentPoem
        {
            get
            {
                if (this.parentPoemPart != null)
                {
                    return this.parentPoemPart.ParentPoem;
                }

                return this.parentPoem;
            }

            internal set
            {
                if (this.parentPoemPart == null)
                {
                    if (this.parentPoem != value)
                    {
                        if (this.parentPoem != null)
                        {
                            this.parentPoem.Lines.Remove(this);
                        }

                        this.parentPoem = value;
                        if (this.parentPoem != null)
                        {
                            this.parentPoem.Lines.Add(this);
                        }
                    }
                }
            }
        }

        private PoemPart parentPoemPart;
        public PoemPart ParentPoemPart
        {
            get
            {
                return this.parentPoemPart;
            }

            internal set
            {
                if (this.parentPoemPart != value)
                {
                    if (this.parentPoemPart != null)
                    {
                        this.parentPoemPart.Lines.Remove(this);
                    }

                    this.parentPoemPart = value;
                    if (this.parentPoemPart != null)
                    {
                        this.parentPoemPart.Lines.Add(this);
                    }
                }
            }
        }

        private string line = string.Empty;
        public string Line
        {
            get { return this.line; }
        }

        public PoemLine(string vLine)
        {
            this.line = vLine;
        }

        public override string ToString()
        {
            return this.line;
        }

        public LineIsStart LineStartStatus
        {
            get
            {
                LineIsStart result = LineIsStart.None;

                if (this.ParentPoemPart != null)
                {
                    if (this.parentPoemPart.IsFirstLine(this))
                    {
                        result |= LineIsStart.OfPoemPart;
                    }
                }

                if (this.ParentPoem.IsFirstLine(this))
                {
                    result |= LineIsStart.OfPoem;
                }

                if (this.ParentPoem.ParentBlockPart != null)
                {
                    if (this.ParentPoem.ParentBlockPart.IsFirstLine(this))
                    {
                        result |= LineIsStart.OfBlockPart;
                    }
                }

                if (this.ParentPoem.ParentBlock.IsFirstLine(this))
                {
                    result |= LineIsStart.OfBlock;
                }

                return result;
            }
        }

        internal PoemLineIdentifier GetID()
        {
            PoemLineIdentifier result = new PoemLineIdentifier();

            result.LineString = this.Line;

            PoemPart curPoemPart = this.ParentPoemPart;
            Poem curPoem = this.ParentPoem;

            result.PoemName = curPoem.Name;
            result.PoemFirstLine = curPoem.GetFirstLine().Line;

            PoemLinesCollection collLines = null;

            if (curPoemPart != null)
            {
                collLines = curPoemPart.Lines;

                result.PoemPartName = curPoemPart.Name;
                result.PoemPartFirstLine = curPoemPart.GetFirstLine().Line;
                result.PoemPartIndex = curPoem.Parts.IndexOf(curPoemPart);
            }
            else
            {
                collLines = curPoem.Lines;
            }

            result.LineIndex = collLines.IndexOf(this);

            SABlockPart curBlockPart = curPoem.ParentBlockPart;
            SABlock curBlock = curPoem.ParentBlock;

            result.BlockName = curBlock.Name;
            result.BlockIndex = curBlock.ParentSA.Blocks.IndexOf(curBlock);


            PoemCollection collPoems = null;

            if (curBlockPart != null)
            {
                collPoems = curBlockPart.Poems;

                result.BlockPartName = curBlockPart.Name;
                result.BlockPartFirstLine = curBlockPart.GetFirstLine().Line;
                result.BlockPartIndex = curBlock.Parts.IndexOf(curBlockPart);
            }
            else
            {
                collPoems = curBlock.Poems;
            }

            result.PoemIndex = collPoems.IndexOf(curPoem);

            return result;
        }

        public string GetFullInfo()
        {
            StringBuilder strBuilder = new StringBuilder();

            PoemPart curPoemPart = this.ParentPoemPart;
            Poem curPoem = this.ParentPoem;
            SABlockPart curBlockPart = curPoem.ParentBlockPart;
            SABlock curBlock = curPoem.ParentBlock;

            strBuilder.AppendFormat("Блок: {0}", curBlock.ToString());

            if (curBlockPart != null)
            {
                strBuilder.AppendLine();
                strBuilder.AppendFormat("Часть блока: {0}", curBlockPart.ToString());
            }

            strBuilder.AppendLine();
            strBuilder.AppendFormat("Стих: {0}", curPoem.ToString());

            if (curPoemPart != null)
            {
                strBuilder.AppendLine();
                strBuilder.AppendFormat("Часть стиха: {0}", curPoemPart.ToString());
            }

            return strBuilder.ToString();
        }
    }
}
