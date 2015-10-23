using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GenericsDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MijnLijstje<Persoon> items = new MijnLijstje<Persoon>();
            items.AddItem(new Persoon { Naam = "Pieter" });
            items.AddItem(new Persoon { Naam = "Janneke" });
            Assert.AreEqual("Pieter", items[0].Naam);
            Assert.AreEqual("Janneke", items[1].Naam);
            items.AddItem(new Persoon { Naam = "Pieter" });
            items.AddItem(new Persoon { Naam = "Pieter" });
            items.AddItem(new Persoon { Naam = "Pieter" });
            items.AddItem(new Persoon { Naam = "Pieter" });
            items.AddItem(new Persoon { Naam = "Pieter" });
            items.AddItem(new Persoon { Naam = "Pieter" });
            items.AddItem(new Persoon { Naam = "Pieter" });
            items.AddItem(new Persoon { Naam = "Pieter" });
        }

        [TestMethod]
        public void MaarKanErOokIetsAndersInDanAlleenPersonen()
        {
            MijnLijstje<int> lijstje = new MijnLijstje<int>();
            lijstje.AddItem(1);
            lijstje.AddItem(2);
            //lijstje.AddItem(new Persoon { Naam = "Jacoba" });
        }

        [TestMethod]
        public void HoeZietHetLijstjeVanMicrosoftErDanUit()
        {
            List<int> items = new List<int>();
        }

        [TestMethod]
        public void VoorbeeldVanGenericOpMethode()
        {
            var i1 = CreateItem(3);
            var i2 = CreateItem<int>(3);
            //string i3 = CreateItem("Pieter");
            //Persoon p = CreateItem<Persoon>(null);
        }

        private ANDER_TYPE CreateItem<ANDER_TYPE>(ANDER_TYPE input) 
            where ANDER_TYPE : IComparable, new()
        {
            if (input == null)
            {
                return default(ANDER_TYPE);
            }

            if (input is int)
            {
                int x = (int)(object)input;
            }

            return new ANDER_TYPE();
        }
    }
}