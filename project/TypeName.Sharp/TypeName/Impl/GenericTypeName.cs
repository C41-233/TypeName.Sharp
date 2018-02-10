using System;
using TypeName.Container;

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable HeuristicUnreachableCode
namespace TypeName
{
    internal sealed class GenericTypeName : TypeName
    {

        public override Namespace Namespace { get; }
        public override BaseNameList BaseNames { get; }
        public override string Name { get; }
        public override GenericList Generics { get; }

        public GenericTypeName(Type type, TypeNameFlag flags) : base(type)
        {
            Namespace = new Namespace(type.Namespace);
            BaseNames = new BaseNameList();
            Generics = new GenericList();

            var visitor = new GenericVisitor(type);

            {
                var super = type.DeclaringType;
                while (super != null)
                {
                    if (super.IsGenericType)
                    {
                        BaseNames.AddBefore(new TypeNameView(super, visitor, flags));
                    }
                    else
                    {
                        BaseNames.AddBefore(new TypeNameView(super));
                    }
                    super = super.DeclaringType;
                }
            }

            var genericName = type.Name;
            var iQuota = genericName.LastIndexOf('`');

            int lenGeneric;
            if (iQuota > 0)
            {
                Name = iQuota < 0 ? genericName : genericName.Substring(0, iQuota);
                lenGeneric = int.Parse(genericName.Substring(iQuota + 1));
            }
            else
            {
                Name = genericName;
                lenGeneric = 0;
            }

            for (var i=0; i<lenGeneric; i++)
            {
                Generics.Add(TypeNameFactory.Create(visitor.Next(), flags));
            }
        }

    }
}
