using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace GenericsDemo.Tests
{
    [TestClass]
    public class SortedListTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            SortedList<int> list = SortedList.Create<int>();
            list.Add(5);

            Assert.AreEqual(5, list[0]);
        }

        [TestMethod]
        public void Add3Before5()
        {
            SortedList<int> list = SortedList.Create<int>();
            list.Add(5);
            list.Add(3);

            Assert.AreEqual(3, list[0]);
            Assert.AreEqual(5, list[1]);
        }

        [TestMethod]
        public void Add5After3()
        {
            SortedList<int> list = SortedList.Create<int>();
            list.Add(3);
            list.Add(5);

            Assert.AreEqual(3, list[0]);
            Assert.AreEqual(5, list[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexOnEmptyListShouldThrow()
        {
            SortedList<int> list = SortedList.Create<int>();
            var item = list[0];
        }
        [TestMethod]
        public void SortedListShouldBeEnumerable()
        {
            SortedList<int> list = SortedList.Create<int>();
            list.Add(4);
            list.Add(2);
            list.Add(5);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            var sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append(item);
            }

            Assert.AreEqual("223455", sb.ToString());
        }

        [TestMethod]
        public void PlusOperatorOpSortedList()
        {
            SortedList<int> list = SortedList.Create<int>();
            list += 4;
            list += 2;

            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(4, list[1]);
        }

        [TestMethod]
        public void SorteerVanPersonen()
        {
            SortedList<Persoon> list = 
                SortedList.Create<Persoon>(p => p.Leeftijd);

            list.Add(new Persoon { Naam = "Pieter", Leeftijd = 25 });
            list.Add(new Persoon { Naam = "Janneke", Leeftijd = 21 });

            Assert.AreEqual("Janneke", list[0].Naam);
            Assert.AreEqual("Pieter", list[1].Naam);
        }

        [TestMethod]
        public void SorteerSelectPropertyInConstructor()
        {
            SortedList<Persoon> list = 
                new SortedList<Persoon>(p => p.Leeftijd);

        }
    }


}