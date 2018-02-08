
using System;
using TypeName.Container;

namespace TypeName
{
    internal sealed class RefTypeName : ComponentTypeNameBase
    {
        public override Sign Sign { get; }

        internal RefTypeName(Type type, TypeNameFlag flags) : base(type)
        {
            ComponentType = TypeNameFactory.Create(type.GetElementType(), flags);
            if (flags.Has(TypeNameFlag.ExplicitRef))
            {
                Sign = Sign.Ref;
            }
            else
            {
                Sign = Sign.Empty;
            }
        }
    }
}
