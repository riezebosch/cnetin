using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class OperatorsDemo
    {
        int tellertje = 0;

        [Fact]
        public void ConditionalAndOperator()
        {
            tellertje = 0;

            if (ReturnFalse() &&
                ReturnFalse())
            {
                throw new Exception("Dit zou toch nooit uitgevoerd moeten worden");
            }

            Assert.Equal(1, tellertje);
        }

        [Fact]
        public void ConditionalOrOperator()
        {
            tellertje = 0;

            if (ReturnFalse() ||
                ReturnFalse())
            {
                throw new Exception("Dit zou toch nooit uitgevoerd moeten worden");
            }

            Assert.Equal(2, tellertje);
        }

        [Fact]
        public void ConditionalOrOperatorShortCircuit()
        {
            tellertje = 0;

            if (true ||
                ReturnFalse() ||
                ReturnFalse())
            {
                //throw new Exception("Dit zou toch nooit uitgevoerd moeten worden");
            }

            Assert.Equal(0, tellertje);
        }

        [Fact]
        public void HoeWerktDeXor()
        {
            tellertje = 0;

            if (true ^
                ReturnFalse() ^
                ReturnFalse())
            {
                //throw new Exception("Dit zou toch nooit uitgevoerd moeten worden");
            }

            Assert.Equal(2, tellertje);
        }

        private bool ReturnFalse()
        {
            tellertje++; // <-- tellertje = tellertje + 1;
            return false;
        }

        public void TernaryOperator()
        {
            string mood =
                DateTime.Today.DayOfWeek == DayOfWeek.Tuesday
                ? "happy"
                : "sad";

            Assert.Equal("happy", mood);

            string mood2;
            if (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
            {
                mood2 = "happy";
            }
            else
            {
                mood2 = "sad";
            }

            Assert.Equal(mood, mood2);
        }

        [Fact]
        public void IncrementOperator()
        {
            var a = 0.8m;
            a--;

            Assert.Equal(-0.2m, a);
        }

        [Fact]
        public void IncrementOperator2()
        {
            var a = 0.8m;
            Assert.Equal(0.8m, a--);
            Assert.Equal(-0.2m, a);
        }

        [Fact]
        public void IncrementOperator3()
        {
            var a = 0.8m;
            Assert.Equal(-0.2m, --a);
            Assert.Equal(-0.2m, a);
        }

        [Fact]
        public void IncrementOperator4()
        {
            var a = 0.8m;
            var b = a++;
            Assert.Equal(0.8m, b);
            Assert.Equal(1.8m, a);

            a = 0.8m;
            var c = ++a;
            Assert.Equal(1.8m, c);
            Assert.Equal(1.8m, a);

            a = 0.8m;
            var d = a = a + 1;
            Assert.Equal(1.8m, d);
            Assert.Equal(1.8m, a);
        }

        [Fact]
        public void Loops()
        {
            int[] items = { 1, 2, 3, 4, 5 };

            for (int i = 0; i < items.Length; i++)
            {
                int item = items[i];
            }

            for (int i = items.Length - 1; i >= 0; i--)
            {
            }

            for (int i = items.Length; i >= 0; --i)
            {
            }

            foreach (var item in items)
            {
            }
        }

        public void CastOperators()
        {
            int a = 4;
            double b = a;

            double c = 4;
            int d = (int)c;

            float e = 1.3f;
            int f = (int)e;

            Assert.Equal(1, f);
        }

        [Fact]
        public void AssignmentOperators()
        {
            int a = 4;
            a += 5; // <-- a = a + 5;
            a *= 2;
        }

        [Fact]
        public void BitShiftDemo()
        {
            int a = 4;
            int b = a >> 2;

            Assert.Equal(1, b);
        }

        [Fact]
        public void ExplicitCastWatGebeurtBijOverflow()
        {
            long l = int.MaxValue;
            l++;

            int i = (int)l;
            Assert.Equal(int.MinValue, i);
        }

        [Fact]
        public void ExplicitCastWatGebeurtBijOverflowGooitException()
        {
            long l = int.MaxValue;
            l++;

            checked // <--- zorgt ervoor dat aritmetische operaties gecontroleerd worden of het resultaat wel past in de variabele.
            {
                Assert.Throws<OverflowException>(() => (int)l);
            }
            
        }
    }
}
