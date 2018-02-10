using System.Reflection;
using TypeName.Filter;

namespace TypeName
{
    public static class MethodNameExtend
    {

        public static string GetDefinitionNameString(this MethodInfo method, TypeNameFlag flags = TypeNameFlag.Default)
        {
            return null;
        }

        public static string GetDefinitionFullNameString(this MethodInfo method, TypeNameFlag flags = TypeNameFlag.Default)
        {
            return GetDefinitionFullName(method, flags).ToString();
        }

        public static IMethodName GetDefinitionFullName(this MethodInfo method, TypeNameFlag flags = TypeNameFlag.Default)
        {
            return new MethodName(method, flags);
        }

        public static IMethodName GetDefinitionName(this MethodInfo method, TypeNameFlag flags = TypeNameFlag.Default)
        {
            var name = new MethodName(method, flags);
            var filter = new NamespaceFilter();

            return name;
        }

    }
}
