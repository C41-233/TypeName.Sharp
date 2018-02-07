using System;
using TypeName.Container;
using TypeName.Filter;

// ReSharper disable HeuristicUnreachableCode
// ReSharper disable ConditionIsAlwaysTrueOrFalse
namespace TypeName
{
    internal sealed class DirectTypeName : TypeName
    {
        public override Namespace Namespace { get; }
        public override BaseNameList BaseNames { get; }
        public override string Name { get; }

        internal DirectTypeName(Type type) : base(type)
        {
            Namespace = new Namespace(type.Namespace);
            {
                BaseNames = new BaseNameList();
                var super = type.DeclaringType;
                while (super != null)
                {
                    BaseNames.AddBefore(new TypeNameView(super));
                    super = super.DeclaringType;
                }
            }
            Name = type.Name;
        }

        public override void FilterNamespace(NamespaceFilter filter)
        {
            filter.Add(this);
        }

        public override void ClearNamespace(NamespaceFilter filter)
        {
            if (!filter.IsNeedFullName(this))
            {
                Namespace.Clear();
            }
        }
    }
}
