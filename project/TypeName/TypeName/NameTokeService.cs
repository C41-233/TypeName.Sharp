using System.Collections.Generic;
using System.Text;
using TypeName.Utility;

namespace TypeName
{
    internal partial class NameToken
    {

        public void SetRecursiveFull()
        {
            Parent?.SetRecursiveFull();
            IsFullMode = true;
            foreach (var name in GenericNameTokens)
            {
                name.SetRecursiveFull();
            }
        }

        public void ToString(StringBuilder sb)
        {
            if (Parent != null)
            {
                if (IsFullMode)
                {
                    Parent.IsFullMode = true;
                }
                Parent.ToString(sb);
                sb.Append('.');
            }
            else if (IsFullMode && Namespace != null)
            {
                sb.Append(Namespace);
                sb.Append('.');
            }
            sb.Append(Name);
            if (GenericNameTokens.Count > 0)
            {
                sb.Append("<");
                foreach (var name in GenericNameTokens)
                {
                    if (IsFullMode)
                    {
                        name.IsFullMode = true;
                    }
                    name.ToString(sb);
                    sb.Append(',');
                }
                sb.RemoveLast(',');
                sb.Append(">");
            }
            sb.Append(Suffix);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            ToString(sb);
            return sb.ToString();
        }

        public void MakeNameDictionary(Dictionary<string, List<NameToken>> dic)
        {
            List<NameToken> tokens;
            if (dic.TryGetValue(Name, out tokens) == false)
            {
                tokens = dic[Name] = new List<NameToken>();
            }
            tokens.Add(this);
            Parent?.MakeNameDictionary(dic);
            foreach (var name in GenericNameTokens)
            {
                name.MakeNameDictionary(dic);
            }
        }
    }
}