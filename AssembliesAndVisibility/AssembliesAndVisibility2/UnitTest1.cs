using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssembliesAndVisibility;

namespace AssembliesAndVisibility2
{
    class MyClass3 : MyClass
    {
        public void Print()
        {
            Console.WriteLine(this.DezeHouIkVoorMijnEigenAssemblyAlleen);
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var m = new MyClass();
            
        }
    }
}
