using System;
using System.Text;
using TypeName.Container;
using TypeName.Util;

namespace TypeName
{
    internal abstract class TypeName : ITypeName
    {
        public Type Type { get; }
        public virtual Namespace Namespace => Namespace.Empty;
        public virtual BaseNameList BaseNames => BaseNameList.Empty;
        public virtual string Name => Type.Name;
        public virtual GenericList Generics => GenericList.Empty;
        public virtual bool Nullable => false;
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
            if (Nullable)
            {
                sb.Append('?');
            }
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

        internal virtual void SetNoNamespaceIfPossible(NameContext context)
        {
        }

    }
}
