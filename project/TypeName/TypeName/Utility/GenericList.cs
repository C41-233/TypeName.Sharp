using System;

namespace TypeName.Utility
{

    internal class GenericList
    {

        private readonly Type[] types;
        private int i = -1;

        public GenericList(Type type)
        {
            types = type.GetGenericArguments();
        }

        public Type Next()
        {
            return types[++i];
        }

    }

}
