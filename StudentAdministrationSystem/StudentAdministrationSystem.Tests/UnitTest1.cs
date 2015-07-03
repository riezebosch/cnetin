using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentAdministrationSystem;

namespace StudentAdministrationSystem.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var b = new BeheerTool();
            Cursus c = b.NieuweCursus("C#");

            Assert.AreEqual("C#", c.Code);
        }

        [TestMethod]
        public void StudentenToevoegen()
        {
            var b = new BeheerTool();
            Cursus c = b.NieuweCursus("C#");
            Student s = b.NieuweStudent(202060, "Manuel Riezebosch", c);

            Assert.AreEqual<string>("Manuel Riezebosch", s.Name);
            Assert.AreEqual<int>(202060, s.Number);
            Assert.AreEqual<Cursus>(c, s.CurrentlyFollowingCourse);
        }

        [TestMethod]
        public void AlleStudentenAfdrukken()
        {
            var b = new BeheerTool();
            Cursus c = b.NieuweCursus("C#");
            Student s = b.NieuweStudent(202060, "Manuel Riezebosch", c);

            Cursus dba = b.NieuweCursus("DBA Master 2015");
            Student s2 = b.NieuweStudent(123456, "Erma van Alebeek", dba);

            string expected = @"Manuel Riezebosch (202060): C#
Erma van Alebeek (123456): DBA Master 2015
";

            string output = b.PrintAll();
            Assert.AreEqual(expected, output);
        }
    }
}
