using System;
using TypeName.Container;
using TypeName.Filter;

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

        void FilterNamespace(NamespaceFilter filter);

        void ClearNamespace(NamespaceFilter filter);

    }
}
