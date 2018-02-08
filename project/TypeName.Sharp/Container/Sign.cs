using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TypeName.Container
{
    public sealed class Sign
    {

        internal static readonly Sign Empty = new Sign();
        internal static readonly Sign Nullable = new Sign("?");
        internal static readonly Sign Pointer = new Sign("*");

        private readonly string sign;

        private Sign(string sign = "")
        {
            this.sign = sign;
        }

        public void ToString(StringBuilder sb)
        {
            sb.Append(sign);
        }

        public override string ToString()
        {
            return sign;
        }

    }

}
