using System;
using System.Collections;

namespace Collection
{
    class SimpleList : IList //, ICollection, IEnumerable
    {
        private readonly object[] contents = new object[8];
        private int count;

        public SimpleList()
        {
            count = 0;
        }

        #region IList Members

        /// <summary>
        /// Pridá položku do zoznamu IList.
        /// </summary>
        /// <param name="value">Položka, ktorá má byť zaradená do kolekcie.</param>
        /// <returns>Index položky, ktorá je zaradená do kolekie.</returns>
        public int Add(object value)
        {
            if (count < contents.Length)
            {
                contents[count] = value;
                count++;

                return (count - 1);
            }
            return -1;
        }

        // Odstráni všetky položky z kolekcie IList.
        public void Clear()
        {
            count = 0;
        }

        // Určuje, či je zadaná hodnota obsiahnutá v kolekcie IList.
        public bool Contains(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (contents[i] == value)
                    return true;
            }
            return false;
        }

        // Určuje index danej položky v IList.
        public int IndexOf(object value)
        {
            for (int i = 0; i < Count; i++)
                if (contents[i] == value)
                    return i;
            return -1;
        }

        // Vloží element do IListu v danom indexe.
        public void Insert(int index, object value)
        {
            if ((count + 1 <= contents.Length) && (index < Count) && (index >= 0))
            {
                count++;

                for (int i = Count - 1; i > index; i--)
                {
                    contents[i] = contents[i - 1];
                }
                contents[index] = value;
            }
        }

        // Získa hodnotu, ktorá označuje, či IList má pevnú veľkosť.
        public bool IsFixedSize
        {
            get { return true; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Remove(object value)
        {
            RemoveAt(IndexOf(value));
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                    contents[i] = contents[i + 1];

                count--;
            }
        }

        public object this[int index]
        {
            get
            {
                return contents[index];
            }
            set
            {
                contents[index] = value;
            }
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            int j = index;
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(contents[i], j);
                j++;
            }
        }

        public int Count
        {
            get { return count; }
        }

        // Získa hodnotu, ktorá označuje, či je prístup k kolekcii ICollection synchronizovaný (bezpečný pre vlákna).
        public bool IsSynchronized
        {
            get { return false; }
        }

        // Získa objekt, ktorý je možné použiť na synchronizáciu prístupu k kolekcii ICollection.
        public object SyncRoot
        {
            get { return null; }
        }

        #endregion

        #region IEnumerable Members

        // Vráti enumerátor, ktorý iteruje prvky kolekcie. (Implementácia IEnumerable.)
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return contents[i];
            }
        }

        #endregion

        public void PrintContents()
        {
            Console.WriteLine("contents {0} count {1} elemntu.", contents.Length, count);
            Console.Write("List obsahuje:");

            for (int i = 0; i < Count; i++)
                Console.Write(" {0}", contents[i]);

            Console.WriteLine("\n" + new string('-', 55));
        }
    }
}
