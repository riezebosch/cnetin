using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InheritanceDemo
{
    [TestClass]
    public class InterfaceDemo
    {
        interface IInterface
        {
            void Prima();
        }

        interface ISecond
        {
            void Prima();
        }

        interface IThird
        {
            int Prima();
        }

        class MyClass : 
            IInterface,
            ISecond,
            IThird
        {
            void IInterface.Prima()
            {
                Console.WriteLine("Prima!!");
            }

            void ISecond.Prima()
            {
                Console.WriteLine("Ook prima!");
            }

            int IThird.Prima()
            {
                Console.WriteLine("Ook prima, maar ander contract.");
                return 15;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            MyClass c = new MyClass();
            IInterface m = c;
            m.Prima();

            ISecond s = c;
            s.Prima();

            IThird t = c;
            t.Prima();

        }

        struct MyStruct : IInterface
        {
            public void Prima()
            {
                Console.WriteLine("Prima, een struct!");
            }
        }

        [TestMethod]
        public void StructMetInterface()
        {
            MyStruct s;
            s.Prima();

            IInterface m = s;

            MyStruct s2 = (MyStruct)m;

        }

        struct PersoonStruct
        {
            public string Naam { get; set; }
            public int Leeftijd { get; set; }
        }

        class PersoonClass
        {
            public string Naam { get; set; }
            public int Leeftijd { get; set; }
        }

        [TestMethod]
        public void WanneerEenStructEnWanneerEenClass()
        {
            PersoonStruct s1 = new PersoonStruct();
            s1.Naam = "Pieter";

            PersoonStruct s2 = s1;
            s2.Naam = "Janneke";

            Console.WriteLine($"s1.Naam: {s1.Naam}, s2.Naam: {s2.Naam}");



            PersoonClass c1 = new PersoonClass();
            c1.Naam = "Pieter";

            PersoonClass c2 = c1;
            c2.Naam = "Janneke";

            Console.WriteLine($"c1.Naam: {c1.Naam}, c2.Naam: {c2.Naam}");
        }
    }
}
