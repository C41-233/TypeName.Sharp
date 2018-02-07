using System;

namespace TypeName
{
    internal static class TypeNameFactory
    {

        internal static TypeName Create(Type type, TypeNameFlag flags)
        {
            if (SimpleTypeName.IsSimpleType(type))
            {
                return new SimpleTypeName(type, flags);
            }
            if (type.IsArray)
            {
                return new ArrayTypeName(type, flags);
            }
            if (type.IsGenericParameter)
            {
                return new GenericParameterTypeName(type, flags);
            }
            if (type.IsGenericType)
            {
                if (type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    return new NullableTypeName(type, flags);
                }
                return new GenericTypeName(type, flags);
            }
            return new DirectTypeName(type);
        }

    }
}
