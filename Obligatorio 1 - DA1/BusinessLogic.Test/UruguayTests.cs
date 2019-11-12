using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Exceptions;
using Moq;

namespace BusinessLogic.Test
{
    [TestClass]
    public class UruguayTests
    {
        private Uruguay uy;

        [TestInitialize]
        public void SetUpUruguay()
        {
            uy = new Uruguay();
        }

        [TestMethod]
        public void ValidatePhoneNumberWithSpaceAndZero()
        {
            Assert.IsTrue(uy.IsPhoneNumberValid("098 204 265"));
        }

        [TestMethod]
        public void ValidatePhoneNumberWithZeroAndWithoutSpace()
        {
            Assert.IsTrue(uy.IsPhoneNumberValid("098204265"));
        }

        [TestMethod]
        public void ValidatePhoneNumberWithSpaceAndWithoutZero()
        {
            Assert.IsTrue(uy.IsPhoneNumberValid("98 204 265"));
        }

        [TestMethod]
        public void ValidatePhoneNumberWithoutSpaceAndWithoutZero()
        {
            Assert.IsTrue(uy.IsPhoneNumberValid("98204265"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberStaringWithZeroNotFollowedByNine()
        {
            uy.IsPhoneNumberValid("082 042 656");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberNotStaringWithZeroNorNine()
        {
            uy.IsPhoneNumberValid("82 042 656");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberTooManyNumbers()
        {
            uy.IsPhoneNumberValid("9820426568435131");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberNotEnoughNumbers()
        {
            uy.IsPhoneNumberValid("98204");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberContainsLetters()
        {
            uy.IsPhoneNumberValid("098 740 mal");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneStartWithNineInvalidLength()
        {
            uy.IsPhoneNumberValid("982 004 658");
        }

        [TestMethod]
        public void FormatPhoneNumberLength8()
        {
            Assert.AreEqual(uy.FormatPhoneNumber("98123 456"), "098 123 456");
        }

        [TestMethod]
        public void FormatPhoneNumberLength9()
        {
            Assert.AreEqual(uy.FormatPhoneNumber("098123456"), "098 123 456");
        }

        [TestMethod]
        public void ValidateMessageType1AllValidAllSpaces()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedUruguay.Object.IsMessageValid("SBs 1234 120 13:00"));
        }

        [TestMethod]
        public void ValidateMessageValidType2AllValidNoSpaceLicensePlate()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
           Assert.IsTrue(mockedUruguay.Object.IsMessageValid("SBs1234 120 13:00"));
        }

        [TestMethod]
        public void ValidateMessageValidType3AllValidNoStartingTime()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedUruguay.Object.IsMessageValid("SBS 1234 120"));
        }

        [TestMethod]
        public void ValidateMessageType4AllValidNoStartingTimeNoSpaceLicensePlate()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedUruguay.Object.IsMessageValid("SBS1234 120"));
        }

        [TestMethod]
        public void ValidateMessageType1AllValidInvalidFormatExtraSpace()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedUruguay.Object.IsMessageValid("SBS 1234 120  13:00"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageWrongLicensePlateMissingLetters()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("1234 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType1WrongLicensePlateInvalidFormatXXX()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("SB1 1234 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType1WrongLicensePlateInvalidFormatYYYY()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("SBA 1T34 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageWrongLicensePlateMissingNumbers()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("ABs 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType2WrongLicensePlateXXXContainsLetters()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AB43456 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType2WrongLicensePlateYYYYContainsNumbers()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("rBA34u6 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType1MinutesAreNotMultipleOf30()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AzA 1237 110 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType1InvalidFormatStartingHourHHmmVariant1()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AzA 1237 120 9");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType1InvalidFormatStartingHourHHmmVariant2()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AzA 1237 120 9:0");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType1StartingHourHHmmContainsLetters()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AzA 1237 120 09:AM");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType1MinutesAreZero()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AzA 1237 0 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType1InvalidStartingHourBeforeMinimum()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AzA 1237 120 09:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType3CurrentHourBeforeMinimumHour()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(9);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AzA 1237 120");
        }

        [TestMethod]
        public void ValidateMessageType1AllValidStartingHourBorderCaseMinBorder()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedUruguay.Object.IsMessageValid("SBS 1234 120 10:00"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType1StartingHourBorderCaseMaxBorder()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AzA 1237 120 18:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType1InvalidStartingHourAfterMaximum()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AzA 1237 120 19:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType3InvalidStartingHourAfterMaximum()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AzA1237 120 19:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType1CurrentHourAfterMaximumHour()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(19);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AzA 1237 120 15:00");
        }

        [TestMethod]
        public void ValidateMessageType1StartingTimePlusMinutesExceedsMaximumHour()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedUruguay.Object.IsMessageValid("AzA 1237 120 17:35"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType1InvalidStartingHourFormat()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AzA 1237 120 10:90");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageType1InvalidStartingHourBeforeActualHour()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(15);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AzA 1237 120 13:00");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageyInvalidStartingHourFormat12H()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedUruguay.Object.IsMessageValid("AzA 1237 120 10:00 AM ");
        }

        [TestMethod]
        public void ExtractMinutesFromValidMessageType1()
        {
            Assert.AreEqual(uy.ExtractMinutes("AzA 1237 120 10:00"), 120);
        }

        [TestMethod]
        public void ExtractMinutesFromValidMessageType2()
        {
            Assert.AreEqual(uy.ExtractMinutes("AzA1237 120 10:00"), 120);
        }

        [TestMethod]
        public void ExtractMinutesFromValidMessageType3()
        {
            Assert.AreEqual(uy.ExtractMinutes("AzA 1237 120"), 120);
        }

        [TestMethod]
        public void ExtractMinutesFromValidMessageType4()
        {
            Assert.AreEqual(uy.ExtractMinutes("AzA1237 120"), 120);
        }

        [TestMethod]
        public void ExtractStartingHourFromValidMessageType1()
        {
            DateTime startingHour = DateTime.Today;
            startingHour = startingHour.AddHours(11);
            Assert.AreEqual(uy.ExtractStartingHour("AzA 1237 120 11:00"), startingHour);
        }

        [TestMethod]
        public void ExtractStartingHourFromValidMessageType2()
        {
            DateTime startingHour = DateTime.Today;
            startingHour = startingHour.AddHours(11);
            Assert.AreEqual(uy.ExtractStartingHour("AzA1237 120 11:00"), startingHour);
        }

        [TestMethod]
        public void ExtractStartingHourFromValidMessageType3()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(11);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.AreEqual(mockedUruguay.Object.ExtractStartingHour("AzA 1237 120"), aDate);
        }

        [TestMethod]
        public void ExtractStartingHourFromValidMessageType4()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(11);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.AreEqual(mockedUruguay.Object.ExtractStartingHour("AzA1237 120"), aDate);
        }

        [TestMethod]
        public void ExtractFinishingHourFromValidMessageType1()
        {
            DateTime finishingHour = DateTime.Today;
            finishingHour = finishingHour.AddHours(13);
            Assert.AreEqual(uy.ExtractFinishingHour("AzA 1237 120 11:00"), finishingHour);
        }

        [TestMethod]
        public void ExtractFinishingHourFromValidMessageType2()
        {
            DateTime finishingHour = DateTime.Today;
            finishingHour = finishingHour.AddHours(13);
            Assert.AreEqual(uy.ExtractFinishingHour("AzA1237 120 11:00"), finishingHour);
        }

        [TestMethod]
        public void ExtractFinishingHourFromValidMessageType3()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(11);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            DateTime finishingHour = DateTime.Today;
            finishingHour = finishingHour.AddHours(13);
            Assert.AreEqual(mockedUruguay.Object.ExtractFinishingHour("AzA 1237 120"), finishingHour);
        }

        [TestMethod]
        public void ExtractFinishingHourFromValidMessageType4()
        {
            Mock<Uruguay> mockedUruguay = new Mock<Uruguay>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(17);
            mockedUruguay.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            DateTime finishingHour = DateTime.Today;
            finishingHour = finishingHour.AddHours(18);
            Assert.AreEqual(mockedUruguay.Object.ExtractFinishingHour("AzA1237 120"), finishingHour);
        }

        [TestMethod]
        public void ExtractLicensePlateFromValidMessageType1()
        {
            Assert.AreEqual(uy.ExtractLicensePlate("AcU 1238 90 10:30"), "ACU 1238");
        }

        [TestMethod]
        public void ExtractLicensePlateFromValidMessageType2()
        {
            Assert.AreEqual(uy.ExtractLicensePlate("aCU1238 10:30 180"), "ACU 1238");
        }

        [TestMethod]
        public void ExtractLicensePlateFromValidMessageType3()
        {
            Assert.AreEqual(uy.ExtractLicensePlate("aCU 1238 90"), "ACU 1238");
        }

        [TestMethod]
        public void ExtractLicensePlateFromValidMessageType4()
        {
            Assert.AreEqual(uy.ExtractLicensePlate("aCU1238 90"), "ACU 1238");
        }
    }
}
