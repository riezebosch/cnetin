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
        public void TestMethod1()
        {

        }
    }
}
