using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericsDemo
{
    public class AutoResizeArray<T> : IEnumerable
        where T: IComparable
    {
        private int max;
        private T[] items = new T[4];

        public void Add(T getal)
        {
            EnsureSize();
            items[max++] = getal;
        }

        private void EnsureSize()
        {
            T[] temp = new T[items.Length * 2];
            for (int index = 0; index < items.Length; index++)
            {
                temp[index] = items[index];
            }

            items = temp;
        }

        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public int Length 
        { 
            get 
            { 
                return max; 
            } 
        }

        public T this[int index]
        {
            get { return items[index]; }
        }



        public void Sort()
        {
            for (int j = 0; j < max; j++)
            {

                for (int i = 0; i < max - 1; i++)
                {
                    if (items[i].CompareTo(items[i + 1]) > 0)
                    {
                        T temp = items[i];
                        items[i] = items[i + 1];
                        items[i + 1] = temp;
                    }
                }
            }
        }


        public TResult Iets<TInput, TResult>(TInput input)
            where TResult: new()
        {
            if (input == null)
            {
                return default(TResult);
            }

            if (input is int)
            {
                int i = (int)(object)input;
            }

            return new TResult();
        }

        public void Iets<TInput>(TInput input)
        {
            if (input != null)
            {
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine("input is null");
            }
        }
    }
}
