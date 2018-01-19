using System.Text;

namespace TypeName.Utility
{
    internal static class StringExtend
    {

        public static void RemoveLast(this StringBuilder sb, string token)
        {
            if (sb.EndsWith(token))
            {
                sb.Remove(sb.Length - token.Length - 1, token.Length);
            }
        }

        public static void RemoveLast(this StringBuilder sb, char token)
        {
            if (sb.Length > 0 && sb[sb.Length - 1] == token)
            {
                sb.Remove(sb.Length - 1, 1);
            }
        }

        public static void RemoveFirst(this StringBuilder sb, string token)
        {
            if (sb.StartsWith(token))
            {
                sb.Remove(0, token.Length);
            }
        }

        public static void RemoveFirst(this StringBuilder sb, char token)
        {
            if (sb.Length > 0 && sb[0] == token)
            {
                sb.Remove(0, 1);
            }
        }

        public static bool StartsWith(this StringBuilder sb, string value)
        {
            for (int i = 0, j = 0; j < value.Length; i++, j++)
            {
                if (i >= sb.Length)
                {
                    return false;
                }
                if (sb[i] != value[j])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool EndsWith(this StringBuilder sb, string value)
        {
            for (int i = sb.Length - 1, j = 0; j < value.Length; i--, j++)
            {
                if (i < 0)
                {
                    return false;
                }
                if (sb[i] != value[j])
                {
                    return false;
                }
            }
            return true;
        }

        public static void Prepend(this StringBuilder sb, char value)
        {
            sb.Insert(0, value);
        }

        public static void Prepend(this StringBuilder sb, string value)
        {
            sb.Insert(0, value);
        }

    }
}
