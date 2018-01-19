using System;
using System.Collections.Generic;

namespace TypeName.Utility
{
    internal static class EmptyEnumerator
    {
        public static IEnumerator<Type> Instance = new List<Type>().GetEnumerator(); 
    }
}
