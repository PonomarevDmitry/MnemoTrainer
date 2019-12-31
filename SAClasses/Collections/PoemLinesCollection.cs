using System.Collections.ObjectModel;

namespace SAClasses.Collections
{
    public class PoemLinesCollection : Collection<PoemLine>
    {
        private Poem ownerPoem;
        private PoemPart ownerPoemPart;

        public PoemLinesCollection(Poem ownerPoem)
        {
            this.ownerPoem = ownerPoem;
        }

        public PoemLinesCollection(PoemPart ownerPoemPart)
        {
            this.ownerPoemPart = ownerPoemPart;
        }

        public new void Add(PoemLine line)
        {
            if (!this.Contains(line))
            {
                base.Add(line);
            }

            if (this.ownerPoemPart != null)
            {
                line.ParentPoemPart = ownerPoemPart;
            }
            else
            {
                line.ParentPoem = ownerPoem;
            }
        }

        internal PoemLine[] GetPoemsByFirstLine(string firstLine)
        {
            int count = 0;

            foreach (PoemLine item in this)
            {
                string itemFirstLine = item.Line;

                if (string.Compare(itemFirstLine, firstLine, true) == 0)
                {
                    count++;
                }
            }

            PoemLine[] result = new PoemLine[count];

            count = 0;

            foreach (PoemLine item in this)
            {
                string itemFirstLine = item.Line;

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
