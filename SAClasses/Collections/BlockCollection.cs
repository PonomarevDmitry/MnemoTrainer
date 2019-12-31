using System.Collections.ObjectModel;

namespace SAClasses.Collections
{
    public class BlockCollection : Collection<SABlock>
    {
        private SA owner;

        public BlockCollection(SA Owner)
        {
            this.owner = Owner;
        }

        public new void Add(SABlock block)
        {
            if (!this.Contains(block))
            {
                base.Add(block);
            }

            block.ParentSA = owner;
        }
    }
}
