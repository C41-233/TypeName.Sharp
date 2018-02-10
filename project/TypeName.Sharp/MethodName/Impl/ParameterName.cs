using System;
using System.Reflection;
using System.Text;

namespace TypeName
{
    internal sealed class ParameterName : IParameterName
    {
        public ParameterInfo Parameter { get; }
        public string PassBy { get; }
        public ITypeName TypeName { get; }
        public string Name { get; }

        public bool IsOut { get; }
        public bool IsRef { get; }
        public bool IsVarParams { get; }

        internal ParameterName(ParameterInfo parameter, TypeNameFlag flags)
        {
            Parameter = parameter;
            TypeName = TypeNameFactory.Create(parameter.ParameterType, flags);
            Name = parameter.Name;

            if (parameter.IsOut)
            {
                IsOut = true;
                PassBy = "out";
            }
            else if (parameter.ParameterType.IsByRef)
            {
                IsRef = true;
                if (!flags.Has(TypeNameFlag.ExplicitRef))
                {
                    PassBy = "ref";
                }
            }
            else if (parameter.GetCustomAttributes(typeof(ParamArrayAttribute), false).Length > 0)
            {
                IsVarParams = true;
                PassBy = "params";
            }
            else
            {
                PassBy = null;
            }
        }

        public void ToString(StringBuilder sb)
        {
            if (PassBy != null)
            {
                sb.Append(PassBy);
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
