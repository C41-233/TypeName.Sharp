using System;

namespace TypeName
{
    internal sealed class GenericParameterTypeName : TypeName
    {

        public override string Name { get; }

        internal GenericParameterTypeName(Type type) : base(type)
        {
            Name = type.Name;
        }
    }
}
