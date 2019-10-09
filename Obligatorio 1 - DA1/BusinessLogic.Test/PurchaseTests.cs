using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Test
{
    [TestClass]
    public class PurchaseTests
    {
        [TestMethod]
        public void CreatePurchaseValid_LicensePlate_MinutesToPurchase_StartingHour()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);
            
            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "SBS 1234 120 13:00")
            {
                Account = testAccount
            };

            Assert.AreEqual(aPurchase.Account, testAccount);
            Assert.AreEqual(aPurchase.LicensePlate, "SBS 1234");
            Assert.AreEqual(aPurchase.StartingHour.Hour, 13);
            Assert.AreEqual(aPurchase.FinishingHour.Hour, 15);

        }
    }
}
