using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericsDemo.Tests
{
    class Persoon : IComparable<Persoon>, IComparable
    {
        public string Naam { get; set; }

        public int CompareTo(Persoon other)
        {
            return this.Naam.CompareTo(other.Naam);
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo(obj as Persoon);
        }
    }
}
