using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Exceptions;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace BusinessLogic.Test
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ParkingTests
    {
        private Parking aParking;

        [TestInitialize]
        public void SetUpParking()
        {
            aParking = new Parking();
        }

        [TestMethod]
        public void CreateParking()
        {
            Assert.AreEqual(aParking.GetAllAccounts().Count, 0);
            Assert.AreEqual(aParking.GetAllPurchases().Count, 0);
            Assert.AreEqual(aParking.CostPerMinute, 1);
        }

        [TestMethod]
        public void AddAccount()
        {
            Account anAccount = new Account() { Phone = "098 204 265" };

            aParking.AddAccount(anAccount);

            Assert.AreEqual(aParking.GetAllAccounts().Count, 1);
            Assert.IsTrue(aParking.GetAllAccounts().Contains(anAccount));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IsAccountAlreadyRegisteredItsRegistered()
        {

            Account anAccount = new Account() { Phone = "095 620 356" };
            aParking.AddAccount(anAccount);

            aParking.IsAccountAlreadyRegistered("095 620 356");
        }

        [TestMethod]
        public void IsAccountAlreadyRegisteredFalseAccountsEmpty()
        {
            Assert.IsFalse(aParking.IsAccountAlreadyRegistered("095 620 356"));
        }

        [TestMethod]
        public void IsAccountAlreadyRegisteredFalseAccountsNotEmpty()
        {
            Account anAccount = new Account() { Phone = "095 620 356" };
            aParking.AddAccount(anAccount);

            Assert.IsFalse(aParking.IsAccountAlreadyRegistered("098 740 956"));
        }

        [TestMethod]
        public void RetrieveAccountTestAccountExistsTrue()
        {
            Account anAccount = new Account() { Phone = "098 204 265" };
            aParking.AddAccount(anAccount);

            Account theAccount = aParking.RetrieveAccount("098 204 265");
            Assert.AreEqual(theAccount, anAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void RetrieveAccountTestAccountExistsFalseAccountsEmpty()
        {
            Account theAccount = aParking.RetrieveAccount("098 204 265");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void RetrieveAccountTestAccountExistsFalseAccountsNotEmpty()
        {
            Account anAccount = new Account() { Phone = "098 204 265" };
            aParking.AddAccount(anAccount);

            Account theAccount = aParking.RetrieveAccount("098 740 956");
        }

        [TestMethod]
        public void ValidatePhoneNumberWithSpaceAndZero()
        {
            Assert.IsTrue(aParking.IsNumberPhoneValid("098 204 265"));
        }

        [TestMethod]
        public void ValidatePhoneNumberWithZeroAndWithoutSpace()
        {
            Assert.IsTrue(aParking.IsNumberPhoneValid("098204265"));
        }

        [TestMethod]
        public void ValidatePhoneNumberWithSpaceAndWithoutZero()
        {
            Assert.IsTrue(aParking.IsNumberPhoneValid("98 204 265"));
        }

        [TestMethod]
        public void ValidatePhoneNumberWithoutSpaceAndWithoutZero()
        {
            Assert.IsTrue(aParking.IsNumberPhoneValid("98204265"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberStaringWithZeroNotFollowedByNine()
        {
            aParking.IsNumberPhoneValid("082 042 656");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberNotStaringWithZeroNorNine()
        {
            aParking.IsNumberPhoneValid("82 042 656");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberTooManyNumbers()
        {
            aParking.IsNumberPhoneValid("9820426568435131");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberNotEnoughNumbers()
        {
            aParking.IsNumberPhoneValid("98204");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberContainsLetters()
        {
            aParking.IsNumberPhoneValid("098 740 mal");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneStartWithNineInvalidLength()
        {
            aParking.IsNumberPhoneValid("982 004 658");
        }

        [TestMethod]
        public void ValidateLicensePlateValidLicensePlateXXX_YYYY()
        {
            Assert.IsTrue(aParking.IsLicensePlateValid("SBA 1234"));
        }

        [TestMethod]
        public void ValidateLicensePlateValidLicensePlateXXXYYYY()
        {
            Assert.IsTrue(aParking.IsLicensePlateValid("SbA1234"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateLicensePlateWrongLicensePlateMissingLetters()
        {
            aParking.IsLicensePlateValid("1234");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateLicensePlateWrongLicensePlateInvalidFormatXXX()
        {
            aParking.IsLicensePlateValid("SB1 1234");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateLicensePlateWrongLicensePlateInvalidFormatYYYY()
        {
            aParking.IsLicensePlateValid("SBA 1T34");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateLicensePlateWrongLicensePlateMissingNumbers()
        {
            aParking.IsLicensePlateValid("ABs");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateLicensePlateWrongLicensePlateXXXContainsLetters()
        {
            aParking.IsLicensePlateValid("AB43456");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateLicensePlateWrongLicensePlateYYYYContainsNumbers()
        {
            aParking.IsLicensePlateValid("rBA34u6");
        }

        [TestMethod]
        public void MakePurchaseTestExistsAccountTrueHasEnoughBalanceTrue()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);

            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBT 4505 30 13:00");

            aParking.MakePurchase("098 740 956", mockedPurchase.Object);

            Assert.IsTrue(aParking.GetAllPurchases().Contains(mockedPurchase.Object));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void MakePurchaseTestExistsAccountFalse()
        {
            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBT 4505 30 13:00");

            aParking.MakePurchase("098 740 956", mockedPurchase.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void MakePurchaseTestExistsAccountTrueHasEnoughBalanceFalse()
        {
            Account anAccount = new Account() { Phone = "098 740 956" };
            aParking.AddAccount(anAccount);

            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBT 4505 30 13:00");

            aParking.MakePurchase("098 740 956", mockedPurchase.Object);
        }

        [TestMethod]
        public void IsPurchaseActiveTestIsActiveTrue()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);

            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBT 4505 120 13:00");

            aParking.MakePurchase("098 740 956", mockedPurchase.Object);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(13);
            chosenMoment = chosenMoment.AddMinutes(5);

            Assert.IsTrue(aParking.IsPurchaseActive("SBT 4505", chosenMoment));
        }

        [TestMethod]
        public void IsPurchaseActiveTestIsActiveFalseChosenMomentHigherThanFinishingHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);

            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBT 4505 30 13:00");

            aParking.MakePurchase("098 740 956", mockedPurchase.Object);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(13);
            chosenMoment = chosenMoment.AddMinutes(35);

            Assert.IsFalse(aParking.IsPurchaseActive("SBT 4505", chosenMoment));
        }

        [TestMethod]
        public void IsPurchaseActiveTestIsActiveFalseChosenMomentEarlierThanStartingHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);

            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBT 4505 30 13:00");

            aParking.MakePurchase("098 740 956", mockedPurchase.Object);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(12);
            chosenMoment = chosenMoment.AddMinutes(35);

            Assert.IsFalse(aParking.IsPurchaseActive("SBT 4505", chosenMoment));
        }

        [TestMethod]
        public void IsPurchaseActiveTestIsActiveTrueBorderCaseCheckOnFinishingHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);

            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBT 4505 30 13:00");

            aParking.MakePurchase("098 740 956", mockedPurchase.Object);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(13);
            chosenMoment = chosenMoment.AddMinutes(30);

            Assert.IsTrue(aParking.IsPurchaseActive("SBT 4505", chosenMoment));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IsPurchaseActiveTestChosenDateNotInRangeBorderCaseMaximumHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);

            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBT 4505 30 13:00");

            aParking.MakePurchase("098 740 956", mockedPurchase.Object);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(18);

            aParking.IsPurchaseActive("SBT 4505", chosenMoment);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IsPurchaseActiveTestChosenDateNotInRangeHourHigherThanMaximumHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);

            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBT 4505 30 13:00");

            aParking.MakePurchase("098 740 956", mockedPurchase.Object);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(19);
            chosenMoment = chosenMoment.AddMinutes(30);

            aParking.IsPurchaseActive("SBT 4505", chosenMoment);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IsPurchaseActiveTestChosenDateNotInRangeHourEarlierThanMinimumHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);

            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBT 4505 30 13:00");

            aParking.MakePurchase("098 740 956", mockedPurchase.Object);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(9);
            chosenMoment = chosenMoment.AddMinutes(30);

            aParking.IsPurchaseActive("SBT 4505", chosenMoment);
        }

        [TestMethod]
        public void IsPurchaseActiveTestChosenDateNotInRangePreviousDayAtSameHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);

            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(13);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBT 4505 30 13:00");

            aParking.MakePurchase("098 740 956", mockedPurchase.Object);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(-11);

            Assert.IsFalse(aParking.IsPurchaseActive("SBT 4505", chosenMoment));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IsPurchaseActiveTestChosenDateNotInRangeFutureDay()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);

            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBT 4505 30 13:00");

            aParking.MakePurchase("098 740 956", mockedPurchase.Object);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(48);

            aParking.IsPurchaseActive("SBT 4505", chosenMoment);
        }

        [TestMethod]
        public void IsPurchaseActiveTestChosenDateInRangeMinimumHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);

            Mock<Purchase> mockedPurchase = new Mock<Purchase>();
            DateTime aDate = DateTime.Today;
            aDate = aDate.AddHours(10);
            mockedPurchase.Setup(m => m.GetDateTimeNow()).Returns(aDate);
            mockedPurchase.Object.SetPurchaseProperties("SBT 4505 30 10:00");

            aParking.MakePurchase("098 740 956", mockedPurchase.Object);

            Assert.IsTrue(aParking.IsPurchaseActive("SBT 4505", DateTime.Today.AddHours(10)));
        }

        [TestMethod]
        public void FormatPhoneNumberTestValidPhoneLength8()
        {
            Assert.AreEqual(aParking.FormatPhoneNumber("98123 456"), "098 123 456");
        }

        [TestMethod]
        public void FormatPhoneNumberTestValidPhoneLength9()
        {
            Assert.AreEqual(aParking.FormatPhoneNumber("098123456"), "098 123 456");
        }
    }
}