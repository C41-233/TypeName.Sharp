using System.Reflection;
using System.Text;
using TypeName.Container;
using TypeName.Filter;

namespace TypeName
{
    internal sealed class MethodName : IMethodName
    {

        public MethodInfo Method { get; }
        public ITypeName ReturnType { get; }
        public ITypeName ExplicitInterface { get; }
        public string Name { get; }
        public GenericList Generics { get; }
        public ParameterList Parameters { get; }

        public MethodName(MethodInfo method, TypeNameFlag flags)
        {
            Method = method;
            ReturnType = TypeNameFactory.Create(method.ReturnType, flags);

            if (!method.Name.Contains("."))
            {
                Name = method.Name;
                ExplicitInterface = null;
            }
            else
            {
                var iSplit = method.Name.LastIndexOf('.');
                var interfacePart = method.Name.Substring(0, iSplit);
                Name = method.Name.Substring(iSplit + 1);
                var interfaceType = method.DeclaringType.GetInterface(interfacePart);
                ExplicitInterface = TypeNameFactory.Create(interfaceType, flags);
            }

            Generics = new GenericList();
            if (method.IsGenericMethod)
            {
                foreach (var generic in method.GetGenericArguments())
                {
                    Generics.Add(TypeNameFactory.Create(generic, flags));
                }
            }

            Parameters = new ParameterList();
            foreach (var parameter in method.GetParameters())
            {
                Parameters.Add(new ParameterName(parameter, flags));
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            ToString(sb);
            return sb.ToString();
        }

        public void FilterNamespace(NamespaceFilter filter)
        {
            ReturnType.FilterNamespace(filter);
            ExplicitInterface?.FilterNamespace(filter);
            foreach (var name in Generics)
            {
                name.FilterNamespace(filter);
            }
            foreach (var parameter in Parameters)
            {
                parameter.TypeName.FilterNamespace(filter);
            }
        }

        public void ToString(StringBuilder sb)
        {
            ReturnType.ToString(sb);
            sb.Append(" ");
            if (ExplicitInterface != null)
            {
                sb.Append(ExplicitInterface);
                sb.Append('.');
            }
            sb.Append(Name);
            Generics.ToString(sb);
            Parameters.ToString(sb);
        }
    }
}
