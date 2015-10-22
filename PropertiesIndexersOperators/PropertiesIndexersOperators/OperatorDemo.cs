using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace PropertiesIndexersOperators
{
    [TestClass]
    public class OperatorDemo
    {
        class MyClass
        {
            public int Leeftijd { get; private set; }

            public static explicit operator MyClass(int v)
            {
                return new MyClass { Leeftijd = v };
            }

            public static MyClass operator +(MyClass m1, int value)
            {
                return new MyClass { Leeftijd = m1.Leeftijd + value };
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            var m = new MyClass();
            m = (MyClass)6;

            Assert.AreEqual(6, m.Leeftijd);

            m += 1;
            Assert.AreEqual(7, m.Leeftijd);

            // Voorbeeld van implicit conversion operator in de praktijk
            XNamespace ns = "asdfasdfsadf";
        }
    }
}
