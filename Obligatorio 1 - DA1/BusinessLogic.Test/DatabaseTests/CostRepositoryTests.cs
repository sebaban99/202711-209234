using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BusinessLogic.Exceptions;
using BusinessLogic.Domain;
using BusinessLogic.Persistance;
using BusinessLogic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Test
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CostRepositoryTests
    {
        private CostRepository costRepository;

        [TestInitialize]
        public void SetUpCostRepository()
        {
            costRepository = new CostRepository(new ParkingContext());
        }

        [TestCleanup]
        public void CleanUp()
        {
            costRepository.Empty();
        }

        [TestMethod]
        public void AddNewCostPerMinute()
        {
            CostPerMinute aCost = new CostPerMinute()
            {
                Value = 1,
                CountryTag = "UY"
            };

            costRepository.Add(aCost);

            Assert.AreEqual(costRepository.Context.Costs.ToList().Count(), 1);
            Assert.IsTrue(costRepository.Context.Costs.ToList().Contains(aCost));
        }

        [TestMethod]
        [ExpectedException(typeof(DatabaseException))]
        public void AddAlreadyExistentCostPerMinute()
        {
            CostPerMinute aCost = new CostPerMinute()
            {
                Value = 1,
                CountryTag = "UY"
            };

            costRepository.Context.Costs.Add(aCost);
            costRepository.Context.SaveChanges();

            CostPerMinute newCost = new CostPerMinute()
            {
                Value = 2,
                CountryTag = "UY"
            };

            costRepository.Add(newCost);
        }

        [TestMethod]
        public void UpdateCostPerMinuteValue()
        {
            CostPerMinute aCost = new CostPerMinute()
            {
                Value = 1,
                CountryTag = "UY"
            };

            costRepository.Context.Costs.Add(aCost);
            costRepository.Context.SaveChanges();
            aCost.Value = 2;

            costRepository.Update(aCost);

            Assert.AreEqual(costRepository.Get("", aCost.CountryTag).Value, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(DatabaseException))]
        public void UpdateCostPerMinuteValueInexistentCost()
        {
            CostPerMinute aCost = new CostPerMinute()
            {
                Value = 1,
                CountryTag = "UY"
            };

            aCost.Value = 2;

            costRepository.Update(aCost);
        }
    }
}
