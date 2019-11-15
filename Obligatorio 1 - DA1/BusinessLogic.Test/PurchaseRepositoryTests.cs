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
    }
}
