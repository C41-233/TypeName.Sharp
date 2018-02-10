
using System;

namespace TypeName
{
    internal sealed class RefTypeName : ComponentTypeNameBase
    {
        public override string Sign { get; }

        internal RefTypeName(Type type, TypeNameFlag flags) : base(type)
        {
            ComponentType = TypeNameFactory.Create(type.GetElementType(), flags);
            if (flags.Has(TypeNameFlag.ExplicitRef))
            {
                Sign = SignConstant.Ref;
            }
            else
            {
                Sign = null;
            }
        }
    }
}
