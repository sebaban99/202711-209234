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
        [ExpectedException(typeof(BusinessException))]
        public void IsAccountAlreadyRegistered_ItsRegistered()
        {

            Account anAccount = new Account() { Phone = "095 620 356" };
            aParking.AddAccount(anAccount);

            aParking.IsAccountAlreadyRegistered("095 620 356");
        }

        [TestMethod]
        public void IsAccountAlreadyRegistered_False()
        {
            Assert.IsFalse(aParking.IsAccountAlreadyRegistered("095 620 356"));
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
        public void RetrieveAccountTest_AccountExistsTrue()
        {
            Account anAccount = new Account() { Phone = "098 204 265" };
            aParking.AddAccount(anAccount);

            Account theAccount = aParking.RetrieveAccount("098 204 265");
            Assert.AreEqual(theAccount, anAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void RetrieveAccountTest_AccountExistsFalse()
        {
            Account theAccount = aParking.RetrieveAccount("098 204 265");
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
            Purchase aPurchase = new Purchase("SBT 4505 120 14:00");

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
        public void ValidateLicensePlate_ValidLicensePlateXXX_YYYY()
        {
            Assert.IsTrue(aParking.IsLicensePlateValid("SBA 1234"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidateLicensePlate_ValidLicensePlateXXXYYYY()
        {
            Assert.IsTrue(aParking.IsLicensePlateValid("SbA1234"));
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
        public void MakePurchaseTest_ExistsAccountTrue_HasEnoughBalanceTrue()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);
            Purchase aPurchase = new Purchase("SBT 4505 30 13:00");
            aParking.MakePurchase("098 740 956", aPurchase);

            Assert.IsTrue(aParking.GetAllPurchases().Contains(aPurchase));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void MakePurchaseTest_ExistsAccountFalse()
        {
            Purchase aPurchase = new Purchase("SBT 4505 30 13:00");
            aParking.MakePurchase("098 740 956", aPurchase);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void MakePurchaseTest_ExistsAccountTrue_HasEnoughBalanceFalse()
        {
            Account anAccount = new Account() { Phone = "098 740 956"};
            aParking.AddAccount(anAccount);
            Purchase aPurchase = new Purchase("SBT 4505 30 13:00");
            aParking.MakePurchase("098 740 956", aPurchase);
        }

        [TestMethod]
        public void IsPurchaseActiveTest_IsActiveTrue()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);
            Purchase aPurchase = new Purchase("SBT 4505 120 13:00");
            aParking.MakePurchase("098 740 956", aPurchase);
            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(13);
            chosenMoment = chosenMoment.AddMinutes(5);

            Assert.IsTrue(aParking.IsPurchaseActive("SBT 4505", chosenMoment));
        }

        [TestMethod]
        public void IsPurchaseActiveTest_IsActiveFalse_ChosenMomentHigherThanFinishingHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);
            Purchase aPurchase = new Purchase("SBT 4505 30 13:00");
            aParking.MakePurchase("098 740 956", aPurchase);
            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(13);
            chosenMoment = chosenMoment.AddMinutes(35);

            Assert.IsFalse(aParking.IsPurchaseActive("SBT 4505", chosenMoment));
        }

        [TestMethod]
        public void IsPurchaseActiveTest_IsActiveFalse_ChosenMomentEarlierThanStartingHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);
            Purchase aPurchase = new Purchase("SBT 4505 30 13:00");
            aParking.MakePurchase("098 740 956", aPurchase);
            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(12);
            chosenMoment = chosenMoment.AddMinutes(35);

            Assert.IsFalse(aParking.IsPurchaseActive("SBT 4505", chosenMoment));
        }

        [TestMethod]
        public void IsPurchaseActiveTest_IsActiveTrue_BorderCaseCheckOnFinishingHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);
            Purchase aPurchase = new Purchase("SBT 4505 30 13:00");
            aParking.MakePurchase("098 740 956", aPurchase);
            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(13);
            chosenMoment = chosenMoment.AddMinutes(30);

            Assert.IsTrue(aParking.IsPurchaseActive("SBT 4505", chosenMoment));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IsPurchaseActiveTest_ChosenDateNotInRange_BorderCase_MaximumHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);
            Purchase aPurchase = new Purchase("SBT 4505 30 13:00");
            aParking.MakePurchase("098 740 956", aPurchase);
            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(18);

            aParking.IsPurchaseActive("SBT 4505", chosenMoment);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IsPurchaseActiveTest_ChosenDateNotInRange_HourHigherThanMaximumHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);
            Purchase aPurchase = new Purchase("SBT 4505 30 13:00");
            aParking.MakePurchase("098 740 956", aPurchase);
            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(19);
            chosenMoment = chosenMoment.AddMinutes(30);

            aParking.IsPurchaseActive("SBT 4505", chosenMoment);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IsPurchaseActiveTest_ChosenDateNotInRange_HourEarlierThanMinimumHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);
            Purchase aPurchase = new Purchase("SBT 4505 30 13:00");
            aParking.MakePurchase("098 740 956", aPurchase);
            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(9);
            chosenMoment = chosenMoment.AddMinutes(30);

            aParking.IsPurchaseActive("SBT 4505", chosenMoment);
        }

        [TestMethod]
        public void IsPurchaseActiveTest_ChosenDateNotInRange_PreviousDayAtSameHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);
            Purchase aPurchase = new Purchase("SBT 4505 30 13:00");
            aParking.MakePurchase("098 740 956", aPurchase);
            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(-11);            

            Assert.IsFalse(aParking.IsPurchaseActive("SBT 4505", chosenMoment));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IsPurchaseActiveTest_ChosenDateNotInRange_FutureDay()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);
            Purchase aPurchase = new Purchase("SBT 4505 30 13:00");
            aParking.MakePurchase("098 740 956", aPurchase);
            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(48);

            aParking.IsPurchaseActive("SBT 4505", chosenMoment);
        }

        [TestMethod]        
        public void IsPurchaseActiveTest_ChosenDateInRange_MinimumHour()
        {
            Account anAccount = new Account() { Phone = "098 740 956", Balance = 500 };
            aParking.AddAccount(anAccount);
            Purchase aPurchase = new Purchase("SBT 4505 30 10:00");
            aParking.MakePurchase("098 740 956", aPurchase);
            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(10);            

            Assert.IsTrue(aParking.IsPurchaseActive("SBT 4505", chosenMoment));
        }

        [TestMethod]
        public void FormatPhoneNumberTest_ValidPhoneLength8()
        {
            Assert.AreEqual(aParking.FormatPhoneNumber("98123 456"),"098 123 456");
        }

        [TestMethod]
        public void FormatPhoneNumberTest_ValidPhoneLength9()
        {
            Assert.AreEqual(aParking.FormatPhoneNumber("098123456"), "098 123 456");
        }



    }
}