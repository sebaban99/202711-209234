using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Test
{
    [TestClass]
    public class ParkingTests
    {

        [TestMethod]
        public void CreateParking()
        {
            Parking aParking = new Parking();

            Assert.AreEqual(aParking.GetAllAccounts().Count, 0);
            Assert.AreEqual(aParking.GetAllPurchases().Count, 0);
            Assert.AreEqual(aParking.CostPerMinute, 1);
        }

        [TestMethod]
        public void AddAccount()
        {
            Parking aParking = new Parking();
            Account anAccount = new Account("098 740 956");

            aParking.AddAccount(anAccount);

            Assert.AreEqual(aParking.GetAllAccounts().Count, 1);
            Assert.IsTrue(aParking.GetAllAccounts().Contains(anAccount));
        }

        [TestMethod]
        public void AddPurchase()
        {
            Parking aParking = new Parking();
            Purchase aPurchase = new Purchase("SBT 4505 120 14:00");

            aParking.AddPurchase(aPurchase);

            Assert.AreEqual(aParking.GetAllPurchases().Count, 1);
            Assert.IsTrue(aParking.GetAllPurchases().Contains(aPurchase));
        }

        [TestMethod]
        public void ExistAccount()
        {
            Parking aParking = new Parking();
            Account anAccount = new Account("098 740 956");
            aParking.AddAccount(anAccount);

            Assert.IsTrue(aParking.ExistAccount(anAccount));
        }

        [TestMethod]
        public void NonExistAccount()
        {
            Parking aParking = new Parking();
            Account anAccount = new Account("091 111 111");

            Assert.IsFalse(aParking.ExistAccount(anAccount));
        }

        [TestMethod]
        public void ValidBalanceForPurchase()
        {
            Parking aParking = new Parking();
            Account anAccount = new Account("098 740 956");
            anAccount.Balance = 500;
            Purchase aPurchase = new Purchase("SBT 4505 120 12:00");

            bool hasEnough = aParking.HasEnoughBalance(anAccount, aPurchase);

            Assert.IsTrue(hasEnough);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidBalanceForPurchase()
        {
            Parking aParking = new Parking();
            Account anAccount = new Account("098 740 956");
            anAccount.Balance = 50;
            Purchase aPurchase = new Purchase("SBT 4505 120 12:00");

            bool hasEnough = aParking.HasEnoughBalance(anAccount, aPurchase);
        }
    }
}
