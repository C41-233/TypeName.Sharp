using System;
using TypeName.Container;

namespace TypeName
{
    internal sealed class NullableTypeName : TypeName
    {
        public override Namespace Namespace { get; }
        public override EnclosingNameList EnclosingNames { get; }
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
                EnclosingNames = EnclosingNameList.Empty;
                Name = nameof(Nullable);
                Generics = new GenericList {componentType};
                Sign = null;
            }
            else
            {
                Namespace = componentType.Namespace;
                EnclosingNames = componentType.EnclosingNames;
                Name = componentType.Name;
                Generics = GenericList.Empty;
                Sign = SignConstant.Nullable;
            }
        }

    }
}
