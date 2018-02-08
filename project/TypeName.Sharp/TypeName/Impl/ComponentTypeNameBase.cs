using System;
using TypeName.Container;
using TypeName.Filter;

namespace TypeName
{
    internal abstract class ComponentTypeNameBase : TypeName
    {
        public override Namespace Namespace => ComponentType.Namespace;
        public override BaseNameList BaseNames => ComponentType.BaseNames;
        public override string Name => ComponentType.Name;
        public override GenericList Generics => ComponentType.Generics;
        public override Sign Sign => ComponentType.Sign;
        public override ArrayRankList ArrayRanks => ComponentType.ArrayRanks;

        protected TypeName ComponentType { get; set; }

        internal ComponentTypeNameBase(Type type) : base(type)
        {
        }

        public override void FilterNamespace(NamespaceFilter filter)
        {
            ComponentType.FilterNamespace(filter);
        }

        public override void ClearNamespace(NamespaceFilter filter)
        {
            ComponentType.ClearNamespace(filter);
        }
    }
}
