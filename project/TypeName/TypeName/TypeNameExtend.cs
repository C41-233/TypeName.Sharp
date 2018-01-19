using System;
using System.Collections.Generic;

namespace TypeName
{

    public static class TypeNameExtend
    {

        public static string GetSourceFullName(this Type type)
        {
            var name = NameToken.Create(type);
            name.SetRecursiveFull();
            return name.ToString();
        }

        public static string GetSourceName(this Type type)
        {
            var name = NameToken.Create(type);
            var dic = new Dictionary<string, List<NameToken>>();
            name.MakeNameDictionary(dic);
            ProcessDuplicate(dic);
            return name.ToString();
        }

        private static void ProcessDuplicate(Dictionary<string, List<NameToken>> dic)
        {
            foreach (var list in dic.Values)
            {
                if (list.Count == 1)
                {
                    continue;
                }
                for (var i = 1; i < list.Count; i++)
                {
                    if (list[i].Type != list[0].Type)
                    {
                        foreach (var token in list)
                        {
                            token.IsFullMode = true;
                        }
                        break;
                    }
                }
            }
        }

    }

}
