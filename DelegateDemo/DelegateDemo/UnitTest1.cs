using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DelegateDemo
{
    [TestClass]
    public class UnitTest1
    {
        List<Persoon> items = new List<Persoon>
        {
            new Persoon { Naam = "Janneke", Woonplaats = "Veendaal" },
            new Persoon { Naam = "Pieter", Woonplaats = "Amsterdam" },
            new Persoon { Naam = "Heidi", Woonplaats = "Zeist" },
            new Persoon { Naam = "Henk", Woonplaats = "Veendaal" },
            new Persoon { Naam = "Berdien", Woonplaats = "Zeist" },
            new Persoon { Naam = "Alexander", Woonplaats = "Driebergen" },
            new Persoon { Naam = "Bart", Woonplaats = "Zeist" },
            new Persoon { Naam = "Wim", Woonplaats = "Amsterdam" },
            new Persoon { Naam = "Pieter", Woonplaats = "Driebergen" },
            new Persoon { Naam = "Isolde", Woonplaats = "Zeist" },
            new Persoon { Naam = "Henrieke", Woonplaats = "Zeist" },
            new Persoon { Naam = "Emiel", Woonplaats = "Amsterdam" },
            new Persoon { Naam = "Jan", Woonplaats = "Driebergen" },
            new Persoon { Naam = "Dirk", Woonplaats = "Zeist" },
            new Persoon { Naam = "Willem", Woonplaats = "Driebergen" },
            new Persoon { Naam = "Anneke", Woonplaats = "Veendaal" },
            new Persoon { Naam = "Jojanneke", Woonplaats = "Zeist" },
            new Persoon { Naam = "Theo", Woonplaats = "Zeist" },
            new Persoon { Naam = "Maureen", Woonplaats = "Zeist" },
            new Persoon { Naam = "Marlies", Woonplaats = "Nijmegen" },
            new Persoon { Naam = "Tim", Woonplaats = "Veendaal" },
            new Persoon { Naam = "Fred", Woonplaats = "Driebergen" },
        };

        [TestMethod]
        public void DitIsEenVoorbeeldVanEenLambda()
        {
            foreach (var persoon in items.Where(p => p.Woonplaats == "Zeist"))
            {
                Console.WriteLine(persoon.Naam);
            }
        }

        [TestMethod]
        public void MyTestMethod()
        {
            foreach (var persoon in WhereWoonplaastIsZeist1(items))
            {
                Console.WriteLine(persoon.Naam);
            }
        }

        delegate bool SelecteerMethode(Persoon p);

        [TestMethod]
        public void MyTestMethod2()
        {
            foreach (var persoon in Where(items, WhereWoonplaatsIsZeist2))
            {
                Console.WriteLine(persoon.Naam);
            }
        }

        private static IEnumerable<Persoon> WhereWoonplaastIsZeist1(IEnumerable<Persoon> lijstje)
        {
            foreach (var persoon in lijstje)
            {
                if (persoon.Woonplaats == "Zeist")
                {
                    yield return persoon;
                }
            }
        }

        private static IEnumerable<Persoon> Where(IEnumerable<Persoon> lijstje, SelecteerMethode methode)
        {
            foreach (var persoon in lijstje)
            {
                if (methode(persoon))
                {
                    yield return persoon;
                }
            }
        }

        private static bool WhereWoonplaatsIsZeist2(Persoon p)
        {
            return p.Woonplaats == "Zeist";
        }

        [TestMethod]
        public void VerschillendeNotaties()
        {
            var result1 = Where(items, WhereWoonplaatsIsZeist2);
            var result2 = Where(items, delegate(Persoon p) { return p.Woonplaats == "Zeist"; });

            var result3 = Where(items, (Persoon p) => { return p.Woonplaats == "Zeist"; });
            var result4 = Where(items, (Persoon p) => p.Woonplaats == "Zeist");
            var result5 = Where(items, p => p.Woonplaats == "Zeist");
        }
    }
}
