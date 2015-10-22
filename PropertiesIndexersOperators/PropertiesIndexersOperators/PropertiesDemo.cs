using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PropertiesIndexersOperators
{
    [TestClass]
    public class PropertiesDemo
    {
        class MyClass
        {
            public int AutoImplementedProperty { get; set; }




            private int _backingField;

            public int NotSoAutoImplementedProperty
            {
                get { return _backingField; }
                set { _backingField = value; }
            }

            // De java-way of doing stuff
            public void SetNotSoAutoImplementedProperty(int value)
            {
                _backingField = value;
            }

            public int GetNotSoAutoImplementedProperty()
            {
                return _backingField;
            }

            // C# 6 stuff
            public int ReadOnlyProperty { get; } = 6;
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
