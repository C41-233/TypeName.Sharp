using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TypeName.Container
{
    public sealed class ParameterList : NameList<IParameterName>
    {

        private readonly List<ParameterName> parameters = new List<ParameterName>();

        public override IEnumerator<IParameterName> GetEnumerator()
        {
            return parameters.Cast<IParameterName>().GetEnumerator();
        }

        public override IParameterName this[int index] => parameters[index];

        public override int Count => parameters.Count;

        public override void ToString(StringBuilder sb)
        {
            sb.Append('(');
            for (var i = 0; i < parameters.Count; i++)
            {
                parameters[i].ToString(sb);
                if (i != parameters.Count - 1)
                {
                    sb.Append(',');
                }       
            }
            sb.Append(')');
        }

        internal void Add(ParameterName parameter)
        {
            parameters.Add(parameter);
        }
    }
}
