using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Test
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void CreateAccount()
        {
            Account ac = new Account() { Phone = "098 204 265" };

            Assert.AreEqual(ac.Balance, 0);
            Assert.AreEqual(ac.Phone, "098 204 265");
        }

        [TestMethod]
        public void DecreaseBalance()
        {
            Account ac = new Account() { Phone = "098 204 265", Balance = 120 };

            ac.DecreaseBalance(30);

            Assert.AreEqual(ac.Balance, 90);
        }

        [TestMethod]
        public void DecreaseBalanceAndLeaveItOnZero()
        {
            Account ac = new Account() { Phone = "098 204 265", Balance = 30 };

            ac.DecreaseBalance(30);

            Assert.AreEqual(ac.Balance, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void DecreaseBalanceWithABiggerNumberThanCurrentBalance()
        {
            Account ac = new Account() { Phone = "098 204 265", Balance = 30 };

            ac.DecreaseBalance(120);
        }

        [TestMethod]
        public void IncreaseBalance()
        {
            Account ac = new Account() { Phone = "098 204 265" };
            ac.IncreaseBalance(30);

            Assert.AreEqual(ac.Balance, 30);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IncreaseBalanceWithNegativeNumber()
        {
            Account ac = new Account() { Phone = "098 204 265" };

            ac.IncreaseBalance(-15);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IncreaseBalanceWithZero()
        {
            Account ac = new Account() { Phone = "098 204 265" };

            ac.IncreaseBalance(0);
        }
    }
}