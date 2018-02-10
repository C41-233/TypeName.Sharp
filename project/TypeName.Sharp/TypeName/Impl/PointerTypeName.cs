using System;

namespace TypeName
{
    internal sealed class PointerTypeName : ComponentTypeNameBase
    {

        public override string Sign => SignConstant.Pointer;

        internal PointerTypeName(Type type, TypeNameFlag flags) : base(type)
        {
            ComponentType = TypeNameFactory.Create(type.GetElementType(), flags);
        }

    }
}
