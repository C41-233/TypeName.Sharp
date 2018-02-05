using System;

namespace TypeName
{
    internal sealed class GenericVisitor
    {

        private readonly Type[] types;
        private int i = -1;

        public GenericVisitor(Type type)
        {
            types = type.GetGenericArguments();
        }

        public Type Next()
        {
            return types[++i];
        }

    }

}
