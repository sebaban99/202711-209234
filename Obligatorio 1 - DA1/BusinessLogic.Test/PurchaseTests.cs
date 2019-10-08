using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Test
{
    [TestClass]
    public class PurchaseTests
    {
        [TestMethod]
        public void CreatePurchaseWithValid_LicensePlate_MinutesToPurchase_StartingHour()
        {
            Account testAccount = new Account("099 123 456")
            {
                Balance = 500
            };
            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "SBS 1234 120 11:00")
            {
                Account = testAccount
            };

            Assert.AreEqual(aPurchase.Account, testAccount);
            Assert.AreEqual(aPurchase.LicensePlate, "SBS 1234");
            Assert.AreEqual(aPurchase.StartingHour.Hour, 11);
            Assert.AreEqual(aPurchase.FinishingHour, 13);

        }
    }
}
