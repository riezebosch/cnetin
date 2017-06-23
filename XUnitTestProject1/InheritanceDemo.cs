using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class InheritanceDemo
    {
        [Fact]
        public void IetsMetInheritanceOpClassesEnInterfaces()
        {
            Keuken keuken = new IndischeKeuken();
            keuken.PrintMenu();

            IPrintbaar printable = keuken;
            printable.Print();
        }
    }

    interface IPrintbaar
    {
        void Print();
    }

    class Demo
    {
        private string _name;

        public void Update(string name)
        {
            _name = name;
        }
    }

    abstract class Keuken : IPrintbaar
    {
        public string Naam { get; set; }

        public List<Gerecht> Voorgerechten { get; set; }

        public void Print()
        {
            Console.WriteLine(Naam);
            foreach (var gerecht in Voorgerechten)
            {
                gerecht.Print();
            }

            PrintMenu();
        }

        public abstract void PrintMenu();

    }

    class IndischeKeuken : Keuken
    {
        public override void PrintMenu()
        {
        }

        protected virtual int Scoville()
        {
            return 3;
        }
    }

    class JavaanseKeuken : IndischeKeuken, IPrintbaar
    {
        public override void PrintMenu()
        {
            base.PrintMenu();
            Console.WriteLine("Maar dan pittiger");
        }

        protected override int Scoville()
        {
            return base.Scoville() * 2;
        }
    }

    public class Gerecht : IPrintbaar
    {
        public void Print()
        {
        }
    }
}
