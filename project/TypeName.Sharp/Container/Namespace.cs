using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeName.Container
{
    public sealed class Namespace : INameList<string>
    {

        private static readonly string[] EmptyArray = new string[0];

        internal static readonly Namespace Empty = new Namespace();

        private string[] RuntimeTokens => IsFullName ? tokens : EmptyArray;

        private readonly string[] tokens;

        public string FullName { get; }

        public bool IsFullName { get; private set; }

        internal Namespace(string ns = null)
        {
            IsFullName = true;
            FullName = ns ?? "";
            tokens = ns?.Split('.') ?? EmptyArray;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return RuntimeTokens.Cast<string>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return RuntimeTokens.GetEnumerator();
        }

        public string this[int index] => RuntimeTokens[index];

        public int Count => RuntimeTokens.Length;

        public bool IsEmpty => Count == 0;

        internal void Clear()
        {
            IsFullName = false;
        }

        public override string ToString()
        {
            return IsFullName ? FullName : "";
        }

        internal void ToString(StringBuilder sb)
        {
            sb.Append(ToString());
        }

    }
}
