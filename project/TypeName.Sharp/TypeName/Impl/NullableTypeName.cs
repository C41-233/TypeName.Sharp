using System;
using System.Linq;
using TypeName.Container;
using TypeName.Util;

namespace TypeName
{
    internal sealed class NullableTypeName : TypeName
    {
        public override Namespace Namespace { get; }
        public override BaseNameList BaseNames { get; }
        public override string Name { get; }
        public override GenericList Generics { get; }
        public override bool Nullable { get; }

        internal NullableTypeName(Type type, NameFlag flags) : base(type)
        {
            var component = type.GetGenericArguments()[0];
            var componentType = TypeNameFactory.Create(component, flags);

            if (flags.Has(NameFlag.FullNullable))
            {
                Namespace = new Namespace(type.Namespace);
                BaseNames = BaseNameList.Empty;
                Name = nameof(Nullable);
                Generics = new GenericList {componentType};
                Nullable = false;
            }
            else
            {
                Namespace = componentType.Namespace;
                BaseNames = componentType.BaseNames;
                Name = componentType.Name;
                Generics = GenericList.Empty;
                Nullable = true;
            }
        }

        internal override void SetNoNamespaceIfPossible(NameContext context)
        {
            Namespace.Clear();
            foreach (var type in Generics.Cast<TypeName>())
            {
                type.SetNoNamespaceIfPossible(context);
            }
        }
    }
}
