using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypeName.Utility;

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable HeuristicUnreachableCode
// ReSharper disable ExpressionIsAlwaysNull

namespace TypeName
{
    internal partial class NameToken
    {

        private NameToken(Type type, string name, string ns)
        {
            Type = type;
            Name = name;
            Namespace = ns;
        }

        private static readonly Dictionary<Type, string> SimpleNames = new Dictionary<Type, string>();

        static NameToken()
        {
            SimpleNames[typeof(byte)] = "byte";
            SimpleNames[typeof(char)] = "char";
            SimpleNames[typeof(short)] = "short";
            SimpleNames[typeof(int)] = "int";
            SimpleNames[typeof(long)] = "long";
            SimpleNames[typeof(ushort)] = "ushort";
            SimpleNames[typeof(uint)] = "uint";
            SimpleNames[typeof(ulong)] = "ulong";
            SimpleNames[typeof(float)] = "float";
            SimpleNames[typeof(double)] = "double";
            SimpleNames[typeof(decimal)] = "decimal";
            SimpleNames[typeof(void)] = "void";
            SimpleNames[typeof(string)] = "string";
        }

        public static NameToken Create(Type type)
        {
            if (type.IsGenericType)
            {
                return Create(type, type.GetGenericArguments().Cast<Type>().GetEnumerator());
            }
            return Create(type, EmptyEnumerator.Instance);
        }

        private static NameToken Create(Type type, IEnumerator<Type> generics)
        {
            if (type.IsGenericParameter)
            {
                return CreateGenericParameter(type);
            }
            if (type.DeclaringType != null)
            {
                return CreateInner(type, generics);
            }
            return CreateRoot(type, generics);
        }

        private static NameToken CreateRoot(Type type, IEnumerator<Type> generics)
        {
            if (SimpleNames.ContainsKey(type))
            {
                return CreateSimple(type);
            }
            if (type.IsArray)
            {
                return CreateArray(type);
            }
            if (type.IsGenericType == false)
            {
                return CreateDirect(type);
            }
            if (type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return CreateNullable(type);
            }
            return CreateGeneric(type, generics);
        }

        private static NameToken CreateSimple(Type type)
        {
            var name = SimpleNames[type];
            return new NameToken(type, name, null);
        }

        private static NameToken CreateDirect(Type type)
        {
            return new NameToken(type, type.Name, type.Namespace);
        }

        private static NameToken CreateNullable(Type type)
        {
            var element = type.GetGenericArguments()[0];
            var name = Create(element);
            name.Suffix += "?";
            return name;
        }

        private static NameToken CreateArray(Type type)
        {
            var sb = new StringBuilder();
            while (type.IsArray)
            {
                sb.Append('[');
                var rank = type.GetArrayRank();
                for (var i = 1; i < rank; i++)
                {
                    sb.Append(',');
                }
                sb.Append(']');
                type = type.GetElementType();
            }
            var name = Create(type);
            name.Suffix += sb.ToString();
            return name;
        }

        private static NameToken CreateGenericParameter(Type type)
        {
            return new NameToken(type, type.Name, null);
        }

        private static NameToken CreateInner(Type type, IEnumerator<Type> generics)
        {
            var super = type.DeclaringType;
            var parent = Create(super, generics);
            NameToken name;
            if (!type.IsGenericType)
            {
                name = CreateRoot(type, generics);
            }
            else
            {
                name = CreateGeneric(type, generics);
            }
            name.Parent = parent;
            return name;
        }

        private static NameToken CreateGeneric(Type type, IEnumerator<Type> generics)
        {
            var def = type.GetGenericTypeDefinition();

            var cName = type.Name;
            var iQuota = cName.IndexOf('`');
            cName = cName.Substring(0, iQuota);
            var iDot = cName.LastIndexOf('.');
            if (iDot >= 0)
            {
                cName = cName.Substring(iDot);
            }

            var ns = type.DeclaringType == null ? type.Namespace : null;

            var name = new NameToken(def, cName, ns);
            foreach (var genericArgument in type.GetGenericArguments())
            {
                if (!genericArgument.IsGenericParameter)
                {
                    generics.MoveNext();
                    name.GenericNameTokens.Add(Create(genericArgument, generics));
                }
                else
                {
                    generics.MoveNext();
                    var genericType = generics.Current;
                    name.GenericNameTokens.Add(Create(genericType, generics));
                }
            }
            return name;
        }

        private NameToken Parent;

        public readonly Type Type;

        private readonly string Name;

        private readonly string Namespace;

        public bool IsFullMode { get; set; }

        private readonly List<NameToken> GenericNameTokens = new List<NameToken>();

        private string Suffix = "";
    }

}
