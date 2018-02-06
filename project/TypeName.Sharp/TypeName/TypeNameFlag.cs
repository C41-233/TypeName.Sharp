using System;

namespace TypeName
{
    [Flags]
    public enum NameFlag
    {
        
        Default = 0,
        FullPrimitive = 0x01,
        FullNullable = 0x02,

    }

    public static class NameFlagExtend
    {
        public static bool Has(this NameFlag flags, NameFlag flag)
        {
            return (flags & flag) != 0;
        }

    }
}
