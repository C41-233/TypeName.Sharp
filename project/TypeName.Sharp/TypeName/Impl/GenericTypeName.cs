using System;
using System.Collections.Generic;
using System.Linq;
using TypeName.Container;
using TypeName.Util;

namespace TypeName
{
    internal sealed class GenericTypeName : TypeName
    {

        public override Namespace Namespace { get; }
        public override BaseNameList BaseNames { get; }
        public override string Name { get; }
        public override GenericList Generics { get; }

        public GenericTypeName(Type type, NameFlag flags) : base(type)
        {
            Namespace = new Namespace(type.Namespace);
            BaseNames = new BaseNameList();
            Generics = new GenericList();

            var visitor = new GenericVisitor(type);

            {
                var supers = new List<Type>();
                {
                    var super = type.DeclaringType;
                    while (super != null)
                    {
                        supers.Add(super);
                        super = super.DeclaringType;
                    }
                }
                for (var i = supers.Count - 1; i >= 0; i--)
                {
                    var super = supers[i];
                    if (super.IsGenericType)
                    {
                        BaseNames.AddBefore(new TypeNameView(super, visitor, flags));
                    }
                    else
                    {
                        BaseNames.AddBefore(new TypeNameView(super));
                    }
                }
            }

            var genericName = type.Name;
            var iQuota = genericName.LastIndexOf('`');

            Name = genericName.Substring(0, iQuota);

            var lenGeneric = int.Parse(genericName.Substring(iQuota + 1));
            for (var i=0; i<lenGeneric; i++)
            {
                Generics.Add(TypeNameFactory.Create(visitor.Next(), flags));
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
