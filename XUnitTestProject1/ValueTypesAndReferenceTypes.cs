using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class ValueTypesAndReferenceTypes
    {
        [Fact]
        public void HoeWerktEenValueType()
        {
            int a = 3;
            int b = a;

            a = 5;
            Assert.Equal(3, b);
        }

        [Fact]
        public void WatIsDanEenReferenceType()
        {
            var a = new MyClass();
            a.Leeftijd = 5;

            var b = a;
            a.Leeftijd = 3;

            Assert.Equal(3, b.Leeftijd);
        }

        class MyClass
        {
            public int Leeftijd { get; set; }
        }

        [Fact]
        public void KanIkOokZelfEenValueTypeMaken()
        {
            var a = new MyStruct { Hoogte = 5 };
            var b = a;

            a.Hoogte = 3;
            Assert.Equal(5, b.Hoogte);
        }

        struct MyStruct
        {
            public int Hoogte { get; set; }
        }
    }
}
