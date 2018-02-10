using System.Reflection;
using System.Text;

namespace TypeName
{
    internal sealed class ParameterName : IParameterName
    {
        public ParameterInfo Parameter { get; }
        public ITypeName TypeName { get; }
        public string Name { get; }

        internal ParameterName(ParameterInfo parameter, TypeNameFlag flags)
        {
            Parameter = parameter;
            TypeName = TypeNameFactory.Create(parameter.ParameterType, flags);
            Name = parameter.Name;
        }

        public void ToString(StringBuilder sb)
        {
            TypeName.ToString(sb);
            sb.Append(" ");
            sb.Append(Name);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            ToString(sb);
            return sb.ToString();
        }
    }
}
