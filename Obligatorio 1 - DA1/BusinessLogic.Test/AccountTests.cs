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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateAccountStartZeroSecondNotNine()
        {
            Account ac = new Account("082 042 656");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateAccountNoStartWithZeroOrNine()
        {
            Account ac = new Account("82 426 568");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateAccountTooManyNumbers()
        {
            Account ac = new Account("9820426568435131");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateAccountNotEnoughNumbers()
        {
            Account ac = new Account("98204");
        }
    }
}
