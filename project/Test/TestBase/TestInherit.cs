using System.Collections.Generic;

namespace TestBase
{
    public class TestInherit<T> : List<int>
    {
    }

    public class TestInherit<T, K> : List<K>
    {
        
    }
}
