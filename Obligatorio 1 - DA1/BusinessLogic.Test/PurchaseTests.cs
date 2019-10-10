using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Exceptions;

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

        [TestMethod]
        public void CreatePurchaseValidParametersInvalidFormat_ExtraSpace()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "SBS 1234 120  13:00", testAccount);

            Assert.AreEqual(aPurchase.Account, testAccount);
            Assert.AreEqual(aPurchase.LicensePlate, "SBS 1234");
            Assert.AreEqual(aPurchase.StartingHour.Hour, 13);
            Assert.AreEqual(aPurchase.FinishingHour.Hour, 15);
            Assert.AreEqual(aPurchase.Account.Balance, 380);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMessageFormatException))]
        public void CreatePurchaseInvalidParameters_WrongLicensePlate_MissingLetters()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "1234 120 13:00", testAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMessageFormatException))]
        public void CreatePurchaseInvalidParameters_WrongLicensePlate_InvalidFormatXXX()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "SB1 1234 120 13:00", testAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMessageFormatException))]
        public void CreatePurchaseInvalidParameters_WrongLicensePlate_InvalidFormatYYYY()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "SBA 1T34 120 13:00", testAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMessageFormatException))]
        public void CreatePurchaseInvalidParameters_WrongLicensePlate_MissingNumbers()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "ABs 120 13:00", testAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMessageFormatException))]
        public void CreatePurchaseInvalidParameters_WrongLicensePlate_XXXContainsLetters()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "AB43456 120 13:00", testAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMessageFormatException))]
        public void CreatePurchaseInvalidParameters_WrongLicensePlate_YYYYContainsNumbers()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "rBA34u6 120 13:00", testAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMessageFormatException))]
        public void CreatePurchaseInvalidParameters_MinutesAreNotMultipleOf30()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "AzA 1237 110 13:00", testAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMessageFormatException))]
        public void CreatePurchaseInvalidParameters_InvalidFormat_StartingHour_HHmm_Variant1()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "AzA 1237 120 9", testAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMessageFormatException))]
        public void CreatePurchaseInvalidParameters_InvalidFormat_StartingHour_HHmm_Variant2()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "AzA 1237 120 9:0", testAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMessageFormatException))]
        public void CreatePurchaseInvalidParameters_InvalidFormat_StartingHour_HHmm_ContainsLetters()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "AzA 1237 120 09:AM", testAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMessageFormatException))]
        public void CreatePurchaseInvalidParameters_MinutesAreZero()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "AzA 1237 0 13:00", testAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMessageFormatException))]
        public void CreatePurchaseInvalidParameters_InvalidStartingHourBeforeMinimum()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "AzA 1237 120 09:00", testAccount);
        }

        [TestMethod]
        public void CreatePurchaseValidParameters_StartingHourBorderCase()
        {
            Account testAccount = new Account("099 123 456");
            testAccount.IncreaseBalance(500);

            int costPerMinute = 1;
            Purchase aPurchase = new Purchase(costPerMinute, "SBS 1234 120 10:00", testAccount);

            Assert.AreEqual(aPurchase.Account, testAccount);
            Assert.AreEqual(aPurchase.LicensePlate, "SBS 1234");
            Assert.AreEqual(aPurchase.StartingHour.Hour, 10);
            Assert.AreEqual(aPurchase.FinishingHour.Hour, 12);
            Assert.AreEqual(aPurchase.Account.Balance, 380);
        }







    }
}
