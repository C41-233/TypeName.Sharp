using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TypeName.Utility;

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

        public static string GetSourceName(this MethodInfo method)
        {
            var dic = new Dictionary<string, List<NameToken>>();

            var returnName = NameToken.Create(method.ReturnType);
            returnName.MakeNameDictionary(dic);

            NameToken[] genericNames = new NameToken[0];
            if (method.IsGenericMethod)
            {
                genericNames = method.GetGenericArguments().Select(type =>
                {
                    var name = NameToken.Create(type);
                    name.MakeNameDictionary(dic);
                    return name;
                }).ToArray();
            }

            var parameters = method.GetParameters();
            var parameterNames = parameters.Select(p =>
            {
                var name = NameToken.Create(p.ParameterType);
                name.MakeNameDictionary(dic);
                return name;
            }).ToArray();
            ProcessDuplicate(dic);
            return GetMethodSourceString(method, genericNames, returnName, parameters, parameterNames);
        }

        public static string GetSourceFullName(this MethodInfo method)
        {
            var returnName = NameToken.Create(method.ReturnType);
            returnName.SetRecursiveFull();

            NameToken[] genericNames = new NameToken[0];
            if (method.IsGenericMethod)
            {
                genericNames = method.GetGenericArguments().Select(type =>
                {
                    var name = NameToken.Create(type);
                    name.SetRecursiveFull();
                    return name;
                }).ToArray();
            }

            var parameters = method.GetParameters();
            var parameterNames = parameters.Select(p =>
            {
                var name = NameToken.Create(p.ParameterType);
                name.SetRecursiveFull();
                return name;
            }).ToArray();
            return GetMethodSourceString(method, genericNames, returnName, parameters, parameterNames);
        }

        private static string GetMethodSourceString(MethodInfo method, NameToken[] genericNames, NameToken returnName, ParameterInfo[] parameters, NameToken[] parameterNames)
        {
            var sb = new StringBuilder();
            sb.Append(returnName);
            sb.Append(" ");
            sb.Append(method.Name);
            if (genericNames.Length > 0)
            {
                sb.Append('<');
                foreach (var name in genericNames)
                {
                    sb.Append(name);
                    sb.Append(',');
                }
                sb.RemoveLast(',');
                sb.Append('>');
            }
            sb.Append('(');
            for (var i = 0; i < parameters.Length; i++)
            {
                sb.Append(parameterNames[i]);
                sb.Append(" ");
                sb.Append(parameters[i].Name);
                sb.Append(", ");
            }
            sb.RemoveLast(", ");
            sb.Append(')');
            return sb.ToString();
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
