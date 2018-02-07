using System.Collections.Generic;

namespace TypeName.Filter
{

    public sealed class NamespaceFilter
    {

        private struct TypeNameContext
        {
            public readonly string Namespace;
            public readonly List<TypeName> Names;

            public TypeNameContext(string ns)
            {
                Namespace = ns;
                Names = new List<TypeName>();
            }
        }

        private readonly Dictionary<NameIdentity, TypeNameContext> identityToContext = new Dictionary<NameIdentity, TypeNameContext>();

        private readonly HashSet<NameIdentity> badIdentities = new HashSet<NameIdentity>();
        private readonly List<TypeName> badNames = new List<TypeName>();

        internal void Add(TypeName name)
        {
            var identity = name.NameIdentity;
            if (badIdentities.Contains(identity))
            {
                badNames.Add(name);
                return;
            }

            TypeNameContext context;
            if (!identityToContext.TryGetValue(identity, out context))
            {
                context = new TypeNameContext(name.Namespace.FullName);
                context.Names.Add(name);
                identityToContext.Add(identity, context);
                return;
            }

            if (context.Namespace == name.Namespace.FullName)
            {
                context.Names.Add(name);
                return;
            }

            badIdentities.Add(identity);
            badNames.AddRange(context.Names);
            badNames.Add(name);
            identityToContext.Remove(identity);
        }

        internal bool IsNeedFullName(TypeName name)
        {
            return badNames.Contains(name);
        }

    }
}
