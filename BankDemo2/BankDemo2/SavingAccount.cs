using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankDemo2
{
    public class SavingAccount : BankAccount
    {
        public override void Withdraw(decimal ammount)
        {
            if (Balance >= ammount)
            {
                base.Withdraw(ammount);
            }
        }
    }
}
