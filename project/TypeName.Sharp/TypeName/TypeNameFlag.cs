using System;

namespace TypeName
{
    [Flags]
    public enum NameFlag
    {
        
        Default = 0,
        NoNamespace = 0x01,
        FullPrimitive = 0x02,
        FullNullable = 0x04,

    }

    public static class NameFlagExtend
    {
        public static bool Has(this NameFlag flags, NameFlag flag)
        {
            return (flags & flag) != 0;
        }

    }
}
