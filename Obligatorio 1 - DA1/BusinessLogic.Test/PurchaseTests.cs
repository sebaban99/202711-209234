using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Test
{
    [TestClass]
    public class PurchaseTests
    {
        [TestMethod]
        public void CreatePurchaseType1_AllValid_AllSpaces()
        {
            Purchase aPurchase = new Purchase("SBs 1234 120 13:00");

            Assert.AreEqual(aPurchase.LicensePlate, "SBS 1234");
            Assert.AreEqual(aPurchase.StartingHour.Hour, 13);
            Assert.AreEqual(aPurchase.FinishingHour.Hour, 15);
        }

        [TestMethod]
        public void CreatePurchaseType2_AllValid_NoSpaceLicensePlate()
        {
            Purchase aPurchase = new Purchase("SBs1234 120 13:00");

            Assert.AreEqual(aPurchase.LicensePlate, "SBS 1234");
            Assert.AreEqual(aPurchase.StartingHour.Hour, 13);
            Assert.AreEqual(aPurchase.FinishingHour.Hour, 15);
        }

        [TestMethod]
        public void CreatePurchaseType3_AllValid_NoStartingTime()
        {
            Purchase aPurchase = new Purchase("SBS 1234 120");
            DateTime now = DateTime.Now;
            DateTime finishTime = now.AddMinutes(120);

            Assert.AreEqual(aPurchase.LicensePlate, "SBS 1234");
            Assert.AreEqual(aPurchase.StartingHour.Hour, now.Hour);
            Assert.AreEqual(aPurchase.StartingHour.Minute, now.Minute);
            Assert.AreEqual(aPurchase.FinishingHour.Hour, finishTime.Hour);
            Assert.AreEqual(aPurchase.FinishingHour.Minute, finishTime.Minute);
        }

        [TestMethod]
        public void CreatePurchaseType4_AllValid_NoStartingTime_NoSpaceLicensePlate()
        {
            Purchase aPurchase = new Purchase("SBS1234 120");
            DateTime now = DateTime.Now;
            DateTime finishTime = now.AddMinutes(120);

            Assert.AreEqual(aPurchase.LicensePlate, "SBS 1234");
            Assert.AreEqual(aPurchase.StartingHour.Hour, now.Hour);
            Assert.AreEqual(aPurchase.StartingHour.Minute, now.Minute);
            Assert.AreEqual(aPurchase.FinishingHour.Hour, finishTime.Hour);
            Assert.AreEqual(aPurchase.FinishingHour.Minute, finishTime.Minute);
        }

        [TestMethod]
        public void CreatePurchaseType1_ValidParametersInvalidFormat_ExtraSpace()
        {
            Purchase aPurchase = new Purchase("SBS 1234 120  13:00");


            Assert.AreEqual(aPurchase.LicensePlate, "SBS 1234");
            Assert.AreEqual(aPurchase.StartingHour.Hour, 13);
            Assert.AreEqual(aPurchase.FinishingHour.Hour, 15);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseInvalidParameters_WrongLicensePlate_MissingLetters()
        {
            Purchase aPurchase = new Purchase("1234 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1_InvalidParameters_WrongLicensePlate_InvalidFormatXXX()
        {
            Purchase aPurchase = new Purchase("SB1 1234 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1_InvalidParameters_WrongLicensePlate_InvalidFormatYYYY()
        {
            Purchase aPurchase = new Purchase("SBA 1T34 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseInvalidParameters_WrongLicensePlate_MissingNumbers()
        {
            Purchase aPurchase = new Purchase("ABs 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType2_InvalidParameters_WrongLicensePlate_XXXContainsLetters()
        {
            Purchase aPurchase = new Purchase("AB43456 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType2_InvalidParameters_WrongLicensePlate_YYYYContainsNumbers()
        {
            Purchase aPurchase = new Purchase("rBA34u6 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1_InvalidParameters_MinutesAreNotMultipleOf30()
        {
            Purchase aPurchase = new Purchase("AzA 1237 110 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1_InvalidParameters_InvalidFormat_StartingHour_HHmm_Variant1()
        {
            Purchase aPurchase = new Purchase("AzA 1237 120 9");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1_InvalidParameters_InvalidFormat_StartingHour_HHmm_Variant2()
        {
            Purchase aPurchase = new Purchase("AzA 1237 120 9:0");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1_InvalidParameters_InvalidFormat_StartingHour_HHmm_ContainsLetters()
        {
            Purchase aPurchase = new Purchase("AzA 1237 120 09:AM");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1_InvalidParameters_MinutesAreZero()
        {
            Purchase aPurchase = new Purchase("AzA 1237 0 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1_InvalidParameters_InvalidStartingHour_BeforeMinimum()
        {
            Purchase aPurchase = new Purchase("AzA 1237 120 09:00");
        }

        [TestMethod]
        public void CreatePurchaseType1_ValidParameters_StartingHourBorderCase_MinBorder()
        {
            Purchase aPurchase = new Purchase("SBS 1234 120 10:00");

            Assert.AreEqual(aPurchase.LicensePlate, "SBS 1234");
            Assert.AreEqual(aPurchase.StartingHour.Hour, 10);
            Assert.AreEqual(aPurchase.FinishingHour.Hour, 12);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1_InvalidParameters_StartingHourBorderCase_MaxBorder()
        {
            Purchase aPurchase = new Purchase("AzA 1237 120 18:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1_InvalidParameters_InvalidStartingHour_AfterMaximum()
        {
            Purchase aPurchase = new Purchase("AzA 1237 120 19:00");
        }

        [TestMethod]
        public void CreatePurchaseType1_ValidParameters_StartingTimePlusMinutesExceedsMaximumHour()
        {
            Purchase aPurchase = new Purchase("AzA 1237 120 17:35");

            Assert.AreEqual(aPurchase.LicensePlate, "AZA 1237");
            Assert.AreEqual(aPurchase.StartingHour.Hour, 17);
            Assert.AreEqual(aPurchase.StartingHour.Minute, 35);
            Assert.AreEqual(aPurchase.FinishingHour.Hour, 18);
            Assert.AreEqual(aPurchase.FinishingHour.Minute, 0);

        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1_InvalidParameters_InvalidStartingHourFormat()
        {
            Purchase aPurchase = new Purchase("AzA 1237 120 10:90");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1_InvalidStartingHour_BeforeActualHour()
        {
            Purchase aPurchase = new Purchase("AzA 1237 120 13:00");
        }
    }
}