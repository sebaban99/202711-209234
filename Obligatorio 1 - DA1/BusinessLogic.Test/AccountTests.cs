using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Test
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void CreateAccountWithSpaceAndZero()
        {
            Account ac = new Account("098 204 265");

            Assert.AreEqual(ac.Balance, 0);
            Assert.AreEqual(ac.Phone, "098 204 265");
        }
    }
}
