using System.Text;

namespace TypeName.Utils
{
    public static class StringUtils
    {

        public static void RemoveLast(this StringBuilder sb, string value)
        {
            if (!sb.EndsWith(value))
            {
                return;
            }
            sb.Remove(sb.Length - value.Length, value.Length);
        }

        public static bool EndsWith(this StringBuilder sb, string value)
        {
            if (sb.Length < value.Length)
            {
                return false;
            }

            for (int i=value.Length-1, j=sb.Length-1; i>=0; i--, j--)
            {
                if (value[i] != sb[j])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
