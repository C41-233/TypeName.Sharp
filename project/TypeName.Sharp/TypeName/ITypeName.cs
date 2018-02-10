using System;
using System.Text;
using TypeName.Container;
using TypeName.Filter;

namespace TypeName
{
    public interface ITypeName : IFilterNamespaceElement
    {

        Type Type { get; }

        Namespace Namespace { get; }

        BaseNameList BaseNames { get; }

        string Name { get; }

        GenericList Generics { get; }

        string Sign { get; }

        ArrayRankList ArrayRanks { get; }

        void ToString(StringBuilder sb);

    }
}
