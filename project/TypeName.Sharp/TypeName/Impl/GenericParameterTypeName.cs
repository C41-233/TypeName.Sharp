using System;

namespace TypeName
{
    internal sealed class GenericParameterTypeName : TypeName
    {

        public override string Name { get; }

        internal GenericParameterTypeName(Type type, TypeNameFlag flags) : base(type)
        {
            if (flags.Has(TypeNameFlag.OmitGenericParameter))
            {
                Name = "";
            }
            else
            {
                Name = type.Name;
            }
        }

    }
}
