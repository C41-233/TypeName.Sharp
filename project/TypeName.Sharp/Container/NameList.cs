using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TypeName.Container
{
    public abstract class NameList<T> : INameList<T>
    {

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public abstract T this[int index] { get; }

        public abstract int Count { get; }

        public bool IsEmpty => Count == 0;

        public abstract void ToString(StringBuilder sb);
    }
}
