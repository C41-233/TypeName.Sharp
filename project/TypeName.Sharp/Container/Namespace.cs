using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeName.Container
{
    public sealed class Namespace : NameList<string>
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

        public override IEnumerator<string> GetEnumerator()
        {
            return RuntimeTokens.Cast<string>().GetEnumerator();
        }

        public override string this[int index] => RuntimeTokens[index];

        public override int Count => RuntimeTokens.Length;

        internal void Clear()
        {
            IsFullName = false;
        }

        public override string ToString()
        {
            return IsFullName ? FullName : "";
        }

        public override void ToString(StringBuilder sb)
        {
            sb.Append(ToString());
        }

    }
}
