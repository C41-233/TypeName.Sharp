using System;
using TypeName.Filter;

namespace TypeName
{
    public static class TypeNameExtend
    {

        public static ITypeName GetTypeName(this Type type, TypeNameFlag flags = TypeNameFlag.Default)
        {
            var name = TypeNameFactory.Create(type, flags);
            var filter = new NamespaceFilter();
            name.FilterNamespace(filter);
            filter.ClearNamespace();
            return name;
        }

        public static ITypeName GetTypeFullName(this Type type, TypeNameFlag flags = TypeNameFlag.Default)
        {
            return TypeNameFactory.Create(type, flags);
        }

        public static string GetTypeNameString(this Type type, TypeNameFlag flags = TypeNameFlag.Default)
        {
            return GetTypeName(type, flags).ToString();
        }

        public static string GetTypeFullNameString(this Type type, TypeNameFlag flags = TypeNameFlag.Default)
        {
            return GetTypeFullName(type, flags).ToString();
        }

    }
}
