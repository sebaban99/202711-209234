using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Test
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void CreateAccount()
        {
            Account ac = new Account() { Phone = "098 204 265" };
            
            Assert.Equals(ac.Balance, 0);
            Assert.Equals(ac.Phone, "098 204 265");
        }
    }
}
