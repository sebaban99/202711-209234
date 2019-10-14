using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Test
{
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
        public void AddPurchase()
        {
            Purchase aPurchase = new Purchase("SBT 4505 120 14:00");

            aParking.AddPurchase(aPurchase);

            Assert.AreEqual(aParking.GetAllPurchases().Count, 1);
            Assert.IsTrue(aParking.GetAllPurchases().Contains(aPurchase));
        }

        [TestMethod]
        public void ExistAccount()
        {
            Account anAccount = new Account() { Phone = "098 204 265" };
            aParking.AddAccount(anAccount);

            Assert.IsTrue(aParking.ExistAccount(anAccount));
        }

        [TestMethod]
        public void NonExistAccount()
        {
            Account anAccount = new Account() { Phone = "098 204 265" };

            Assert.IsFalse(aParking.ExistAccount(anAccount));
        }

        [TestMethod]
        public void EnoughBalanceForPurchase()
        {
            Account anAccount = new Account() { Phone = "098 204 265", Balance = 500 };
            Purchase aPurchase = new Purchase("SBT 4505 120 12:00");

            bool hasEnough = aParking.HasEnoughBalance(anAccount, aPurchase);

            Assert.IsTrue(hasEnough);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void NotEnoughBalanceForPurchase()
        {
            Account anAccount = new Account() { Phone = "098 204 265", Balance = 50 };
            Purchase aPurchase = new Purchase("SBT 4505 120 12:00");

            aParking.HasEnoughBalance(anAccount, aPurchase);
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
        public void ValidatePhoneStartWithNineInvalidLength()
        {
            aParking.IsNumberPhoneValid("982 004 658");
        }


        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateLicensePlate_WrongLicensePlate_MissingLetters()
        {
            aParking.IsLicensePlateValid("1234");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateLicensePlate_WrongLicensePlate_InvalidFormatXXX()
        {
            aParking.IsLicensePlateValid("SB1 1234");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateLicensePlate_WrongLicensePlate_InvalidFormatYYYY()
        {
            aParking.IsLicensePlateValid("SBA 1T34");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateLicensePlate_WrongLicensePlate_MissingNumbers()
        {
            aParking.IsLicensePlateValid("ABs");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateLicensePlate_WrongLicensePlate_XXXContainsLetters()
        {
            aParking.IsLicensePlateValid("AB43456");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateLicensePlate_WrongLicensePlate_YYYYContainsNumbers()
        {
            aParking.IsLicensePlateValid("rBA34u6");
        }

        [TestMethod]
        public void IsPurchaseActive()
        {
            Account anAccount = new Account() { Phone = "098 740 956" };
            aParking.AddAccount(anAccount);
            anAccount.IncreaseBalance(500);
            Purchase aPurchase = new Purchase("SBT 4505 240 11:00");
            aParking.MakePurchase(anAccount, aPurchase);
            DateTime theMoment = DateTime.Today;
            theMoment = theMoment.AddHours(12);
            theMoment = theMoment.AddMinutes(43);

            Assert.IsTrue(aParking.IsPurchaseActive("SBT 4505", theMoment));
        }

    }
}
