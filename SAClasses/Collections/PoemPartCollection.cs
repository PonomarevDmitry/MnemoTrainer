using System.Collections.ObjectModel;

namespace SAClasses.Collections
{
    public class PoemPartCollection : Collection<PoemPart>
    {
        private Poem owner;

        public PoemPartCollection(Poem Owner)
        {
            this.owner = Owner;
        }

        public new void Add(PoemPart poemPart)
        {
            if (!this.Contains(poemPart))
            {
                base.Add(poemPart);
            }

            poemPart.ParentPoem = owner;
        }
    }
}
