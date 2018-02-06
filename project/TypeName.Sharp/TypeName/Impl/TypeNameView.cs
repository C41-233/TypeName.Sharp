using System;
using System.Text;
using TypeName.Container;

namespace TypeName
{
    internal sealed class TypeNameView : ITypeNameView
    {
        public Type Type { get; }
        public string Name { get; }

        INameList<ITypeName> ITypeNameView.Generics => Generics;

        public GenericList Generics { get; }

        internal TypeNameView(Type type)
        {
            Type = type;
            Name = type.Name;
            Generics = GenericList.Empty;
        }

        internal TypeNameView(Type type, GenericVisitor visitor, NameFlag flags)
        {
            Type = type;
            Generics = new GenericList();

            var genericName = type.Name;
            var iQuota = genericName.LastIndexOf('`');

            int lenGeneric;
            if (iQuota > 0)
            {
                Name = genericName.Substring(0, iQuota);
                lenGeneric = int.Parse(genericName.Substring(iQuota + 1));
            }
            else
            {
                Name = genericName;
                lenGeneric = 0;
            }

            for (int i = 0; i<lenGeneric; i++)
            {
                Generics.Add(TypeNameFactory.Create(visitor.Next(), flags));
            }
        }

        internal void ToString(StringBuilder sb)
        {
            sb.Append(Name);
            if (!Generics.IsEmpty)
            {
                Generics.ToString(sb);
            }
        }
    }
}