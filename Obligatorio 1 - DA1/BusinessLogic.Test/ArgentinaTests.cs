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
            Mock<Argentina> mockedArg = new Mock<Argentina>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedArg.Object.IsMessageValid("ABC1234 10:30 50"));
        }

        [TestMethod]
        public void ValidateMessageValidMessageContainsExtraSpace()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedArg.Object.IsMessageValid("ABC1234 10:30  50"));
        }

        [TestMethod]
        public void ValidateMessageValidMessageLicensePlateWithSpace()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedArg.Object.IsMessageValid("ABC 1234 10:30 50"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageLicensePlateMissingLetters()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedArg.Object.IsMessageValid("1234 10:30 50"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageLicensePlateMissingNumbers()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedArg.Object.IsMessageValid("ABC 10:30 50"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageLicensePlateXXXContainsNumbersV1()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedArg.Object.IsMessageValid("A1C1234 10:30 50"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateMessageInvalidMessageLicensePlateXXXContainsNumbersV2()
        {
            Mock<Argentina> mockedArg = new Mock<Argentina>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedArg.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            Assert.IsTrue(mockedArg.Object.IsMessageValid("A1C 1234 10:30 50"));
        }

    }
}
