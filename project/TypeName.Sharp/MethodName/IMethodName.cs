using System.Reflection;
using System.Text;
using TypeName.Container;
using TypeName.Filter;

namespace TypeName
{
    public interface IMethodName : IFilterNamespaceElement
    {
        MethodInfo Method { get; }
        ITypeName ReturnType { get; }
        ITypeName ExplicitInterface { get; }
        string Name { get; }
        GenericList Generics { get; }
        ParameterList Parameters { get; }
        void ToString(StringBuilder sb);
    }
}
