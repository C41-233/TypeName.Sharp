using System;

namespace TypeName
{
    [Flags]
    public enum TypeNameFlag
    {
        
        Default = 0,
        FullPrimitive = 0x01,
        FullNullable = 0x02,
        OmitGenericParameter = 0x04,
        ExplicitRef = 0x08,

    }

    public static class TypeNameFlagExtend
    {
        public static bool Has(this TypeNameFlag flags, TypeNameFlag flag)
        {
            return (flags & flag) != 0;
        }

    }
}
