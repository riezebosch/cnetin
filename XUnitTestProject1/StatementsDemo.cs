using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class StatementsDemo
    {
        [Fact]
        public void SwitchDemo()
        {
            Assert.False(IsWeekend(DateTime.Today.DayOfWeek));
        }

        [Fact]
        public void SwitchDemoWeekend()
        {
            Assert.True(IsWeekend(DayOfWeek.Saturday));
        }

        [Fact]
        public void SwitchDemoGeenGeldigeDay()
        {
            Assert.Throws<Exception>(() => IsWeekend((DayOfWeek)13));
        }

        private bool IsWeekend(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Friday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                    return false;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return true;
                default:
                    throw new Exception($"Unknown day of week {day}");
            }
        }

        [Fact]
        public void BreakDemo()
        {
            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                count = i;
                if (count > 10)
                {
                    break;
                }
            }

            Assert.Equal(11, count);
        }

        [Fact]
        public void ContinueDemo()
        {
            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                continue;
                count = i;
            }

            Assert.Equal(0, count);
        }
    }
}
