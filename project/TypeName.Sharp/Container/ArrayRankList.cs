using System.Collections.Generic;
using System.Text;

namespace TypeName.Container
{
    public sealed class ArrayRankList : NameList<int>
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

        public override IEnumerator<int> GetEnumerator()
        {
            return ranks.GetEnumerator();
        }

        public override int this[int index] => ranks[index];

        public override int Count => ranks.Count;

        public override void ToString(StringBuilder sb)
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
