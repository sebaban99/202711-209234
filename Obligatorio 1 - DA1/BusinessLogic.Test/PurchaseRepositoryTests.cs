using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Test
{
    [TestClass]
    public class PurchaseRepositoryTests
    {
        private PurchaseRepository purchaseRepository;

        [TestInitialize]
        public void SetUpPurchaseRepository()
        {
            purchaseRepository = new PurchaseRepository()
            {
                Context = new ParkingContext()
            };
        }

        [TestCleanup]
        public void CleanUp()
        {
            purchaseRepository.Empty();
        }

        [TestMethod]
        public void GetAllPurchaseEmptyDB()
        {
            Assert.AreEqual(purchaseRepository.GetAll().Count(), 0);
        }

        [TestMethod]
        public void GetAllPurchasesNotEmptyDB()
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
                CountryTag = "AR"
            };

            purchaseRepository.Context.Purchases.Add(purchase);

            Assert.AreEqual(purchaseRepository.GetAll().Count(), 1);
            Assert.IsTrue(purchaseRepository.GetAll().Contains(purchase));
        }

        [TestMethod]
        public void AddPurchase()
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
                CountryTag = "AR"
            };

            purchaseRepository.Add(purchase);

            Assert.IsTrue(purchaseRepository.GetAll().Contains(purchase));
            Assert.AreEqual(purchaseRepository.Context.Purchases.Count(), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(DatabaseException))]
        public void AddPNullurchase()
        {
            Purchase purchase = null;

            purchaseRepository.Add(purchase);
        }

        [TestMethod]
        public void GetPurchase()
        {
            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchaseAR = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "AR"
            };

            Purchase purchaseUY = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "UY"
            };

            purchaseRepository.Add(purchaseAR);
            purchaseRepository.Add(purchaseUY);

            Assert.AreEqual(purchaseRepository.Get("ABA 1234", "UY"), purchaseUY);
        }

        [TestMethod]
        public void GetInexistentPurchase()
        {
            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            Purchase purchaseAR = new Purchase
            {
                LicensePlate = "ABA 1234",
                StartingHour = startingHour,
                FinishingHour = finishingHour,
                AmountOfMinutes = 60,
                CountryTag = "AR"
            };

            purchaseRepository.Add(purchaseAR);

            Assert.AreEqual(purchaseRepository.Get("ABA 1234", "UY"), null);
        }
    }
}
