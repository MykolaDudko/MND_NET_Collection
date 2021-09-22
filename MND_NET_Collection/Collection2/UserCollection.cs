using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// ICollection <T> - definuje metódy používané na správu generických kolekcií.

namespace Collection
{
    class UserCollection<T> : ICollection<T>
    {
        T[] elements = new T[0];

        // Pridá položku do rozhrania ICollection <T>.
        public void Add(T item)
        {
            var newArray = new T[elements.Length + 1]; // Vytvori nové pole (o 1 viac ako staré).
            elements.CopyTo(newArray, 0);              // Skopírujte staré pole do nového.
            newArray[newArray.Length - 1] = item;      // Novú hodnotu umiestnite na koniec poľa.
            elements = newArray;                       // Vymena starého pole za nové.
        }

        // Odstráni všetky položky z kolekcie ICollection <T>
        public void Clear()
        {
            elements = new T[0];
        }

        // Určuje, či rozhranie ICollection <T> obsahuje zadanú hodnotu.
        public bool Contains(T item)
        {
            foreach (var element in elements)
            {
                if (element.Equals(item))
                    return true;
            }

            return false; 

            ////AJ takto LINQ :)
            return elements.Contains(item);
        }

        // Skopíruje prvky ICollection <T> do poľa, počnúc konkrétnym indexom v poli.
        public void CopyTo(T[] array, int arrayIndex)
        {
            elements.CopyTo(array, arrayIndex);
        }

        // Zistí počet prvkov obsiahnutých v rozhraní ICollection <T>.
        public int Count
        {
            get { return elements.Length; }
        }

        // Získa hodnotu, ktorá označuje, či je ICollection <T> len na čítanie.
        public bool IsReadOnly
        {
            get { return false; }
        }

        // Odstráni prvý výskyt zadaného objektu z kolekcie ICollection <T>.
        public bool Remove(T item)
        {
            throw new NotImplementedException(); 
        }

        // Vráti enumerátor, ktorý iteruje prvky v kolekcii. (Zdedené z IEnumerable <T>.)
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>) elements).GetEnumerator();
        }

        // Vráti enumerátor, ktorý iteruje prvky kolekcie. (Zdedené z IEnumerable)
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<T>).GetEnumerator();
        }
    }
}
