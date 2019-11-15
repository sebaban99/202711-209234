using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace BusinessLogic.Test
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AccountTests
    {
        private Account ac;

        [TestInitialize]
        public void SetUpAccount()
        {
            ac = new Account
            {
                Balance = 0
            };
        }

        [TestMethod]
        public void SetAccountProperties()
        {
            ac.Phone = "098 204 265";
            ac.CountryTag = "AR";
            ac.Balance = 0;
            Assert.AreEqual(ac.Balance, 0);
            Assert.AreEqual(ac.CountryTag, "AR");
            Assert.AreEqual(ac.Phone, "098 204 265");
        }

        [TestMethod]
        public void DecreaseBalance()
        {
            ac.Balance = 120;

            ac.DecreaseBalance(30);

            Assert.AreEqual(ac.Balance, 90);
        }

        [TestMethod]
        public void DecreaseBalanceAndLeaveItOnZero()
        {
            ac.Balance = 30;

            ac.DecreaseBalance(30);

            Assert.AreEqual(ac.Balance, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void DecreaseBalanceWithABiggerNumberThanCurrentBalance()
        {
            ac.Balance = 30;

            ac.DecreaseBalance(120);
        }

        [TestMethod]
        public void IncreaseBalance()
        {
            ac.IncreaseBalance(30);

            Assert.AreEqual(ac.Balance, 30);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IncreaseBalanceWithNegativeNumber()
        {
            ac.IncreaseBalance(-15);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IncreaseBalanceWithZero()
        {
            ac.IncreaseBalance(0);
        }
    }
}