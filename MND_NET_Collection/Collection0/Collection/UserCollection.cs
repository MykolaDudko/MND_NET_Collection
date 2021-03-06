using System;
using System.Collections;

namespace Collection
{
    // Trieda predstavujúca vlastnú kolekciu.
    public class UserCollection
    {
        readonly Element[] elements = new Element[4];

        public Element this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }

        int position = -1;

        // Implementácia rozhrania IEnumerator:

        public bool MoveNext()
        {
            if (position < elements.Length - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get { return elements[position]; }
        }

        // Implementácia rozhrania IEnumerable:

        public UserCollection GetEnumerator()
        {
            return this;
        }
    }
}
