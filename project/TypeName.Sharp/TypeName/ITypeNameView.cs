using System;
using TypeName.Container;

namespace TypeName
{
    public interface ITypeNameView
    {

        Type Type { get; }

        string Name { get; }

        INameList<ITypeName> Generics { get; }

    }
}
