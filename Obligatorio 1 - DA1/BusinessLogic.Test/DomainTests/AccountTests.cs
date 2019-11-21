using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Exceptions;
using BusinessLogic.Domain;
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
            ac = new Account();
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
    }
}