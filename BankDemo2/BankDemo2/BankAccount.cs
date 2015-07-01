using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankDemo2
{
    public class BankAccount
    {
        public int Number { get; set; }

        public decimal Balance { get; set; }

        public void Deposit(decimal ammount)
        {
            Balance += ammount;
        }

        public virtual void Withdraw(decimal ammount)
        {
            Balance -= ammount;
        }
    }
}
