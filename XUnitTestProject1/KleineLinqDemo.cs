using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class KleineLinqDemo
    {
        [Fact]
        public void SorterenOpProperty()
        {
            BankAccount[] accounts = 
            {
                new BankAccount { RekeningNummer = "qwert", Saldo = 20m },
                new BankAccount { RekeningNummer = "asdf", Saldo = 12 }
            };

            accounts.OrderBy(acc => acc.RekeningNummer).ThenBy(acc => acc.Saldo);
        }

        private class BankAccount
        {
            public string RekeningNummer { get; internal set; }
            public decimal Saldo { get; internal set; }
        }
    }
}
