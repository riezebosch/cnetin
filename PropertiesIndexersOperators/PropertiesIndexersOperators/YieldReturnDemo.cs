using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PropertiesIndexersOperators
{
    [TestClass]
    public class YieldReturnDemo
    {
        public IEnumerable<int> AlleGeheleGetallen()
        {
            yield return 0;
            yield return 1;
            yield return 0;
            yield return 1;
            yield return 0;
            yield return 1;
            yield return 0;

            int[] items = { 2, 2, 2, 2, 2, 2, 2, 2, 2 };
            foreach (var item in items)
            {
                yield return item;
            }

            int i = 0;
            while(true)
            {
                yield return i++;
            }
        }

        public IEnumerable<int> FilterAlleOnevenGetallenEruit(IEnumerable<int> items)
        {
            foreach (var item in items)
            {
                if (item % 2 == 0)
                {
                    yield return item;
                }
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            foreach (var item in FilterAlleOnevenGetallenEruit(AlleGeheleGetallen()))
            {
                Console.WriteLine(item);
                if (item == 100)
                {
                    break;
                }
            }
        }
    }
}
