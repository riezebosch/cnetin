using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericsDemo.Tests
{
    class Persoon : IComparable
    {
        public int CompareTo(object obj)
        {
            return -1;

        }

    }
}
