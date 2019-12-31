using System.Collections.ObjectModel;

namespace SAClasses.Collections
{
    public class BlockPartCollection : Collection<SABlockPart>
    {
        private SABlock owner;

        public BlockPartCollection(SABlock Owner)
        {
            this.owner = Owner;
        }

        public new void Add(SABlockPart blockPart)
        {
            if (!this.Contains(blockPart))
            {
                base.Add(blockPart);
            }

            blockPart.ParentBlock = owner;
        }
    }
}
