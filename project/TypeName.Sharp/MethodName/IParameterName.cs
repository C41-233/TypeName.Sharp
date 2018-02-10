using System.Reflection;
using System.Text;

namespace TypeName
{
    public interface IParameterName
    {

        ParameterInfo Parameter { get; }
        ITypeName TypeName { get; }
        string Name { get; }
        void ToString(StringBuilder sb);

        bool IsOut { get; }
        bool IsRef { get; }
        bool IsVarParams { get; }
    }
}
