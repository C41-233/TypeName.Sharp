using System;
using System.Text;
using TypeName.Container;
using TypeName.Filter;

namespace TypeName
{
    internal abstract class TypeName : ITypeName
    {
        public Type Type { get; }
        public virtual Namespace Namespace => Namespace.Empty;
        public virtual BaseNameList BaseNames => BaseNameList.Empty;
        public virtual string Name => Type.Name;
        public virtual GenericList Generics => GenericList.Empty;
        public virtual string Sign => null;
        public virtual ArrayRankList ArrayRanks => ArrayRankList.Empty;

        protected TypeName(Type type)
        {
            Type = type;
        }

        public void ToString(StringBuilder sb)
        {
            if (!Namespace.IsEmpty)
            {
                Namespace.ToString(sb);
                sb.Append('.');
            }
            if (!BaseNames.IsEmpty)
            {
                BaseNames.ToString(sb);
                sb.Append('.');
            }
            sb.Append(Name);
            Generics.ToString(sb);
            if (Sign != null)
            {
                sb.Append(Sign);
            }
            ArrayRanks.ToString(sb);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            ToString(sb);
            return sb.ToString();
        }

        public void FilterNamespace(NamespaceFilter filter)
        {
            filter.Add(this);
            foreach (var name in Generics)
            {
                name.FilterNamespace(filter);
            }
        }

        internal NameIdentity NameIdentity
        {
            get
            {
                if (BaseNames.IsEmpty)
                {
                    return new NameIdentity(Name, Generics.Count);
                }
                var name = BaseNames[0];
                return new NameIdentity(name.Name, name.Generics.Count);
            }
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }
    }
}
