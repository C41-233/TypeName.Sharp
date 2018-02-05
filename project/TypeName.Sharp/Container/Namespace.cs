using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeName.Container
{
    public sealed class Namespace : INameList<string>
    {

        internal static readonly Namespace Empty = new Namespace();

        private string[] Tokens => tokens ?? (tokens = ns?.Split('.').ToArray() ?? new string[0]);

        private string[] tokens;
        private string ns;

        internal Namespace(string ns = null)
        {
            this.ns = ns;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return Tokens.Cast<string>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Tokens.GetEnumerator();
        }

        public string this[int index] => Tokens[index];

        public int Count => Tokens.Length;

        public bool IsEmpty => Count == 0;

        internal void Clear()
        {
            ns = null;
            tokens = new string[0];
        }

        public override string ToString()
        {
            return ns;
        }

        internal void ToString(StringBuilder sb)
        {
            sb.Append(ns);
        }

    }
}
