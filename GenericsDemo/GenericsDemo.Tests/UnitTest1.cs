using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericsDemo;
using System.Collections.Generic;
using System.Linq;

namespace GenericsDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AutoResizeArray<int> items = new AutoResizeArray<int> { 1, 2, 3, 4 };
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void ResizeOfAutoResizeArray()
        {
            AutoResizeArray<int> items = new AutoResizeArray<int> { 1, 2, 3, 4 };
            items.Add(5);
        }

        [TestMethod]
        public void IndexerOnAutoResizeArray()
        {
            AutoResizeArray<int> items = new AutoResizeArray<int> { 34, 12, 42, 16 };
            for (int index = 0; index < items.Length; index++)
            {
                Console.WriteLine(items[index]);
            }
        }

        [TestMethod]
        public void AutoResizeArrayMaarDanMetStrings()
        {
            AutoResizeArray<string> items = new AutoResizeArray<string>();
            items.Add("Manuel");
            items.Add("C#");
            items.Add("Info Support");
            items.Add("3");

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void DictionaryVoorbeeld()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            List<int> items = new List<int>();
        }

        [TestMethod]
        public void SortOnAutoResizeArray()
        {
            AutoResizeArray<int> items = new AutoResizeArray<int> { 3, 4, 1, 5 };
            items.Sort();

            Assert.AreEqual(1, items[0]);
            Assert.AreEqual(3, items[1]);
            Assert.AreEqual(4, items[2]);
            Assert.AreEqual(5, items[3]);
        }

        [TestMethod]
        public void TestAutoResizeArrayWithPerson()
        {
            AutoResizeArray<Persoon> items = new AutoResizeArray<Persoon>();
        }

        [TestMethod]
        public void TestIets()
        {
            AutoResizeArray<string> dummy = new AutoResizeArray<string>();
            Persoon p = dummy.Iets<string, Persoon>("input waarde");
            dummy.Iets(4);
        }

        [TestMethod]
        public void LinkedListInsertAt()
        {
            var ll = new LinkedList<int>();
            var first = ll.First;

        }

        [TestMethod]
        public void SortedListDemo()
        {
            var sl = new SortedList<int>();
            sl.Add(1);

            Assert.AreEqual(1, sl[0]);
        }

        [TestMethod]
        public void SortedListSecondItem()
        {
            var sl = new SortedList<int>();
            sl.Add(1);
            sl.Add(2);

            Assert.AreEqual(2, sl[1]);
        }

        [TestMethod]
        public void SortedListWithForeach()
        {
            var sl = new SortedList<int>();
            sl.Add(1);

            foreach (var item in sl)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void SortedListWithRemove()
        {
            var sl = new SortedList<int>();
            sl.Add(2);
            sl.Add(1);
            sl.Add(3);

            sl.Remove(2);
            Assert.AreEqual(3, sl[1]);
        }

        [TestMethod]
        public void SortedListWithRemoveMultiple()
        {
            var sl = new SortedList<int>();
            sl.Add(2);
            sl.Add(1);
            sl.Add(3);
            sl.Add(2);

            sl.Remove(2);
            Assert.AreEqual(3, sl[1]);
        }

        [TestMethod]
        public void TestSortedListWithPersonen()
        {
            var sl = new SortedList<Persoon>();
            sl.Add(new Persoon { Naam = "Manuel" });
            sl.Add(new Persoon { Naam = "C#" });

            foreach (var p in sl)
            {
                Console.WriteLine(p.Naam);
            }
        }

        [TestMethod]
        public void TestSortedListWithPersonenRemove()
        {
            var sl = new SortedList<Persoon>();
            sl.Add(new Persoon { Naam = "Manuel" });
            sl.Add(new Persoon { Naam = "C#" });

            VergelijkPersoon vergelijk = new VergelijkPersoon(VerwijderAllePersonenMetDeNaamManuel);
            Remove(sl, vergelijk);

            VergelijkPersoon vergelijk2 = new VergelijkPersoon(VerwijderAllCSharpVakken);
            Remove(sl, vergelijk2);

            foreach (var p in sl)
            {
                Console.WriteLine(p.Naam);
            }
        }

        private void Remove(SortedList<Persoon> sl, VergelijkPersoon vergelijk)
        {
            foreach (var item in sl)
            {
                if (vergelijk(item))
                {
                    sl.Remove(item);
                    break;
                }
            }
        }

        delegate bool VergelijkPersoon(Persoon p);

        private bool VerwijderAllePersonenMetDeNaamManuel(Persoon p)
        {
            return p.Naam == "Manuel";
        }

        private bool VerwijderAllCSharpVakken(Persoon p)
        {
            return p.Naam == "C#";
        }

        delegate void MyDelegate(string input);

        [TestMethod]
        public void DemoVanDelegates()
        {
            MyDelegate m = new MyDelegate(Print);
            m("voorbeeld");

            DoeIetsMetEenDelegate(m);
        }

        private void DoeIetsMetEenDelegate(MyDelegate del)
        {
            del("uitvoer van delegate");
        }

        private void Print(string message)
        {
            Console.WriteLine(message);
        }

        [TestMethod]
        public void TestVerwijderVanPersoonMetBehulpVanDelegate()
        {
            var sl = new SortedList<Persoon>();
            sl.Add(new Persoon { Naam = "Manuel" });
            sl.Add(new Persoon { Naam = "C#" });

            this.naam = "Manuel";
            VerwijderDelegate<Persoon> verwijder = new VerwijderDelegate<Persoon>(Verwijder);
            sl.Remove(verwijder);

            foreach (var item in sl)
            {
                Console.WriteLine(item.Naam);
            }

            string naam = "C#";
            sl.Remove(delegate(Persoon p) { return p.Naam == naam; });
            
            sl.Remove(p => p.Naam == "Manuel");
            sl.Remove((Persoon p) => p.Naam == "Manuel");
            sl.Remove((Persoon p) => { return p.Naam == "Manuel"; });
        }

        string naam;

        private bool Verwijder(Persoon p)
        {
            return p.Naam == naam;
        }

        [TestMethod]
        public void DemoVanLinq()
        {
            List<Persoon> items = new List<Persoon> 
            { 
                new Persoon 
                { 
                    Naam = "Manuel" 
                }
            };

            items.Select(p => p.Naam == "Manuel");
        }
    }
}
