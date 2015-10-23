using System;

namespace GenericsDemo.Tests
{
    class Persoon: IComparable
    {
        public Persoon()
        {

        }

        public Persoon(string naam)
        {
            this.Naam = naam;
        }
        public string Naam { get; set; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}