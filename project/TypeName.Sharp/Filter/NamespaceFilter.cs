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
        private readonly HashSet<TypeName> badNames = new HashSet<TypeName>();
        private readonly HashSet<TypeName> allNames = new HashSet<TypeName>();

        internal void Add(TypeName name)
        {
            if (!allNames.Add(name))
            {
                return;
            }

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
            foreach (var n in context.Names)
            {
                badNames.Add(n);
            }
            badNames.Add(name);
            identityToContext.Remove(identity);
        }

        public void ClearNamespace()
        {
            foreach (var name in allNames)
            {
                if (!badNames.Contains(name))
                {
                    name.Namespace.Clear();
                }
            }
        }

    }
}
