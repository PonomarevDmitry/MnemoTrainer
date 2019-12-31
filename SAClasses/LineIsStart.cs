using System;

namespace SAClasses
{
    [Flags]
    public enum LineIsStart
    {
        None = 0,
        OfPoemPart = 1,
        OfPoem = 2,
        OfBlockPart = 4,
        OfBlock = 8
    }
}
