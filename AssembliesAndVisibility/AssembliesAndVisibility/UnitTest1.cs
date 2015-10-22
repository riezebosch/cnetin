using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssembliesAndVisibility
{
    
    public class MyClass
    {
        private int Id { get; set; }

        public string Naam { get; set; }

        protected int Leeftijd { get; set; }

        protected internal int DezeHouIkVoorMijnEigenAssemblyAlleen { get; set; }
    }

    class MyClass2 : MyClass
    {
        public void Print()
        {
            //Console.WriteLine(this.Id);
            Console.WriteLine(this.Leeftijd);
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var m = new MyClass();
            // m.Id = 13 <-- deze is niet van buitenaf benaderbaar
            m.Naam = "Pieter";
            // m.Leeftijd<-- deze is alleen vanuit sub-classes benaderbaar

            m.DezeHouIkVoorMijnEigenAssemblyAlleen = 13;
        }
    }
}
