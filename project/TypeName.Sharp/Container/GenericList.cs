using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TypeName.Container
{
    public sealed class GenericList : INameList<ITypeName>
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

        public IEnumerator<ITypeName> GetEnumerator()
        {
            return names.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ITypeName this[int index] => names[index];

        public int Count => names.Count;

        public bool IsEmpty => Count == 0;

        internal void ToString(StringBuilder sb)
        {
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
