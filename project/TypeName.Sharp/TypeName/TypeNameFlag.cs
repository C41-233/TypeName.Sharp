using System;

namespace TypeName
{
    [Flags]
    public enum TypeNameFlag
    {
        
        Default = 0,

        /// <summary>
        /// Primitive types should be presented as CLR name. (int as Int32)
        /// </summary>
        FullPrimitive = 0x01,

        /// <summary>
        /// Nullable types should be presented as Class name. (Date? as Nullable&lt;Date&gt;)
        /// </summary>
        FullNullable = 0x02,

        /// <summary>
        /// Generic parameters should be omited. (Dictionary&lt;TKey, TValue&gt; as Dictionary&lt;,&gt;)
        /// </summary>
        OmitGenericParameter = 0x04,

        /// <summary>
        /// Ref parameter should be presented explicited. (out int as int&)
        /// </summary>
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
