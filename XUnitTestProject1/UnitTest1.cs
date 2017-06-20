using ConsoleApp1;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int i = 2;
            int j = 3;

            int result = i * j;

            Assert.Equal(6, result);
        }

        [Fact]
        public void OppervlakteVanEenDriehoek()
        {
            var vorm = new Driehoek();
            vorm.Breedte = 6;
            vorm.Hoogte = 5;

            Assert.Equal(15, vorm.BerekenOppervlakte());
        }

        [Fact]
        public void OppervlakteVanEenCirkel()
        {
            var vorm = new Cirkel();
            vorm.Diameter = 20;

            Assert.Equal(314.1592653590, Math.Round(vorm.BerekenOppervlakte(), 10));
        }

        [Fact]
        public void HoeZetJeEenStringOmNaarEenGetal1()
        {
            string input = "1234";
            int getal = Convert.ToInt32(input);

            Assert.Equal(1234, getal);
        }

        [Fact]
        public void HoeZetJeEenStringOmNaarEenGetal2()
        {
            string input = "1234";
            int getal = int.Parse(input);

            Assert.Equal(1234, getal);
        }

        [Fact]
        public void HoeZetJeEenStringOmNaarEenGetal3()
        {
            string input = "1234";
            int getal;

            Assert.True(int.TryParse(input, out getal));
            Assert.Equal(1234, getal);
        }

        [Fact]
        public void AfrondingsVerschijnselenMetEenDouble()
        {
            double a = 0.1;
            double b = 0.2;
            double c = a + b;

            Assert.NotEqual(0.3, c);
        }

        [Fact]
        public void HoeMoetJeDanOmgaanMetBijvoorbeeldGeld()
        {
            decimal a = 0.1m;
            decimal b = 0.2m;
            decimal c = a+b;

            Assert.Equal(0.3m, c);
        }

        
    }

}
