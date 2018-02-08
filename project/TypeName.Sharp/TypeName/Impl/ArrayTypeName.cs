using System;
using TypeName.Container;
using TypeName.Filter;

namespace TypeName
{
    internal sealed class ArrayTypeName : ComponentTypeNameBase
    {

        public override ArrayRankList ArrayRanks { get; }

        internal ArrayTypeName(Type type, TypeNameFlag flags) : base(type)
        {
            ArrayRanks = new ArrayRankList();
            while (type.IsArray)
            {
                ArrayRanks.Add(type.GetArrayRank());
                type = type.GetElementType();
            }
            ComponentType = TypeNameFactory.Create(type, flags);
        }

    }
}
