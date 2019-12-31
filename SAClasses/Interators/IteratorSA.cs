using SAClasses.Collections;

namespace SAClasses.Interators
{
    public class IteratorSA
    {
        //public SA SystemAccumulation { get; set; }

        public PoemLine GetNextLine(PoemLine currentLine, bool forward)
        {
            {
                PoemLinesCollection coll = null;

                if (currentLine.ParentPoemPart != null)
                {
                    coll = currentLine.ParentPoemPart.Lines;
                }
                else
                {
                    coll = currentLine.ParentPoem.Lines;
                }

                int indexLine = coll.IndexOf(currentLine);
                if (indexLine != -1)
                {
                    int nextIndex = indexLine + (forward ? 1 : -1);

                    if (0 <= nextIndex && nextIndex < coll.Count)
                    {
                        return coll[nextIndex];
                    }
                }
            }

            if (currentLine.ParentPoemPart != null)
            {
                PoemPart nextPoemPart = GetNextPoemPart(currentLine.ParentPoemPart, forward);

                if (nextPoemPart != null)
                {
                    if (forward)
                    {
                        return nextPoemPart.GetFirstLine();
                    }
                    else
                    {
                        return nextPoemPart.GetLastLine();
                    }
                }
            }

            {
                Poem nextPoem = GetNextPoem(currentLine.ParentPoem, forward);
                if (nextPoem != null)
                {
                    if (forward)
                    {
                        return nextPoem.GetFirstLine();
                    }
                    else
                    {
                        return nextPoem.GetLastLine();
                    }
                }
            }

            if (currentLine.ParentPoem.ParentBlockPart != null)
            {
                SABlockPart nextPart = GetNextBlockPart(currentLine.ParentPoem.ParentBlockPart, forward);
                if (nextPart != null)
                {
                    if (forward)
                    {
                        return nextPart.GetFirstLine();
                    }
                    else
                    {
                        return nextPart.GetLastLine();
                    }
                }
            }

            {
                SABlock nextBlock = GetNextBlock(currentLine.ParentPoem.ParentBlock, forward);
                if (nextBlock != null)
                {
                    if (forward)
                    {
                        return nextBlock.GetFirstLine();
                    }
                    else
                    {
                        return nextBlock.GetLastLine();
                    }
                }
            }

            if (forward)
            {
                return currentLine.ParentPoem.ParentBlock.ParentSA.GetFirstLine();
            }
            else
            {
                return currentLine.ParentPoem.ParentBlock.ParentSA.GetLastLine();
            }
        }

        public PoemPart GetNextPoemPart(PoemPart poemPart, bool forward)
        {
            Poem parentPoem = poemPart.ParentPoem;

            int indexPart = parentPoem.Parts.IndexOf(poemPart);
            if (indexPart != -1)
            {
                int nextIndex = indexPart + (forward ? 1 : -1);

                if (0 <= nextIndex && nextIndex < parentPoem.Parts.Count)
                {
                    return parentPoem.Parts[nextIndex];
                }
            }

            return null;
        }

        public Poem GetNextPoem(Poem poem, bool forward)
        {
            {
                PoemCollection coll = null;

                if (poem.ParentBlockPart != null)
                {
                    coll = poem.ParentBlockPart.Poems;
                }
                else
                {
                    coll = poem.ParentBlock.Poems;
                }

                int indexLine = coll.IndexOf(poem);
                if (indexLine != -1)
                {
                    int nextIndex = indexLine + (forward ? 1 : -1);

                    if (0 <= nextIndex && nextIndex < coll.Count)
                    {
                        return coll[nextIndex];
                    }
                }
            }

            if (poem.ParentBlockPart != null)
            {
                SABlockPart nextBlockPart = GetNextBlockPart(poem.ParentBlockPart, forward);

                if (nextBlockPart != null)
                {
                    if (forward)
                    {
                        return nextBlockPart.GetFirstPoem();
                    }
                    else
                    {
                        return nextBlockPart.GetLastPoem();
                    }
                }
            }

            {
                SABlock nextBlock = GetNextBlock(poem.ParentBlock, forward);

                if (forward)
                {
                    return nextBlock.GetFirstPoem();
                }
                else
                {
                    return nextBlock.GetLastPoem();
                }
            }
        }

        public SABlockPart GetNextBlockPart(SABlockPart blockPart, bool forward)
        {
            SABlock parentBlock = blockPart.ParentBlock;

            int indexPart = parentBlock.Parts.IndexOf(blockPart);
            if (indexPart != -1)
            {
                int nextIndex = indexPart + (forward ? 1 : -1);

                if (0 <= nextIndex && nextIndex < parentBlock.Parts.Count)
                {
                    return parentBlock.Parts[nextIndex];
                }
            }

            return null;
        }

        public SABlock GetNextBlock(SABlock block, bool forward)
        {
            SA parentSA = block.ParentSA;

            int indexBlock = parentSA.Blocks.IndexOf(block);

            if (indexBlock != -1)
            {
                int nextIndex = indexBlock + (forward ? 1 : -1);

                if (0 <= nextIndex && nextIndex < parentSA.Blocks.Count)
                {
                    return parentSA.Blocks[nextIndex];
                }
            }

            if (forward)
            {
                return parentSA.GetFirstBlock();
            }
            else
            {
                return parentSA.GetLastBlock();
            }
        }
    }
}
