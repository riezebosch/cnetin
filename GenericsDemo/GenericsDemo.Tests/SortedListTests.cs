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
            SortedList<int> list = new SortedList<int>();
            list.Add(5);
            Assert.AreEqual(5, list[0]);
        }

        [TestMethod]
        public void Add3Before5()
        {
            SortedList<int> list = new SortedList<int>();
            list.Add(5);
            list.Add(3);
            Assert.AreEqual(3, list[0]);
            Assert.AreEqual(5, list[1]);
        }

        [TestMethod]
        public void Add5After3()
        {
            SortedList<int> list = new SortedList<int>();
            list.Add(3);
            list.Add(5);
            Assert.AreEqual(3, list[0]);
            Assert.AreEqual(5, list[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexOnEmptyListShouldThrow()
        {
            SortedList<int> list = new SortedList<int>();
            var item = list[0];
        }
        [TestMethod]
        public void SortedListShouldBeEnumerable()
        {
            SortedList<int> list = new SortedList<int> { 4, 2, 5, 2, 3, 5 };
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
            SortedList<int> list = new SortedList<int>();
            list += 4;
            list += 2;

            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(4, list[1]);
        }

        [TestMethod]
        public void AssignmentOperatorOpSortedList()
        {
            SortedList<int> list = 1;
            Assert.AreEqual(1, list[0]);
        }

        [TestMethod]
        public void AssignmentAndPlusOperator()
        {
            SortedList<int> list = ((SortedList<int>)1) + 2 + 3;
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
        }
    }


}