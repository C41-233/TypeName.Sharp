using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeName.Container
{
    public sealed class BaseNameList : INameList<ITypeNameView>
    {

        internal static readonly BaseNameList Empty = new BaseNameList();

        private readonly List<TypeNameView> names;

        internal BaseNameList()
        {
            names = new List<TypeNameView>();
        }

        internal void AddBefore(TypeNameView type)
        {
            names.Insert(0, type);
        }

        public IEnumerator<ITypeNameView> GetEnumerator()
        {
            return names.Cast<ITypeNameView>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ITypeNameView this[int index] => names[index];

        public int Count => names.Count;

        public bool IsEmpty => Count == 0;

        internal void ToString(StringBuilder sb)
        {
            for (var i = 0; i < names.Count; i++)
            {
                names[i].ToString(sb);
                if (i != names.Count - 1)
                {
                    sb.Append('.');
                }
            }
        }

    }
}
