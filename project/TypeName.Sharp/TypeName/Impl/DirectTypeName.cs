using System;
using TypeName.Container;

// ReSharper disable HeuristicUnreachableCode
// ReSharper disable ConditionIsAlwaysTrueOrFalse
namespace TypeName
{
    internal sealed class DirectTypeName : TypeName
    {
        public override Namespace Namespace { get; }
        public override EnclosingNameList EnclosingNames { get; }
        public override string Name { get; }

        internal DirectTypeName(Type type) : base(type)
        {
            Namespace = new Namespace(type.Namespace);
            {
                EnclosingNames = new EnclosingNameList();
                var super = type.DeclaringType;
                while (super != null)
                {
                    EnclosingNames.AddBefore(new TypeNameView(super));
                    super = super.DeclaringType;
                }
            }
            Name = type.Name;
        }

    }
}
