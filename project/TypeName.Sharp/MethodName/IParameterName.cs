using System.Reflection;
using System.Text;

namespace TypeName
{
    public interface IParameterName
    {

        ParameterInfo Parameter { get; }
        string Modifier { get; }
        ITypeName TypeName { get; }
        string Name { get; }
        void ToString(StringBuilder sb);
    }
}
