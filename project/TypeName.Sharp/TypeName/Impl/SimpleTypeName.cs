using System;
using System.Collections.Generic;
using TypeName.Container;

namespace TypeName
{
    internal sealed class SimpleTypeName : TypeName
    {

        private static readonly Dictionary<Type, string> SimpleNames = new Dictionary<Type, string>();

        static SimpleTypeName()
        {
            SimpleNames[typeof(bool)] = "bool";
            SimpleNames[typeof(byte)] = "byte";
            SimpleNames[typeof(sbyte)] = "byte";
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

        internal static bool IsSimpleType(Type type)
        {
            return SimpleNames.ContainsKey(type);
        }

        public override Namespace Namespace { get; }
        public override string Name { get; }

        internal SimpleTypeName(Type type, TypeNameFlag flags) : base(type)
        {
            if (flags.Has(TypeNameFlag.FullPrimitive))
            {
                Namespace = new Namespace(type.Namespace);
                Name = type.Name;
            }
            else
            {
                Namespace = Namespace.Empty;
                Name = SimpleNames[type];
            }
        }

    }
}
