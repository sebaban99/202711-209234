using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Exceptions;
using Moq;
using BusinessLogic.Domain;
using System.Diagnostics.CodeAnalysis;

namespace BusinessLogic.Test
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class PurchaseTests
    {
        private Purchase purchase;

        [TestInitialize]
        public void SetUpPurchase()
        {
            purchase = new Purchase();
        }

        [TestMethod]
        public void SetPurchaseProperties()
        {
            DateTime startingHour = DateTime.Today;
            DateTime finishingHour = DateTime.Today;
            startingHour = startingHour.AddHours(13);
            finishingHour = finishingHour.AddHours(14);

            purchase.LicensePlate = "ABA 1234";
            purchase.StartingHour = startingHour;
            purchase.FinishingHour = finishingHour;
            purchase.AmountOfMinutes = 60;
            purchase.CountryTag = "AR";
      
            Assert.AreEqual(purchase.LicensePlate, "ABA 1234");
            Assert.AreEqual(purchase.StartingHour, startingHour);
            Assert.AreEqual(purchase.FinishingHour, finishingHour);
            Assert.AreEqual(purchase.AmountOfMinutes, 60);
            Assert.AreEqual(purchase.CountryTag, "AR");
        }
    }
}