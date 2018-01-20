using System;
using System.Collections.Generic;
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
            if (SimpleNames.ContainsKey(type))
            {
                return CreateSimple(type);
            }
            if (type.IsArray)
            {
                return CreateArray(type);
            }
            if (type.IsGenericParameter)
            {
                return CreateGenericParameter(type);
            }
            if (type.DeclaringType != null)
            {
                return CreateInner(type);
            }
            if (type.IsGenericType == false)
            {
                return CreateDirect(type);
            }
            if (type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return CreateNullable(type);
            }
            return CreateGeneric(type);
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

        private static NameToken CreateInner(Type type)
        {
            if (type.IsGenericType)
            {
                return CreateGeneric(type);
            }

            var super = type.DeclaringType;
            var parent = Create(super);

            var name = CreateDirect(type);
            name.Parent = parent;
            return name;
        }

        private static NameToken CreateGeneric(Type type)
        {
            return CreateGeneric(type, new GenericList(type));
        }

        private static NameToken CreateGeneric(Type type, GenericList generics)
        {
            NameToken parent = null;
            string ns = null;
            int genericPosition = 0;

            if (type.DeclaringType != null)
            {
                if (type.DeclaringType.IsGenericType)
                {
                    parent = CreateGeneric(type.DeclaringType, generics);
                    genericPosition = type.DeclaringType.GetGenericArguments().Length;
                }
                else
                {
                    parent = Create(type.DeclaringType);
                }
            }
            else
            {
                ns = type.Namespace;
            }


            var cName = type.Name;
            var iQuota = cName.IndexOf('`');
            if (iQuota >= 0)
            {
                cName = cName.Substring(0, iQuota);
            }

            var name = new NameToken(type.GetGenericTypeDefinition(), cName, ns)
            {
                Parent = parent
            };

            var genericArguments = type.GetGenericArguments();

            for(var i = genericPosition; i < genericArguments.Length; i++)
            {
                var genericArgument = genericArguments[i];
                var genericType = generics.Next();

                if (genericArgument.IsGenericParameter)
                {
                    name.GenericNameTokens.Add(Create(genericType));
                }
                else
                {
                    name.GenericNameTokens.Add(Create(genericArgument));
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
