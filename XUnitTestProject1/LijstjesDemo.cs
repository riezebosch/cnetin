using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class LijstjesDemo
    {
        [Fact]
        public void NaNummerToevoegenMoetDezeErOokWeerErUitGehaaldKunnenWorden()
        {
            var sut = new Lijstje();
            sut.Bewaar(4);

            Assert.Equal(4, sut.Ophalen(0));
        }

        [Fact]
        public void HetTweedeNummerMoetErOokGoedUitKomen()
        {
            var sut = new Lijstje();
            sut.Bewaar(4);
            sut.Bewaar(7);

            Assert.Equal(7, sut.Ophalen(1));
        }

        [Fact]
        public void HetMoetOokWerkenVoorHeleGroteAantallen()
        {
            var sut = new Lijstje();
            for (int i = 0; i < 1000; i++)
            {
                sut.Bewaar(i);
            }
        }
    }
    public class Lijstje
    {
        int[] opslag = new int[5];
        private int aantal;

        public void Bewaar(int waarde)
        {
            ResizeIfNeeded();
            opslag[aantal++] = waarde;
        }

        private void ResizeIfNeeded()
        {
            if (aantal == opslag.Length)
            {
                var temp = new int[aantal * 2];
                Array.Copy(opslag, temp, aantal);
                //for (int i = 0; i < aantal; i++)
                //{
                //    temp[i] = opslag[i];
                //}

                opslag = temp;
            }
        }

        public int Ophalen(int index)
        {
            return opslag[index];
        }
    }
}
