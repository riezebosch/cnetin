using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericsDemo.Tests
{
    delegate bool VerwijderDelegate<T>(T item);

    class SortedList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        LinkedList<T> items = new LinkedList<T>();

        public void Add(T item)
        {
            var node = items.First;

            while (node != null &&
                node.Value.CompareTo(item) < 0)
            {
                node = node.Next;
            }

            if (node == null)
            {
                items.AddLast(item);
            }
            else
            {
                items.AddBefore(node, item);
            }
        }

        public T this[int index]
        {
            get { return items.ElementAt(index); }

        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Remove(T item)
        {
            var node = items.First;
            while (node != null && node.Value.CompareTo(item) <= 0)
            {
                var next = node.Next;
                if (node.Value.Equals(item))
                {
                    items.Remove(node);
                }

                node = next;
            }
        }

        
        public void Remove(VerwijderDelegate<T> vergelijk)
        {
            var node = items.First;
            while (node != null)
            {
                var next = node.Next;
                if (vergelijk(node.Value))
                {
                    items.Remove(node);
                }

                node = next;
            }
        }
    }
}
