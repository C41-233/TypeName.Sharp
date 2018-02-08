using System;
using TypeName.Container;
using TypeName.Filter;

namespace TypeName
{
    internal sealed class PointerTypeName : ComponentTypeNameBase
    {

        public override Sign Sign => Sign.Pointer;

        internal PointerTypeName(Type type, TypeNameFlag flags) : base(type)
        {
            ComponentType = TypeNameFactory.Create(type.GetElementType(), flags);
        }

    }
}
