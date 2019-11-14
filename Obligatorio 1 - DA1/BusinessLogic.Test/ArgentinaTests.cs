using System;
using BusinessLogic.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogic.Test
{
    [TestClass]
    public class ArgentinaTests
    {
        private Argentina arg;

        [TestInitialize]
        public void SetUpArgentina()
        {
            arg = new Argentina();
        }

        [TestMethod]
        public void ValidatePhoneNumberValidNumberLength6()
        {
            Assert.IsTrue(arg.IsPhoneNumberValid("123456"));
        }

        [TestMethod]
        public void ValidatePhoneNumberValidNumberLength7()
        {
            Assert.IsTrue(arg.IsPhoneNumberValid("1234567"));
        }

        [TestMethod]
        public void ValidatePhoneNumberValidNumberLength8()
        {
            Assert.IsTrue(arg.IsPhoneNumberValid("12345678"));
        }

        [TestMethod]
        public void ValidatePhoneNumberValidNumberWithOneHyphen()
        {
            Assert.IsTrue(arg.IsPhoneNumberValid("1-2345678"));
        }

        [TestMethod]
        public void ValidatePhoneNumberValidNumberWithManyHyphens()
        {
            Assert.IsTrue(arg.IsPhoneNumberValid("1-23-45678"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberInvalidNumberWithHyphenAtStart()
        {
            arg.IsPhoneNumberValid("-12345678");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberInvalidNumberWithHyphenAtEnd()
        {
            arg.IsPhoneNumberValid("1234567-");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberInvalidNumberWithBothInvalidHyphens()
        {
            arg.IsPhoneNumberValid("-1234567-");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberInvalidNumberManyHypehnsOneInvalid()
        {
            arg.IsPhoneNumberValid("-1234-5678");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberInvalidNumber2HyphensInARow()
        {
            arg.IsPhoneNumberValid("12-344--567");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberInvalidNumberLengthLessThanMinimum()
        {
            arg.IsPhoneNumberValid("1234-8");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberInvalidNumberLengthGreaterThanMaximum()
        {
            arg.IsPhoneNumberValid("1-234456789");
        }

        [TestMethod]
        public void ValidateMessageValidMessage()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedArg.Object.IsMessageValid("ABC1234 10:30 50"));
        }

        [TestMethod]
        public void ValidateMessageValidMessageStartingHourAtActualHour()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(11);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedArg.Object.IsMessageValid("ABC1234 11:00 50"));
        }

        [TestMethod]
        public void ValidateMessageValidMessageContainsExtraSpace()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedArg.Object.IsMessageValid("ABC1234 10:30  50"));
        }

        [TestMethod]
        public void ValidateMessageValidMessageLicensePlateWithSpace()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedArg.Object.IsMessageValid("ABC 1234 10:30 50"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageLicensePlateMissingLetters()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("1234 10:30 50");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageLicensePlateMissingNumbers()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("ABC 10:30 50");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageLicensePlateXXXContainsNumbersV1()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("A1C1234 10:30 50");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageLicensePlateXXXContainsNumbersV2()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("A1C 1234 10:30 50");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageLicensePlateYYYYContainsLettersV1()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("AxC1R34 10:30 50");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageLicensePlateYYYYContainsLettersV2()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("ACu 123u 10:30 50");
        }


        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageMinutesMissing()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("ACu 1238 10:30");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageStartingHourMissing()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("ACu1238 50");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageAmountOfMinutesIsZero()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("ACu1238 10:56 0");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageAmountOfMinutesWithLetters()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("ACu1238 10:56 veinte");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageAttemptingToBuyBefore10AM()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(9);
            aDate = aDate.AddMinutes(59);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("ACu1238 10:30 20");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageAttemptingToBuyBeforeActualHour()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(11);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("ACu1238 10:30 20");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageAttemptingToBuyAt18()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(11);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("ACu1238 18:00 20");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageAttemptingToBuyAfter18()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(11);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("ACu1238 19:00 20");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageHourIn12HFormat()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>() { CallBase = true };
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(11);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedArg.Object.IsMessageValid("ACu1238 13 PM 20");
        }

        [TestMethod]
        public void ExtractMinutesFromValidMessageLPWithSpace()
        {
            Assert.AreEqual(arg.ExtractMinutes("ACU 1238 13:00 20"), 20);
        }

        [TestMethod]
        public void ExtractMinutesFromValidMessageLPWithoutSpace()
        {
            Assert.AreEqual(arg.ExtractMinutes("ACU1238 13:00 20"), 20);
        }

        [TestMethod]
        public void ExtractStartingHourFromValidMessageLPWithSpace()
        {
            DateTime startingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            Assert.AreEqual(arg.ExtractStartingHour("ACU 1238 13:00 20"), startingHour);
        }

        [TestMethod]
        public void ExtractStartingHourFromValidMessageLPWithoutSpace()
        {
            DateTime startingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            Assert.AreEqual(arg.ExtractStartingHour("ACU1238 13:00 20"), startingHour);
        }

        [TestMethod]
        public void ExtractFinishingHourFromValidMessageLPWithSpace()
        {
            DateTime finishingHour = DateTime.Today;
            finishingHour = finishingHour.AddHours(13);
            finishingHour = finishingHour.AddMinutes(20);
            Assert.AreEqual(arg.ExtractFinishingHour("ACU 1238 13:00 20"), finishingHour);
        }

        [TestMethod]
        public void ExtractFinishingHourFromValidMessageLPWithoutSpace()
        {
            DateTime finishingHour = DateTime.Today;
            finishingHour = finishingHour.AddHours(13);
            finishingHour = finishingHour.AddMinutes(20);
            Assert.AreEqual(arg.ExtractFinishingHour("ACU1238 13:00 20"), finishingHour);
        }

        [TestMethod]
        public void ExtractFinishingHourMaximumHourFromValidMessageLPWithSpace()
        {
            DateTime finishingHour = DateTime.Today;
            finishingHour = finishingHour.AddHours(18);
            Assert.AreEqual(arg.ExtractFinishingHour("ACU 1238 16:40 80"), finishingHour);
        }

        [TestMethod]
        public void ExtractFinishingHourMaximumHourFromValidMessageLPWithoutSpace()
        {
            DateTime finishingHour = DateTime.Today;
            finishingHour = finishingHour.AddHours(18);
            Assert.AreEqual(arg.ExtractFinishingHour("ACU1238 16:40 80"), finishingHour);
        }

        [TestMethod]
        public void ExtractLicensePlateFromValidMessageLPWithSpace()
        {
            Assert.AreEqual(arg.ExtractLicensePlate("AcU 1238 16:40 80"), "ACU 1238");
        }

        [TestMethod]
        public void ExtractLicensePlateFromValidMessageLPWithoutSpace()
        {
            Assert.AreEqual(arg.ExtractLicensePlate("aCU1238 16:40 80"), "ACU 1238");
        }

    }
}
