using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TypeName.Container
{
    public sealed class ArrayRankList : INameList<int>
    {

        internal static readonly ArrayRankList Empty = new ArrayRankList();

        private readonly List<int> ranks;

        internal ArrayRankList()
        {
            ranks = new List<int>();
        }

        internal void Add(int value)
        {
            ranks.Add(value);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return ranks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int this[int index] => ranks[index];

        public int Count => ranks.Count;

        public bool IsEmpty => Count == 0;

        internal void ToString(StringBuilder sb)
        {
            foreach (var rank in ranks)
            {
                sb.Append('[');
                for (var i = 0; i < rank - 1; i++)
                {
                    sb.Append(',');
                }
                sb.Append(']');
            }
        }

    }
}
