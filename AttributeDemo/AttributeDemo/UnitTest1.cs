using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace AttributeDemo
{
   
    [MijnEigen(6)]
    class MyClass
    {
        
        public int MyProperty { get; set; }
    }


    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PrintAllAttributes(typeof(MyClass));
            Debug.Write("Hoi, blijkbaar in debug mode gecompileerd");
        }

        [Conditional("DEBUG")]
        private void PrintAllAttributes(Type type)
        {
            foreach (var attribute in type.GetCustomAttributes(true))
            {
                Console.WriteLine(attribute.GetType().Name);
                if (attribute is MijnEigenAttribute)
                {
                    Console.WriteLine($"Value: {((MijnEigenAttribute)attribute).Value}");
                }
            }
        }
    }
}
