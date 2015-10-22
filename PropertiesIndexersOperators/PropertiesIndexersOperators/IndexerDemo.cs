using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PropertiesIndexersOperators
{
    [TestClass]
    public class IndexerDemo
    {
        class MyClass
        {
            public string this[int index]
            {
                get { return "hallo"; }
                set { Console.WriteLine($"index: {index} value: {value}"); }
            }

            public int this[string index]
            {
                get { return 0; }
                set { Console.WriteLine($"index: {index} value: {value}"); }
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            var m = new MyClass();
            m[3] = "Pieter";
            m["Pieter"] = 26;

            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict["Pieter"] = 26;

            Console.WriteLine(dict["Pieter"]);
        }
    }
}
