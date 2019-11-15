using System;
using System.Linq;
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

            Assert.AreEqual(purchaseRepository.Context.Purchases.Count(), 1);
        }
    }
}
