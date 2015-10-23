using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsDemo
{
    public class SortedList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        LinkedList<T> items = new LinkedList<T>();
        public void Add(T item)
        {
            // search in "items" for correct position
            // and add new item there
            var node = items.First;
            while (node != null && node.Value.CompareTo(item) < 0)
            {
                node = node.Next;
            }

            if (node == null)
            {
                items.AddLast(new LinkedListNode<T>(item));
            }
            else
            {
                items.AddBefore(node, new LinkedListNode<T>(item));
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                var node = items.First;
                while (node != null && index-- > 0)
                {
                    node = node.Next;
                }

                if (node == null)
                {
                    throw new IndexOutOfRangeException();
                }

                return node.Value;
            }
        }

        public static SortedList<T> operator +(SortedList<T> list, T item)
        {
            list.Add(item);
            return list;
        }

        public static implicit operator SortedList<T>(T item)
        {
            return new SortedList<T> { item };
        }
    }
}