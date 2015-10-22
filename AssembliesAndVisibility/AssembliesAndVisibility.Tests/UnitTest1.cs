using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssembliesAndVisibility.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var m = new MyClass();
            m.DezeHouIkVoorMijnEigenAssemblyAlleen = 13;
        }
    }
}
