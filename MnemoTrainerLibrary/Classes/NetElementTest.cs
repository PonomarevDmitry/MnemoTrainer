using System;

namespace MnemoTrainerLibrary.Classes
{
    [Flags]
    public enum NetTestType
    {
        None = 0,
        Number = 1,
        Pattern = 2,
        All = Number | Pattern
    }
}
