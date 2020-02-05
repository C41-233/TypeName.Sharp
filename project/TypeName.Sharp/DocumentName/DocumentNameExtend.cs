using System;
using System.Reflection;
using System.Text;
using TypeName.Utils;

namespace TypeName
{

    public static class DocumentNameExtend
    {

        public static string GetDocumentString(this Type type)
        {
            return "T:" + GetDocumentStringInternal(type);
        }

        private static string GetDocumentStringInternal(Type type)
        {
            var name = type.ToString();
            int genericStart = name.IndexOf('[');
            if (genericStart < 0)
            {
                return name;
            }
            return name.Substring(0, genericStart).Replace('+', '.');
        }

        private static string GetGenericParameterDocumentString(Type type)
        {
            if (type.DeclaringType != null)
            {
                var it = Array.IndexOf(type.DeclaringType.GetGenericArguments(), type);
                if (it >= 0)
                {
                    return $"`{it}";
                }
            }
            if (type.DeclaringMethod != null)
            {
                var it = Array.IndexOf(type.DeclaringMethod.GetGenericArguments(), type);
                if (it >= 0)
                {
                    return $"``{it}";
                }
            }
            return "";
        }

        private static string GetParameterDocumentString(Type type)
        {
            if (type.IsArray)
            {
                var elementType = type.GetElementType();
                var sb = new StringBuilder();
                sb.Append(GetParameterDocumentString(elementType));
                var n = type.GetArrayRank();
                sb.Append('[');
                if (n > 1)
                {
                    for (var i = 0; i < n - 1; i++)
                    {
                        sb.Append("0:,");
                    }
                    sb.Append("0:");
                }
                sb.Append(']');
                return sb.ToString();
            }

            if (type.IsGenericParameter)
            {
                return GetGenericParameterDocumentString(type);
            }

            if (!type.IsGenericType)
            {
                return type.FullName;
            }

            {
                var sb = new StringBuilder();
                var name = type.ToString();
                var genericStart = name.IndexOf('[');
                var tokens = name.Substring(0, genericStart).Split('.', '+');

                var generics = type.GetGenericArguments();
                int genericIndex = 0;

                foreach (var token in tokens)
                {
                    var quota = token.IndexOf('`');
                    if (quota < 0)
                    {
                        sb.Append(token);
                    }
                    else
                    {
                        sb.Append(token.Substring(0, quota));
                        sb.Append("{");
                        int.TryParse(token.Substring(quota + 1), out var num);
                        for (var i = 0; i < num; i++)
                        {
                            var generic = generics[genericIndex++];
                            if (generic.IsGenericParameter)
                            {
                                sb.Append(GetGenericParameterDocumentString(generic));
                            }
                            else
                            {
                                sb.Append(generic);
                            }
                            sb.Append(',');
                        }
                        sb.RemoveLast(",");
                        sb.Append("}");
                    }
                    sb.Append('.');
                }
                sb.RemoveLast(".");
                return sb.ToString();
            }
        }

        public static string GetDocumentString(this MethodInfo method)
        {
            var sb = new StringBuilder();
            sb.Append("M:");
            sb.Append(GetDocumentStringInternal(method.DeclaringType));
            sb.Append('.');
            sb.Append(method.Name);
            if (method.IsGenericMethod)
            {
                var generics = method.GetGenericArguments();
                sb.Append("``").Append(generics.Length);
            }
            var parameters = method.GetParameters();
            if (parameters.Length > 0)
            {
                sb.Append("(");
                foreach (var parameter in parameters)
                {
                    sb.Append(GetParameterDocumentString(parameter.ParameterType));
                    sb.Append(",");
                }
                sb.RemoveLast(",");
                sb.Append(")");
            }
            return sb.ToString();
        }

        public static string GetDocumentString(this FieldInfo field)
        {
            var sb = new StringBuilder();
            sb.Append("F:");
            sb.Append(GetDocumentStringInternal(field.DeclaringType));
            sb.Append(".");
            sb.Append(field.Name);
            return sb.ToString();
        }

        public static string GetDocumentString(this PropertyInfo property)
        {
            var sb = new StringBuilder();
            sb.Append("P:");
            sb.Append(GetDocumentStringInternal(property.DeclaringType));
            sb.Append(".");
            sb.Append(property.Name);
            return sb.ToString();
        }


    }

}
