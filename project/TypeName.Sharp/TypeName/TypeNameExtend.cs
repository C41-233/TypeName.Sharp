using System;
using TypeName.Filter;

namespace TypeName
{
    public static class TypeNameExtend
    {

        public static ITypeName GetTypeName(this Type type, NameFlag flags)
        {
            var name = TypeNameFactory.Create(type, flags);
            var context = new NamespaceFilter();
            name.FilterNamespace(context);
            name.ClearNamespace(context);
            return name;
        }

        public static ITypeName GetTypeFullName(this Type type, NameFlag flags)
        {
            return TypeNameFactory.Create(type, flags);
        }

        public static string GetTypeNameString(this Type type)
        {
            return GetTypeName(type, NameFlag.Default).ToString();
        }

        public static string GetTypeFullNameString(this Type type)
        {
            return GetTypeFullName(type, NameFlag.Default).ToString();
        }

        public static string GetTypeNameString(this Type type, NameFlag flags)
        {
            return GetTypeName(type, flags).ToString();
        }

        public static string GetTypeFullNameString(this Type type, NameFlag flags)
        {
            return GetTypeFullName(type, flags).ToString();
        }

    }
}
