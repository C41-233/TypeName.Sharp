using System;
using TypeName.Util;

namespace TypeName
{
    public static class TypeNameExtend
    {

        public static ITypeName GetTypeName(this Type type, NameFlag flags)
        {
            var name = TypeNameFactory.Create(type, flags);
            if (flags.Has(NameFlag.NoNamespace))
            {
                var context = new NameContext();
                name.SetNoNamespaceIfPossible(context);
            }
            return name;
        }

        public static string GetTypeNameString(this Type type)
        {
            return GetTypeName(type, NameFlag.NoNamespace).ToString();
        }

        public static string GetTypeFullNameString(this Type type)
        {
            return GetTypeName(type, NameFlag.Default).ToString();
        }

    }
}
