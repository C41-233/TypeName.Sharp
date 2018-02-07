using System;
using TypeName.Filter;

namespace TypeName
{
    public static class TypeNameExtend
    {

        public static ITypeName GetTypeName(this Type type, TypeNameFlag flags)
        {
            var name = TypeNameFactory.Create(type, flags);
            var filter = new NamespaceFilter();
            name.FilterNamespace(filter);
            name.ClearNamespace(filter);
            return name;
        }

        public static ITypeName GetTypeFullName(this Type type, TypeNameFlag flags)
        {
            return TypeNameFactory.Create(type, flags);
        }

        public static string GetTypeNameString(this Type type)
        {
            return GetTypeName(type, TypeNameFlag.Default).ToString();
        }

        public static string GetTypeFullNameString(this Type type)
        {
            return GetTypeFullName(type, TypeNameFlag.Default).ToString();
        }

        public static string GetTypeNameString(this Type type, TypeNameFlag flags)
        {
            return GetTypeName(type, flags).ToString();
        }

        public static string GetTypeFullNameString(this Type type, TypeNameFlag flags)
        {
            return GetTypeFullName(type, flags).ToString();
        }

    }
}
