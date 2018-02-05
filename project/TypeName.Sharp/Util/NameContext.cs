using System.Collections.Generic;

namespace TypeName.Util
{
    internal sealed class NameContext
    {

        private struct TypeNameContext
        {
            public string Namespace;
            public List<TypeName> Names;

            public TypeNameContext(string ns)
            {
                Namespace = ns;
                Names = new List<TypeName>();
            }
        }

        private readonly HashSet<NameIdentify> badIdentifies = new HashSet<NameIdentify>();
        private readonly List<TypeName> badNames = new List<TypeName>();

        internal void Add(TypeName name)
        {
            
        }

    }
}
