using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    public class UserCollection<T> : IEnumerable<T>, IEnumerator<T>
    {
        readonly T[] elements = new T[4];

        public T this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }

        int position = -1;

        // Implementácia rozhrania IEnumerator <T>:
        bool IEnumerator.MoveNext()
        {
            if (position < elements.Length - 1)
            {
                position++;
                return true;
            }
            return false;
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get { return elements[position]; }
        }

        T IEnumerator<T>.Current
        {
            get { return elements[position]; }
        }

        // Implementácia rozhrania IEnumerable <T>:
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this;
        }

        // Implementácia rozhrania IDisposable:
        void IDisposable.Dispose()
        {
            ((IEnumerator)this).Reset();
        }
    }
}
