using System;
using TypeName.Container;
using TypeName.Util;

namespace TypeName
{
    internal sealed class ArrayTypeName : TypeName
    {
        public override Namespace Namespace => ComponentType.Namespace;
        public override BaseNameList BaseNames => ComponentType.BaseNames;
        public override string Name => ComponentType.Name;
        public override GenericList Generics => ComponentType.Generics;
        public override bool Nullable => ComponentType.Nullable;

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

        internal override void SetNoNamespaceIfPossible(NameContext conext)
        {
            ComponentType.SetNoNamespaceIfPossible(conext);
        }
    }
}
