using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Test
{
    [TestClass]
    public class PurchaseTests
    {
        [TestMethod]
        public void CreatePurchaseAllValid_AllSpaces()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);
            
            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "SBS 1234 120 13:00", testAccount);

            Assert.AreEqual(aPurchase.Account, testAccount);
            Assert.AreEqual(aPurchase.LicensePlate, "SBS 1234");
            Assert.AreEqual(aPurchase.StartingHour.Hour, 13);
            Assert.AreEqual(aPurchase.FinishingHour.Hour, 15);
            Assert.AreEqual(aPurchase.Account.Balance, 380);

        }

        [TestMethod]
        public void CreatePurchaseAllValid_NoSpaceLicensePlate()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "SBS1234 120 13:00", testAccount);

            Assert.AreEqual(aPurchase.Account, testAccount);
            Assert.AreEqual(aPurchase.LicensePlate, "SBS 1234");
            Assert.AreEqual(aPurchase.StartingHour.Hour, 13);
            Assert.AreEqual(aPurchase.FinishingHour.Hour, 15);
            Assert.AreEqual(aPurchase.Account.Balance, 380);

        }

        [TestMethod]
        public void CreatePurchaseAllValid_NoStartingTime_NoSpaceLicensePlate()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            
            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "SBS1234 120", testAccount);
            DateTime now = DateTime.Now;
            DateTime finishTime = now.AddMinutes(120);

            Assert.AreEqual(aPurchase.Account, testAccount);
            Assert.AreEqual(aPurchase.LicensePlate, "SBS 1234");
            Assert.AreEqual(aPurchase.StartingHour.Hour, now.Hour);
            Assert.AreEqual(aPurchase.StartingHour.Minute, now.Minute);
            Assert.AreEqual(aPurchase.FinishingHour.Hour, finishTime.Hour);
            Assert.AreEqual(aPurchase.FinishingHour.Minute, finishTime.Minute);
            Assert.AreEqual(aPurchase.Account.Balance, 380);
        }

        [TestMethod]
        public void CreatePurchaseAllValid_NoStartingTime()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);


            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "SBS 1234 120", testAccount);
            DateTime now = DateTime.Now;
            DateTime finishTime = now.AddMinutes(120);

            Assert.AreEqual(aPurchase.Account, testAccount);
            Assert.AreEqual(aPurchase.LicensePlate, "SBS 1234");
            Assert.AreEqual(aPurchase.StartingHour.Hour, now.Hour);
            Assert.AreEqual(aPurchase.StartingHour.Minute, now.Minute);
            Assert.AreEqual(aPurchase.FinishingHour.Hour, finishTime.Hour);
            Assert.AreEqual(aPurchase.FinishingHour.Minute, finishTime.Minute);
            Assert.AreEqual(aPurchase.Account.Balance, 380);
        }
    }
}
