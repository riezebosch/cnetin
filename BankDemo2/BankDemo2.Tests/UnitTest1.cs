using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankDemo2;

namespace BankDemo2.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BankAccount account = new BankAccount();
            account.Number = 1;

            decimal saldo = account.Balance;

            account.Deposit(1000m);

            Assert.AreEqual(1000m, account.Balance);
        }

        [TestMethod]
        public void TestWithdraw()
        {
            BankAccount account = new BankAccount();
            account.Withdraw(500m);

            Assert.AreEqual(-500m, account.Balance);
        }

        [TestMethod]
        public void GivenAnSavingsAccountWithdrawShouldFailWhenAmmountExceedBalance()
        {
            BankAccount account = new SavingAccount();
            account.Withdraw(500m);

            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void GivenASavingAccountWithEnoughBalanceWithrawShouldSucceed()
        {
            BankAccount account = new SavingAccount();
            account.Deposit(10m);
            account.Withdraw(5m);

            Assert.AreEqual(5m, account.Balance);
        }
    }
}
