using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GenericsDemo.Tests
{
    delegate void StartPumpCallback();

    interface IPomp
    {
        void Pompen();
    }

    class Pomp : IPomp
    {
        public string Naam { get; set; }

        public void Pompen()
        {
            Console.WriteLine("{0} is aan het pompen", this.Naam);
        }
    }

    class Tockheim : IPomp
    {
        public void Pfumpfen()
        {
            Console.WriteLine("Wir sind lecker ans pumpfen");
        }

        public void Pompen()
        {
            Pfumpfen();
        }
    }

    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void CallbackDemo()
        {
            Pomp p1 = new Pomp { Naam = "P1" };
            Pomp p2 = new Pomp { Naam = "P2" };
            Tockheim p3 = new Tockheim();

            StartPumpCallback callback = new StartPumpCallback(p1.Pompen);
            callback += p2.Pompen;
            callback += p3.Pfumpfen;

            callback();
        }

        [TestMethod]
        public void CallbackDemoMetLijstjeVanInterfaces()
        {
            List<IPomp> pompen = new List<IPomp>();
            pompen.Add(new Pomp { Naam = "P1" });
            pompen.Add(new Pomp { Naam = "P2" });
            pompen.Add(new Tockheim());

            foreach (var pomp in pompen)
            {
                pomp.Pompen();
            }
        }

        [TestMethod]
        public void DemoVanHetVerschilTussenDelegatesEnEvents()
        {
            var c = new ContainerVoorDelegatesEnEvents();
            c.PrintAllTheThings += Console.WriteLine;
            c.PrintAllTheThings += SendToPrinter;
            c.PrintAllTheThings("maandagmiddage 6 juli");


            c.OnPrintAllTheThings += Console.WriteLine;
            c.OnPrintAllTheThings += SendToPrinter;
            c.OnPrintAllTheThings += m => Console.WriteLine(m);
            //c.OnPrintAllTheThings(); <-- mag niet aangeroepen worden van buitenaf
            c.Execute();

            c.PrintAllTheThings = null;
            //c.OnPrintAllTheThings = null; <-- dit mag niet op een event
        }

        private void SendToPrinter(string message)
        {
            // Hier zou zomaar demo-code kunnen staan
            // om naar de printer te schrijven;
        }

        class MyEventArgs : EventArgs
        {
            public string Message { get; set; }
        }

        delegate void Print(string message);
        
        class ContainerVoorDelegatesEnEvents
        {
            public Print PrintAllTheThings;

            public event Print OnPrintAllTheThings;

            public void Execute()
            {
                OnPrintAllTheThings("maandag 6 juli");
            }
        }
    }
}
