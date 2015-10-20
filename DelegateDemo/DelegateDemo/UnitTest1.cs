using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DelegateDemo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // LINQ : Language INtegrated Query
            var lijstje = new List<string> { "Susanne", "Huub", "Wim", "Manuel" };

            var namen = lijstje.Where(n => n.Contains("u"));
            PrintNamen(namen);
        }

        private static void PrintNamen(IEnumerable<string> namen)
        {
            foreach (var naam in namen)
            {
                Console.WriteLine(naam);
            }
        }

        [TestMethod]
        public void WatIsHetVerschilTussenEenLambdaEnEenDelegate()
        {
            var lijstje = new List<string> { "Susanne", "Huub", "Wim", "Manuel" };

            var namen1 = lijstje.Where(n => n.Contains("u"));

            // Misschien is het zo duidelijker wat er gebeurd:
            var namen2 = lijstje.Where(BevatDitItemEenU);
            PrintNamen(namen2);
        }

        private bool BevatDitItemEenU(string arg)
        {
            if (arg.Contains("u"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
