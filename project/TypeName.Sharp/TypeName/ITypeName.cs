using System;
using TypeName.Container;

namespace TypeName
{
    public interface ITypeName
    {

        Type Type { get; }

        Namespace Namespace { get; }

        BaseNameList BaseNames { get; }

        string Name { get; }

        GenericList Generics { get; }

        bool Nullable { get; }

        ArrayRankList ArrayRanks { get; }

    }
}
