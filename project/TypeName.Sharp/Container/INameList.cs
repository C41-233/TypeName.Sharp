using System.Collections.Generic;

namespace TypeName.Container
{

    public interface INameList<T> : IEnumerable<T>
    {

        T this[int index] { get; }

        int Count { get; }

        bool IsEmpty { get; }

    }


}
