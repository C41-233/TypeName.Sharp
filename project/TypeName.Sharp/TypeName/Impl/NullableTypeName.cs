using System;
using TypeName.Container;
using TypeName.Filter;

namespace TypeName
{
    internal sealed class NullableTypeName : TypeName
    {
        public override Namespace Namespace { get; }
        public override BaseNameList BaseNames { get; }
        public override string Name { get; }
        public override GenericList Generics { get; }
        public override string Sign { get; }

        internal NullableTypeName(Type type, TypeNameFlag flags) : base(type)
        {
            var component = type.GetGenericArguments()[0];
            var componentType = TypeNameFactory.Create(component, flags);

            if (flags.Has(TypeNameFlag.FullNullable))
            {
                Namespace = new Namespace(type.Namespace);
                BaseNames = BaseNameList.Empty;
                Name = nameof(Sign);
                Generics = new GenericList {componentType};
                Sign = null;
            }
            else
            {
                Namespace = componentType.Namespace;
                BaseNames = componentType.BaseNames;
                Name = componentType.Name;
                Generics = GenericList.Empty;
                Sign = SignConstant.Nullable;
            }
        }

        public override void FilterNamespace(NamespaceFilter filter)
        {
            filter.Add(this);
            foreach (var type in Generics)
            {
                type.FilterNamespace(filter);
            }
        }

    }
}
