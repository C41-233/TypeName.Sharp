using System;
using TypeName.Container;
using TypeName.Filter;

namespace TypeName
{
    internal sealed class PointerTypeName : TypeName
    {

        public override Namespace Namespace => ComponentType.Namespace;
        public override BaseNameList BaseNames => ComponentType.BaseNames;
        public override string Name => ComponentType.Name;
        public override GenericList Generics => ComponentType.Generics;
        public override Sign Sign => Sign.Pointer;
        private readonly TypeName ComponentType;

        internal PointerTypeName(Type type, TypeNameFlag flags) : base(type)
        {
            ComponentType = TypeNameFactory.Create(type.GetElementType(), flags);
        }

        public override void FilterNamespace(NamespaceFilter filter)
        {
            ComponentType.FilterNamespace(filter);
        }

        public override void ClearNamespace(NamespaceFilter filter)
        {
            if (!filter.IsNeedFullName(this))
            {
                ComponentType.ClearNamespace(filter);
            }
        }

    }
}
