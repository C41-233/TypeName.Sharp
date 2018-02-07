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
        public override NullableName Nullable { get; }

        internal NullableTypeName(Type type, TypeNameFlag flags) : base(type)
        {
            var component = type.GetGenericArguments()[0];
            var componentType = TypeNameFactory.Create(component, flags);

            if (flags.Has(TypeNameFlag.FullNullable))
            {
                Namespace = new Namespace(type.Namespace);
                BaseNames = BaseNameList.Empty;
                Name = nameof(Nullable);
                Generics = new GenericList {componentType};
                Nullable = NullableName.False;
            }
            else
            {
                Namespace = componentType.Namespace;
                BaseNames = componentType.BaseNames;
                Name = componentType.Name;
                Generics = GenericList.Empty;
                Nullable = NullableName.True;
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

        public override void ClearNamespace(NamespaceFilter filter)
        {
            if (!filter.IsNeedFullName(this))
            {
                Namespace.Clear();
            }
            foreach (var type in Generics)
            {
                type.ClearNamespace(filter);
            }
        }
    }
}
