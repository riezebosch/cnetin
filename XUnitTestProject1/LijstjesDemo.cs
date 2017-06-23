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
            var sut = new Lijstje<int>();
            sut.Bewaar(4);

            Assert.Equal(4, sut.Ophalen(0));
        }

        [Fact]
        public void HetTweedeNummerMoetErOokGoedUitKomen()
        {
            var sut = new Lijstje<int>();
            sut.Bewaar(4);
            sut.Bewaar(7);

            Assert.Equal(7, sut.Ophalen(1));
        }

        [Fact]
        public void HetMoetOokWerkenVoorHeleGroteAantallen()
        {
            var sut = new Lijstje<int>();
            for (int i = 0; i < 1000; i++)
            {
                sut.Bewaar(i);
            }
        }

        [Fact]

        public void HetIsNietHandigDatLijstjeAlleenVoorEenBepaaldTypeWerkt()
        {
            var sut = new Lijstje<string>();
            sut.Bewaar("tekst");
        }

        public void HetIsLelijkAlsIkNietGoedWeetVoorafWatErInMijnLijstjeZit()
        {
            var sut = new Lijstje<object>();
            sut.Bewaar("wortel");
            sut.Bewaar(1);

            object result = sut.Ophalen(0);
            if (result is int)
            {
            }

            if (result.GetType() == typeof(int))
            {
            }

            if (result is int i)
            {
                // Nieuw in C# 7
            }

            int getal = (int)sut.Ophalen(0);
        }

        [Fact]
        public void IsDatNietStandaardAlBeschikbaarDan()
        {
            var janatuurlijkwel = new List<int>();
            janatuurlijkwel.Add(4);
            janatuurlijkwel.Add(7);

            Assert.Equal(7, janatuurlijkwel[1]);
        }
    }

    public class Lijstje<T>
    {
        T[] opslag = new T[5];
        private int aantal;

        public void Bewaar(T waarde)
        {
            ResizeIfNeeded();
            opslag[aantal++] = waarde;
        }

        private void ResizeIfNeeded()
        {
            if (aantal == opslag.Length)
            {
                var temp = new T[aantal * 2];
                Array.Copy(opslag, temp, aantal);
                //for (int i = 0; i < aantal; i++)
                //{
                //    temp[i] = opslag[i];
                //}

                opslag = temp;
            }
        }

        public T Ophalen(int index)
        {
            return opslag[index];
        }
    }
}
