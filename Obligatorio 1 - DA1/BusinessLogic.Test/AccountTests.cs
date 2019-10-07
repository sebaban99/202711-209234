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

        [TestMethod]
        public void CreateAccountWithSpaceAndWithoutZero()
        {
            Account ac = new Account("98 204 265");

            Assert.AreEqual(ac.Balance, 0);
            Assert.AreEqual(ac.Phone, "98 204 265");
        }

        [TestMethod]
        public void CreateAccountWithZeroAndWithoutSpace()
        {
            Account ac = new Account("098204265");

            Assert.AreEqual(ac.Balance, 0);
            Assert.AreEqual(ac.Phone, "098204265");
        }

        [TestMethod]
        public void CreateAccountWithoutSpaceAndZero()
        {
            Account ac = new Account("98204265");

            Assert.AreEqual(ac.Balance, 0);
            Assert.AreEqual(ac.Phone, "98204265");
        }
    }
}
