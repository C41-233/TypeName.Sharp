using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeName.Container
{
    public sealed class GenericList : NameList<ITypeName>
    {

        internal static readonly GenericList Empty = new GenericList();

        private readonly List<TypeName> names;

        internal GenericList()
        {
            names = new List<TypeName>();
        }

        internal void Add(TypeName name)
        {
            names.Add(name);
        }

        public override IEnumerator<ITypeName> GetEnumerator()
        {
            return names.Cast<ITypeName>().GetEnumerator();
        }

        public override ITypeName this[int index] => names[index];

        public override int Count => names.Count;

        public override void ToString(StringBuilder sb)
        {
            if (IsEmpty)
            {
                return;
            }
            sb.Append('<');
            for(var i=0; i<names.Count; i++)
            {
                names[i].ToString(sb);
                if (i != names.Count - 1)
                {
                    sb.Append(',');
                }
            }
            sb.Append('>');
        }

    }
}
