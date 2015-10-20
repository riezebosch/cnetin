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

            // Ouderwetse tussenvorm: anonymous method die inline gedefinieerd wordt:
            var namen3 = lijstje.Where(delegate (string n) { return n.Contains("u"); });

            // Verschillende schrijfwijzen van een lambda.
            
            // Volledig:
            var namen4 = lijstje.Where((string n) => { return n.Contains("u"); });

            // Als het type van "n" automatisch kan worden afgeleid mag je die weglaten:
            var namen5 = lijstje.Where(n => { return n.Contains("u"); });

            // Als je "body" maar 1 statement bevat mag je de accolade's en het return keyword ook weglaten
            var namen6 = lijstje.Where(n => n.Contains("u"));

            // Je kunt 'm ook opschrijven met comprehension of query syntax:
            var namen7 = from n in lijstje
                         where n.Contains("u")
                         select n;

            // Dit is vooral nuttig als je wat uitgebreidere query hebt:
            var namen8 = lijstje
                .Where(n => n.Contains("u"))
                .OrderBy(n => n.Length)
                .ThenBy(n => n)
                .Select(n => n[0]);

            var namen9 = from n in lijstje
                         where n.Contains("u")
                         orderby n.Length, n
                         select n[0];
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
