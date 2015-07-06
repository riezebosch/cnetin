using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsDemo.Tests
{
    [TestClass]
    public class UnitTest3
    {
        delegate void TemperatuurAlarm(int temperatuur);

        class Reactor
        {
            public event TemperatuurAlarm HelpIkWordTeHeet;

            public void Split()
            {
                Console.WriteLine("Splitting some atoms");
                Temperatuur += 30;

                if (Temperatuur > 1200)
                {
                    HelpIkWordTeHeet(Temperatuur);
                }
            }

            public int Temperatuur { get; set; }
        }

        class HyraulicPump
        {
            public void Pompen(int temperatuur)
            {
            }
        }

        class PneumaticPump
        {

            public void PompenMaar(int temperatuur)
            {
                
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            var reactor = new Reactor();
            var p1 = new PneumaticPump();
            var p2 = new HyraulicPump();
            var p3 = new HyraulicPump();

            // Deze twee regels betekenen precies hetzelfde:
            reactor.HelpIkWordTeHeet += new TemperatuurAlarm(p1.PompenMaar);
            reactor.HelpIkWordTeHeet += p1.PompenMaar;

            reactor.HelpIkWordTeHeet += p2.Pompen;
            reactor.HelpIkWordTeHeet += p3.Pompen;

            for (int i = 0; i < 50; i++)
            {
                reactor.Split();
            }
        }
    }
}
