using System;
using System.Collections;

// ICollection - definuje veľkosť, enumerátory a metódy synchronizácie pre všetky kolekcie.

namespace Collection
{
    class UserCollection : ICollection
    {
        readonly object syncRoot = new object();

        readonly object[] elements = { 1, 2, 3, 4 };

        // Kopirujem element ICollection v Array, zacinam podla Indexa Array
        public void CopyTo(Array array, int userArrayIndex)
        {
            var arr = array as object[];

            if (arr == null)
                throw new ArgumentException("Expecting array to be object[]");

            for (int i = 0; i < array.Length; i++)
            {
                arr[userArrayIndex++] = elements[i];
            }
        }

        // Vraca cislo elementu, ulozene v kolekci ICollection
        public int Count
        {
            get { return elements.Length; }
        }

        // Získa hodnotu, ktorá označuje, či je prístup k kolekcii ICollection synchronizovaný (bezpečnost pre vlákna).

        public bool IsSynchronized
        {
            get { return true; }
        }

        // Získa objekt, ktorý je možné použiť na synchronizáciu prístupu k kolekcii ICollection.
        public object SyncRoot
        {
            get { return syncRoot; }
        }

        // Vráti enumerátor, ktorý iteruje prvky kolekcie. (Zdedené z IEnumerable.)
        public IEnumerator GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    }
}
