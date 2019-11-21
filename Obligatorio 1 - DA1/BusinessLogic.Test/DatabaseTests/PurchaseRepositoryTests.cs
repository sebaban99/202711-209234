using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BusinessLogic.Exceptions;
using BusinessLogic.Domain;
using BusinessLogic.Persistance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Test
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class PurchaseRepositoryTests
    {
        private PurchaseRepository purchaseRepository;

        [TestInitialize]
        public void SetUpPurchaseRepository()
        {
            purchaseRepository = new PurchaseRepository(new ParkingContext());
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
            purchaseRepository.Context.SaveChanges();

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

            purchaseRepository.Context.Purchases.Add(purchaseAR);
            purchaseRepository.Context.SaveChanges();
            purchaseRepository.Context.Purchases.Add(purchaseUY);
            purchaseRepository.Context.SaveChanges();

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

            purchaseRepository.Context.Purchases.Add(purchaseAR);
            purchaseRepository.Context.SaveChanges();

            Assert.AreEqual(purchaseRepository.Get("ABA 1234", "UY"), null);
        }
    }
}
