using System;
using System.Linq;
using TypeName.Container;
using TypeName.Util;

namespace TypeName
{
    internal sealed class DirectTypeName : TypeName
    {
        public override Namespace Namespace { get; }
        public override BaseNameList BaseNames { get; }
        public override string Name { get; }

        internal DirectTypeName(Type type) : base(type)
        {
            Namespace = new Namespace(type.Namespace);
            {
                BaseNames = new BaseNameList();
                var super = type.DeclaringType;
                while (super != null)
                {
                    BaseNames.AddBefore(new TypeNameView(super));
                    super = super.DeclaringType;
                }
            }
            Name = type.Name;
        }

        internal override void SetNoNamespaceIfPossible(NameContext context)
        {
            Namespace.Clear();
            foreach (var name in BaseNames.Cast<TypeName>())
            {
                name.SetNoNamespaceIfPossible(context);
            }
        }
    }
}
