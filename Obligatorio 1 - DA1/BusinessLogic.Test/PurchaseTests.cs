using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Exceptions;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace BusinessLogic.Test
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class PurchaseTests
    {
        [TestMethod]
        public void CreatePurchaseType1AllValidAllSpaces()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBs 1234 120 13:00");

            Assert.AreEqual(mockedPurchase.Object.LicensePlate, "SBS 1234");
            Assert.AreEqual(mockedPurchase.Object.StartingHour.Hour, 13);
            Assert.AreEqual(mockedPurchase.Object.FinishingHour.Hour, 15);
        }

        [TestMethod]
        public void CreatePurchaseType2AllValidNoSpaceLicensePlate()
        {

            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBs1234 120 13:00");

            Assert.AreEqual(mockedPurchase.Object.LicensePlate, "SBS 1234");
            Assert.AreEqual(mockedPurchase.Object.StartingHour.Hour, 13);
            Assert.AreEqual(mockedPurchase.Object.FinishingHour.Hour, 15);
        }

        [TestMethod]
        public void CreatePurchaseType3AllValidNoStartingTime()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBS 1234 120");

            DateTime now = DateTime.Today;
            now = now.AddHours(13);
            DateTime finishTime = now.AddMinutes(120);

            Assert.AreEqual(mockedPurchase.Object.LicensePlate, "SBS 1234");
            Assert.AreEqual(mockedPurchase.Object.StartingHour.Hour, now.Hour);
            Assert.AreEqual(mockedPurchase.Object.StartingHour.Minute, now.Minute);
            Assert.AreEqual(mockedPurchase.Object.FinishingHour.Hour, finishTime.Hour);
            Assert.AreEqual(mockedPurchase.Object.FinishingHour.Minute, finishTime.Minute);
        }

        [TestMethod]
        public void CreatePurchaseType4AllValidNoStartingTimeNoSpaceLicensePlate()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBS1234 120");

            DateTime now = DateTime.Today;
            now = now.AddHours(13);
            DateTime finishTime = now.AddMinutes(120);

            Assert.AreEqual(mockedPurchase.Object.LicensePlate, "SBS 1234");
            Assert.AreEqual(mockedPurchase.Object.StartingHour.Hour, now.Hour);
            Assert.AreEqual(mockedPurchase.Object.StartingHour.Minute, now.Minute);
            Assert.AreEqual(mockedPurchase.Object.FinishingHour.Hour, finishTime.Hour);
            Assert.AreEqual(mockedPurchase.Object.FinishingHour.Minute, finishTime.Minute);
        }

        [TestMethod]
        public void CreatePurchaseType1ValidParametersInvalidFormatExtraSpace()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBS 1234 120  13:00");

            Assert.AreEqual(mockedPurchase.Object.LicensePlate, "SBS 1234");
            Assert.AreEqual(mockedPurchase.Object.StartingHour.Hour, 13);
            Assert.AreEqual(mockedPurchase.Object.FinishingHour.Hour, 15);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseInvalidParameters_WrongLicensePlate_MissingLetters()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("1234 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1InvalidParametersWrongLicensePlateInvalidFormatXXX()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SB1 1234 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1InvalidParametersWrongLicensePlateInvalidFormatYYYY()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBA 1T34 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseInvalidParametersWrongLicensePlateMissingNumbers()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("ABs 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType2InvalidParametersWrongLicensePlateXXXContainsLetters()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AB43456 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType2InvalidParametersWrongLicensePlateYYYYContainsNumbers()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("rBA34u6 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1InvalidParametersMinutesAreNotMultipleOf30()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA 1237 110 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1InvalidParametersInvalidFormatStartingHourHHmmVariant1()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA 1237 120 9");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1InvalidParametersInvalidFormatStartingHourHHmmVariant2()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA 1237 120 9:0");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1InvalidParametersInvalidFormatStartingHourHHmmContainsLetters()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA 1237 120 09:AM");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1InvalidParametersMinutesAreZero()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA 1237 0 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1InvalidParametersInvalidStartingHourBeforeMinimum()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA 1237 120 09:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType3CurrentHourBeforeMinimumHour()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(9);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA 1237 120");
        }

        [TestMethod]
        public void CreatePurchaseType1ValidParametersStartingHourBorderCaseMinBorder()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBS 1234 120 10:00");

            Assert.AreEqual(mockedPurchase.Object.LicensePlate, "SBS 1234");
            Assert.AreEqual(mockedPurchase.Object.StartingHour.Hour, 10);
            Assert.AreEqual(mockedPurchase.Object.FinishingHour.Hour, 12);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1InvalidParametersStartingHourBorderCaseMaxBorder()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA 1237 120 18:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1InvalidParametersInvalidStartingHourAfterMaximum()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA 1237 120 19:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType3InvalidParametersInvalidStartingHourAfterMaximum()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA1237 120 19:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1CurrentHourAfterMaximumHour()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(19);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA 1237 120 15:00");
        }

        [TestMethod]
        public void CreatePurchaseType1ValidParametersStartingTimePlusMinutesExceedsMaximumHour()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA 1237 120 17:35");

            Assert.AreEqual(mockedPurchase.Object.LicensePlate, "AZA 1237");
            Assert.AreEqual(mockedPurchase.Object.StartingHour.Hour, 17);
            Assert.AreEqual(mockedPurchase.Object.StartingHour.Minute, 35);
            Assert.AreEqual(mockedPurchase.Object.FinishingHour.Hour, 18);
            Assert.AreEqual(mockedPurchase.Object.FinishingHour.Minute, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1InvalidParametersInvalidStartingHourFormat()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA 1237 120 10:90");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseType1InvalidStartingHourBeforeActualHour()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(15);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA 1237 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CreatePurchaseInvalidMessageLength()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("AzA 1237 120 10:00 AM ");
        }

        [TestMethod]
        public void GetDateTimeNowTest()
        {
            Purchase aPurchase = new Purchase();

            Assert.AreEqual(DateTime.Now, aPurchase.GetDateTimeNow());

        }
    }
}