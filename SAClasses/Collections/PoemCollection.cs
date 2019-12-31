using System.Collections.ObjectModel;

namespace SAClasses.Collections
{
    public class PoemCollection : Collection<Poem>
    {
        private SABlock ownerBlock;
        private SABlockPart ownerBlockPart;

        public PoemCollection(SABlock ownerBlock)
        {
            this.ownerBlock = ownerBlock;
        }

        public PoemCollection(SABlockPart ownerBlockPart)
        {
            this.ownerBlockPart = ownerBlockPart; 
        }

        public new void Add(Poem poem)
        {
            if (!this.Contains(poem))
            {
                base.Add(poem);
            }

            if (this.ownerBlockPart != null)
            {
                poem.ParentBlockPart = this.ownerBlockPart;
            }
            else
            {
                poem.ParentBlock = this.ownerBlock;
            }
        }

        internal Poem[] GetPoemsByFirstLine(string firstLine)
        {
            int count = 0;

            foreach (Poem item in this)
            {
                string itemFirstLine = item.GetFirstLine().Line;

                if (string.Compare(itemFirstLine, firstLine, true) == 0)
                {
                    count++;
                }
            }

            Poem[] result = new Poem[count];

            count = 0;

            foreach (Poem item in this)
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
