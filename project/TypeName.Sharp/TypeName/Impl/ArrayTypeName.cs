using System;
using TypeName.Container;
using TypeName.Filter;

namespace TypeName
{
    internal sealed class ArrayTypeName : TypeName
    {
        public override Namespace Namespace => ComponentType.Namespace;
        public override BaseNameList BaseNames => ComponentType.BaseNames;
        public override string Name => ComponentType.Name;
        public override GenericList Generics => ComponentType.Generics;
        public override NullableName Nullable => ComponentType.Nullable;

        public override ArrayRankList ArrayRanks { get; }

        private readonly TypeName ComponentType;

        internal ArrayTypeName(Type type, NameFlag flags) : base(type)
        {
            ArrayRanks = new ArrayRankList();
            while (type.IsArray)
            {
                ArrayRanks.Add(type.GetArrayRank());
                type = type.GetElementType();
            }
            ComponentType = TypeNameFactory.Create(type, flags);
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
