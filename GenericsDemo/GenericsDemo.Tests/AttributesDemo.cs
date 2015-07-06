using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.Xml;
using System.Diagnostics;

namespace GenericsDemo.Tests
{
    
    class CustomAttribute : Attribute
    {
        public int Waarde { get; set; }
    }

    class PersoonAttribute
    {
        [Custom(Waarde = 15)]
        public string Naam { get; set; }
    }

    [TestClass]
    public class AttributesDemo
    {
        [TestMethod]
        [ReadOnly(true)]
        public void TestMethod1()
        {
            var type = this.GetType();
            foreach (var method in type.GetMethods())
            {
                Console.WriteLine(method.Name);
                foreach (var attr in method.GetCustomAttributes(true))
                {
                    Console.WriteLine("  [{0}]", attr.GetType().Name);
                    TestXmlAttributes();
                    Debug.WriteLine("asdf");
                }
            }
        }

        [Conditional("asdfasdfasdf")]
        [TestMethod]
        public void TestXmlAttributes()
        {
#if PGGM
            XmlWriter writer = XmlWriter.Create("output.xml");
#endif
        }
    }
}
