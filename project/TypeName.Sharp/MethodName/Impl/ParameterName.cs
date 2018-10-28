using System;
using System.Reflection;
using System.Text;

namespace TypeName
{
    internal sealed class ParameterName : IParameterName
    {
        public ParameterInfo Parameter { get; }
        public string Modifier { get; }
        public ITypeName TypeName { get; }
        public string Name { get; }

        internal ParameterName(ParameterInfo parameter, TypeNameFlag flags)
        {
            Parameter = parameter;
            TypeName = TypeNameFactory.Create(parameter.ParameterType, flags);
            Name = parameter.Name;

            if (parameter.IsOut)
            {
                Modifier = "out";
            }
            else if (parameter.ParameterType.IsByRef)
            {
                if (!flags.Has(TypeNameFlag.ExplicitRef))
                {
                    Modifier = "ref";
                }
            }
            else if (parameter.GetCustomAttributes(typeof(ParamArrayAttribute), false).Length > 0)
            {
                Modifier = "params";
            }
            else
            {
                Modifier = null;
            }
        }

        public void ToString(StringBuilder sb)
        {
            if (Modifier != null)
            {
                sb.Append(Modifier);
                sb.Append(" ");
            }
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
