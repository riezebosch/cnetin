using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InheritanceDemo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Persoon pieter = new Student();

            Student janneke = (Student)pieter;

            object o = janneke;
        }

        private class Persoon
        {
            public string Naam { get; set; }
        }

        private class Student : Persoon
        {
            public int StudentNummer { get; set; }
        }

        [TestMethod]
        public void HideVanMembersUitBaseClass()
        {
            Base b = new Base();
            Derived d = new Derived();

            b.Naam = "Pieter";
            Console.WriteLine($"b.Naam: {b.Naam}");

            d.Naam = "Janneke";
            d.Leeftijd = 36;
            Console.WriteLine($"d.Naam: {d.Naam}, Leeftijd: {d.Leeftijd}");

            // Voorbeeld van hide.
            Base c = d;
            Console.WriteLine($"c.Naam: {c.Naam}");
        }

        private class Base : Abstract
        {
            public string Naam { get; set; }
            public virtual string Omschrijving { get; set; }

            public override decimal CalculateInterest(decimal value)
            {
                return value * 1.005m;
            }
        }

        private class Derived : Base, IBankAccount
        {
            public new string Naam { get; set; }
            public int Leeftijd { get; set; }

            public override string Omschrijving { get; set; }

            public  override decimal CalculateInterest(decimal value)
            {
                if (value < 50000m)
                {
                    return base.CalculateInterest(value);
                }
                else
                {
                    return value;
                }
            }

            public void Withdraw(decimal value)
            {
                Balance -= value;
            }
        }

        [TestMethod]
        public void DemoVanOverrideVanIetsUitBaseClass()
        {
            Base b = new Base();
            b.Omschrijving = "Dit is een vet goeie base class.";

            Derived d = new Derived();
            d.Omschrijving = "Hello from derived.";

            Base c = d;

            Console.WriteLine($"b.Omschrijving: {b.Omschrijving}");
            Console.WriteLine($"d.Omschrijving: {d.Omschrijving}");
            Console.WriteLine($"c.Omschrijving: {c.Omschrijving}");
        }

        [TestMethod]
        public void DemoVanOverrideVanMethod()
        {
            Base b = new Base();
            Derived d = new Derived();

            Console.WriteLine(b.CalculateInterest(100m));

            Console.WriteLine(d.CalculateInterest(100m));
        }

        [TestMethod]
        public void DemoVanAbstractClass()
        {
            Abstract a = new Base();
            Console.WriteLine(a.CalculateInterest(100m));
        }

        private abstract class Abstract
        {
            public decimal Balance { get; protected set; }

            public abstract decimal CalculateInterest(decimal value);

            public bool Deposit(decimal value)
            {
                Balance += value;
                return true;
            }
        }

        [TestMethod]
        public void DemoVanInterface()
        {
            IBankAccount account = new Derived();
            account.Withdraw(10m);

            Console.WriteLine($"Balance: {((Base)account).Balance}");
        }

        private interface IBankAccount
        {
            void Withdraw(decimal value);
        }
    }
}
