using System;
using TypeName.Container;

namespace TypeName
{
    internal abstract class ComponentTypeNameBase : TypeName
    {
        public override Namespace Namespace => ComponentType.Namespace;
        public override BaseNameList BaseNames => ComponentType.BaseNames;
        public override string Name => ComponentType.Name;
        public override GenericList Generics => ComponentType.Generics;
        public override string Sign => ComponentType.Sign;
        public override ArrayRankList ArrayRanks => ComponentType.ArrayRanks;

        protected TypeName ComponentType { get; set; }

        internal ComponentTypeNameBase(Type type) : base(type)
        {
        }

    }
}
