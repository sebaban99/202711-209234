using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Exceptions;
using BusinessLogic.Domain;
using BusinessLogic.Interfaces;
using BusinessLogic;
using BusinessLogic.Logic;
using BusinessLogic.Persistance;
using Moq;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace BusinessLogic.Test
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ParkingTests
    {
        private Parking aParking;
        ParkingContext context;
        ParkingRepository<Purchase> purchaseRepository;
        ParkingRepository<Account> accountRepository;
        ParkingRepository<BusinessLogic.Domain.CostPerMinute> costRepository;

        [TestInitialize]
        public void SetUpParking()
        {
            context = new ParkingContext();
            purchaseRepository = new PurchaseRepository(context);
            accountRepository = new AccountRepository(context);
            costRepository = new CostRepository(context);

            aParking = new Parking(purchaseRepository,
                accountRepository, costRepository);
        }

        [TestCleanup]
        public void CleanUp()
        {
            costRepository.Empty();
            purchaseRepository.Empty();
            accountRepository.Empty();
        }

        [TestMethod]
        public void CreateParkingActualCountryUruguay()
        {
            Assert.AreEqual(aParking.GetAllAccounts().Count(), 0);
            Assert.AreEqual(aParking.GetAllPurchases().Count(), 0);
            Assert.AreEqual(aParking.GetActualCost().Value, 1);
            Assert.AreEqual(aParking.ActualCountry.GetCountryTag(), "UY");
        }

        [TestMethod]
        public void ChangeActualCountryEmptyDB()
        {
            Country arg = new Argentina();
            aParking.ActualCountry = arg;
            Assert.AreEqual(aParking.GetAllAccounts().Count(), 0);
            Assert.AreEqual(aParking.GetAllPurchases().Count(), 0);
            Assert.AreEqual(aParking.GetActualCost().Value, 1);
            Assert.AreEqual(aParking.ActualCountry.GetCountryTag(), "AR");
        }

        [TestMethod]
        public void ChangeActualCountryNotEmptyDB()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 0,
                CountryTag = "UY"
            };

            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchase = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            accountRepository.Add(anAccount);
            purchaseRepository.Add(purchase);

            Country arg = new Argentina();
            aParking.ActualCountry = arg;
            Assert.AreEqual(aParking.GetAllAccounts().Count(), 1);
            Assert.AreEqual(aParking.GetAllPurchases().Count(), 1);
            Assert.AreEqual(aParking.GetActualCost().Value, 1);
            Assert.AreEqual(aParking.ActualCountry.GetCountryTag(), "AR");
        }

        [TestMethod]
        public void AddAccount()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 0,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            Assert.AreEqual(aParking.GetAllAccounts().Count(), 1);
            Assert.IsTrue(aParking.GetAllAccounts().Contains(anAccount));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IsAccountAlreadyRegisteredItsRegistered()
        {

            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 0,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            aParking.IsAccountAlreadyRegistered("098 204 265");
        }

        [TestMethod]
        public void IsAccountAlreadyRegisteredFalseAccountsEmpty()
        {
            Assert.IsFalse(aParking.IsAccountAlreadyRegistered("095 620 356"));
        }

        [TestMethod]
        public void IsAccountAlreadyRegisteredFalseAccountsNotEmpty()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 0,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            Assert.IsFalse(aParking.IsAccountAlreadyRegistered("098 740 956"));
        }

        [TestMethod]
        public void RetrieveAccountTestAccountExistsTrue()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 0,
                CountryTag = "UY"
            };

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
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 0,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            Account theAccount = aParking.RetrieveAccount("098 740 956");
        }

        [TestMethod]
        public void MakePurchaseTestExistsAccountTrueHasEnoughBalanceTrue()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 500,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchase = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            aParking.MakePurchase("098 204 265", purchase);

            Assert.IsTrue(aParking.GetAllPurchases().Contains(purchase));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void MakePurchaseTestExistsAccountFalse()
        {
            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchase = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            aParking.MakePurchase("098 740 956", purchase);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void MakePurchaseTestExistsAccountTrueHasEnoughBalanceFalse()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 10,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchase = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            aParking.MakePurchase("098 204 265", purchase);
        }

        [TestMethod]
        public void IsPurchaseActiveTestIsActiveTrue()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 500,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchase = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            aParking.MakePurchase("098 204 265", purchase);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(13);
            chosenMoment = chosenMoment.AddMinutes(5);

            Assert.IsTrue(aParking.IsPurchaseActive("ABA 1234", chosenMoment));
        }

        [TestMethod]
        public void IsPurchaseActiveTestIsActiveFalseChosenMomentHigherThanFinishingHour()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 500,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchase = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            aParking.MakePurchase("098 204 265", purchase);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(14);
            chosenMoment = chosenMoment.AddMinutes(1);

            Assert.IsFalse(aParking.IsPurchaseActive("ABA 1234", chosenMoment));
        }

        [TestMethod]
        public void IsPurchaseActiveTestIsActiveFalseChosenMomentEarlierThanStartingHour()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 500,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchase = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            aParking.MakePurchase("098 204 265", purchase);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(12);
            chosenMoment = chosenMoment.AddMinutes(30);

            Assert.IsFalse(aParking.IsPurchaseActive("ABA 1234", chosenMoment));
        }

        [TestMethod]
        public void IsPurchaseActiveTestIsActiveTrueBorderCaseCheckOnFinishingHour()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 500,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchase = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            aParking.MakePurchase("098 204 265", purchase);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(14);

            Assert.IsTrue(aParking.IsPurchaseActive("ABA 1234", chosenMoment));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IsPurchaseActiveTestChosenDateNotInRangeBorderCaseMaximumHour()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 500,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchase = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            aParking.MakePurchase("098 204 265", purchase);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(18);

            aParking.IsPurchaseActive("ABA 1234", chosenMoment);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IsPurchaseActiveTestChosenDateNotInRangeHourHigherThanMaximumHour()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 500,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchase = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            aParking.MakePurchase("098 204 265", purchase);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(19);
            chosenMoment = chosenMoment.AddMinutes(30);

            aParking.IsPurchaseActive("ABA 1234", chosenMoment);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IsPurchaseActiveTestChosenDateNotInRangeHourEarlierThanMinimumHour()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 500,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchase = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            aParking.MakePurchase("098 204 265", purchase);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(9);
            chosenMoment = chosenMoment.AddMinutes(30);

            aParking.IsPurchaseActive("ABA 1234", chosenMoment);
        }

        [TestMethod]
        public void IsPurchaseActiveTestChosenDateNotInRangePreviousDayAtSameHour()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 500,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchase = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            aParking.MakePurchase("098 204 265", purchase);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(-11);

            Assert.IsFalse(aParking.IsPurchaseActive("ABA 1234", chosenMoment));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IsPurchaseActiveTestChosenDateNotInRangeFutureDay()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 500,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchase = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            aParking.MakePurchase("098 204 265", purchase);

            DateTime chosenMoment = DateTime.Today;
            chosenMoment = chosenMoment.AddHours(48);

            aParking.IsPurchaseActive("ABA 1234", chosenMoment);
        }

        [TestMethod]
        public void IsPurchaseActiveTestChosenDateInRangeMinimumHour()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 500,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(10);
            finishingHour = finishingHour.AddHours(11);

            Purchase purchase = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            aParking.MakePurchase("098 204 265", purchase);

            Assert.IsTrue(aParking.IsPurchaseActive("ABA 1234", DateTime.Today.AddHours(10)));
        }

        [TestMethod]
        public void DecreaseBalance()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 500,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            aParking.DecreaseBalance(anAccount, 100);

            Assert.AreEqual(aParking.RetrieveAccount("098 204 265").Balance, 400);
        }

        [TestMethod]
        public void DecreaseBalanceAndLeaveItOnZero()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 500,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            aParking.DecreaseBalance(anAccount, 500);

            Assert.AreEqual(aParking.RetrieveAccount("098 204 265").Balance, 0);
        }

        [TestMethod]
        public void IncreaseBalance()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 0,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            aParking.IncreaseBalance(anAccount, 100);

            Assert.AreEqual(aParking.RetrieveAccount("098 204 265").Balance, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IncreaseBalanceWithNegativeNumber()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 0,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            aParking.IncreaseBalance(anAccount, -15);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void IncreaseBalanceWithZero()
        {
            Account anAccount = new Account()
            {
                Phone = "098 204 265",
                Balance = 0,
                CountryTag = "UY"
            };

            aParking.AddAccount(anAccount);

            aParking.IncreaseBalance(anAccount, 0);
        }

        [TestMethod]
        public void IsChosenSHEarlierThanFHTrue()
        {
            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            ReportDate rep = new ReportDate
            {
                StartingHour = startingHour,
                FinishingHour = finishingHour
            };

            Assert.IsTrue(aParking.IsChosenSHEarlierThanChosenFH(rep));
        }

        [TestMethod]
        public void IsChosenSHEarlierThanFHFalse()
        {
            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(14);
            finishingHour = finishingHour.AddHours(13);

            ReportDate rep = new ReportDate
            {
                StartingHour = startingHour,
                FinishingHour = finishingHour
            };

            Assert.IsFalse(aParking.IsChosenSHEarlierThanChosenFH(rep));
        }

        [TestMethod]
        public void IsChosenSHSameAsFH()
        {
            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(14);
            finishingHour = finishingHour.AddHours(14);

            ReportDate rep = new ReportDate
            {
                StartingHour = startingHour,
                FinishingHour = finishingHour
            };

            Assert.IsTrue(aParking.IsChosenSHEarlierThanChosenFH(rep));
        }

        [TestMethod]
        public void IsChosenSDEarlierThanFDTrue()
        {
            DateTime startingDate = DateTime.Today;
            DateTime finishingDate = DateTime.Today;
            startingDate = startingDate.AddHours(14);
            finishingDate = finishingDate.AddHours(38);

            ReportDate rep = new ReportDate
            {
                StartingDate = startingDate,
                FinishingDate = finishingDate
            };

            Assert.IsTrue(aParking.IsChosenSDateEarlierThanChosenFDate(rep));
        }

        [TestMethod]
        public void IsChosenSDEarlierThanFDFalse()
        {
            DateTime startingDate = DateTime.Today;
            DateTime finishingDate = DateTime.Today;
            startingDate = startingDate.AddHours(14);
            finishingDate = finishingDate.AddHours(-38);

            ReportDate rep = new ReportDate
            {
                StartingDate = startingDate,
                FinishingDate = finishingDate
            };

            Assert.IsFalse(aParking.IsChosenSDateEarlierThanChosenFDate(rep));
        }

        [TestMethod]
        public void IsChosenSDSameAsFD()
        {
            DateTime startingDate = DateTime.Today;
            DateTime finishingDate = DateTime.Today;
            startingDate = startingDate.AddHours(14);
            finishingDate = finishingDate.AddHours(14);

            ReportDate rep = new ReportDate
            {
                StartingDate = startingDate,
                FinishingDate = finishingDate
            };

            Assert.IsTrue(aParking.IsChosenSDateEarlierThanChosenFDate(rep));
        }

        [TestMethod]
        public void AreChosenHourInParkingHourRangeSHBefore10AM()
        {
            DateTime hour = DateTime.Today;
            hour = hour.AddHours(9);

            Assert.IsFalse(aParking.AreChosenHoursInParkingHourRange(hour));
        }

        [TestMethod]
        public void AreChosenHourInParkingHourRangeSHAT10AM()
        {
            DateTime hour = DateTime.Today;
            hour = hour.AddHours(10);

            Assert.IsTrue(aParking.AreChosenHoursInParkingHourRange(hour));
        }

        [TestMethod]
        public void AreChosenHourInParkingHourRangeSHAfter10AMBefore18PM()
        {
            DateTime hour = DateTime.Today;
            hour = hour.AddHours(13);

            Assert.IsTrue(aParking.AreChosenHoursInParkingHourRange(hour));
        }

        [TestMethod]
        public void AreChosenHourInParkingHourRangeSHAt18PM()
        {
            DateTime hour = DateTime.Today;
            hour = hour.AddHours(18);

            Assert.IsTrue(aParking.AreChosenHoursInParkingHourRange(hour));
        }

        [TestMethod]
        public void AreChosenHourInParkingHourRangeSHAfter18PM()
        {
            DateTime hour = DateTime.Today;
            hour = hour.AddHours(19);

            Assert.IsFalse(aParking.AreChosenHoursInParkingHourRange(hour));
        }

        [TestMethod]
        public void IsPurchaseDateInRangeForReportTrueSameSDate()
        {
            DateTime purchaseDate = DateTime.Today;
            purchaseDate = purchaseDate.AddHours(10);

            DateTime startingDate = DateTime.Today;
            startingDate = startingDate.AddHours(10);
            DateTime finishingDate = DateTime.Today;
            finishingDate = finishingDate.AddHours(34);

            ReportDate rep = new ReportDate
            {
                StartingDate = startingDate,
                FinishingDate = finishingDate
            };

            Assert.IsTrue(aParking.IsPurchaseDateInRangeForReport(rep, purchaseDate));
        }

        [TestMethod]
        public void IsPurchaseDateInRangeForReportTrueDayBeforeRSDate()
        {
            DateTime purchaseDate = DateTime.Today;
            purchaseDate = purchaseDate.AddHours(10);

            DateTime startingDate = DateTime.Today;
            startingDate = startingDate.AddHours(-34);
            DateTime finishingDate = DateTime.Today;
            finishingDate = finishingDate.AddHours(34);

            ReportDate rep = new ReportDate
            {
                StartingDate = startingDate,
                FinishingDate = finishingDate
            };

            Assert.IsTrue(aParking.IsPurchaseDateInRangeForReport(rep, purchaseDate));
        }

        [TestMethod]
        public void IsPurchaseDateInRangeForReportFalseRSDateAfterPSDate()
        {
            DateTime purchaseDate = DateTime.Today;
            purchaseDate = purchaseDate.AddHours(10);

            DateTime startingDate = DateTime.Today;
            startingDate = startingDate.AddHours(34);
            DateTime finishingDate = DateTime.Today;
            finishingDate = finishingDate.AddHours(58);

            ReportDate rep = new ReportDate
            {
                StartingDate = startingDate,
                FinishingDate = finishingDate
            };

            Assert.IsFalse(aParking.IsPurchaseDateInRangeForReport(rep, purchaseDate));
        }

        [TestMethod]
        public void IsPurchaseDateInRangeForReportTrueRFDateSameAsPFDate()
        {
            DateTime purchaseDate = DateTime.Today;
            purchaseDate = purchaseDate.AddHours(34);

            DateTime startingDate = DateTime.Today;
            startingDate = startingDate.AddHours(10);
            DateTime finishingDate = DateTime.Today;
            finishingDate = finishingDate.AddHours(34);

            ReportDate rep = new ReportDate
            {
                StartingDate = startingDate,
                FinishingDate = finishingDate
            };

            Assert.IsTrue(aParking.IsPurchaseDateInRangeForReport(rep, purchaseDate));
        }

        [TestMethod]
        public void IsPurchaseDateInRangeForReportTrueRFDateAfterPFDate()
        {
            DateTime purchaseDate = DateTime.Today;
            purchaseDate = purchaseDate.AddHours(34);

            DateTime startingDate = DateTime.Today;
            startingDate = startingDate.AddHours(10);
            DateTime finishingDate = DateTime.Today;
            finishingDate = finishingDate.AddHours(58);

            ReportDate rep = new ReportDate
            {
                StartingDate = startingDate,
                FinishingDate = finishingDate
            };

            Assert.IsTrue(aParking.IsPurchaseDateInRangeForReport(rep, purchaseDate));
        }

        [TestMethod]
        public void IsPurchaseDateInRangeForReportFalseRFDateBeforePFDate()
        {
            DateTime purchaseDate = DateTime.Today;
            purchaseDate = purchaseDate.AddHours(58);

            DateTime startingDate = DateTime.Today;
            startingDate = startingDate.AddHours(10);
            DateTime finishingDate = DateTime.Today;
            finishingDate = finishingDate.AddHours(34);

            ReportDate rep = new ReportDate
            {
                StartingDate = startingDate,
                FinishingDate = finishingDate
            };

            Assert.IsFalse(aParking.IsPurchaseDateInRangeForReport(rep, purchaseDate));
        }
    }
}
