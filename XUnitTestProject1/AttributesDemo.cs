using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class AttributesDemo
    {
        [Fact]
        public void WatZijnAttributes()
        {
            var sut = new EigenClass();

            var attr = sut
                .GetType()
                .GetTypeInfo()
                .GetCustomAttribute<MijnEigenAttribute>();
            
            Assert.NotNull(attr);
            Assert.Equal("wortel", attr.Data);
            Assert.Equal(10, attr.Verplicht);
        }

        [Fact]
        public void ConditionalCompilation()
        {
            Print("hallo");
        }

        [Conditional("DEBUG")]
        private void Print(string input)
        {
#if DEBUG
            Console.WriteLine(input);
#endif
            Debug.Write(input);
        }
    }

    internal class MijnEigenAttribute : Attribute
    {
        public MijnEigenAttribute(int verplicht)
        {
            this.Verplicht = verplicht;
        }

        public int Verplicht { get; private set; }
        public string Data { get; set; }
    }

    [MijnEigen(10, Data = "wortel")]
    internal class EigenClass
    {
    }

}
