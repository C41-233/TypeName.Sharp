using System.Collections.Generic;
using System.Text;

namespace TypeName.Container
{

    public interface INameList<T> : IEnumerable<T>
    {

        T this[int index] { get; }

        int Count { get; }

        bool IsEmpty { get; }

        void ToString(StringBuilder sb);
    }


}
