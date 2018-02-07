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
        public virtual NullableName Nullable => NullableName.False;
        public virtual ArrayRankList ArrayRanks => ArrayRankList.Empty;

        protected TypeName(Type type)
        {
            Type = type;
        }

        internal void ToString(StringBuilder sb)
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
            if (!Generics.IsEmpty)
            {
                Generics.ToString(sb);
            }
            sb.Append(Nullable);
            if (!ArrayRanks.IsEmpty)
            {
                ArrayRanks.ToString(sb);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            ToString(sb);
            return sb.ToString();
        }

        public virtual void FilterNamespace(NamespaceFilter filter)
        {
        }

        public virtual void ClearNamespace(NamespaceFilter filter)
        {
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

    }
}
