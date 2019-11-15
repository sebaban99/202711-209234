using System;
using System.Linq;
using BusinessLogic.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Test
{
    [TestClass]
    public class CostRepositoryTests
    {
        private CostRepository costRepository;

        [TestInitialize]
        public void SetUpCostRepository()
        {
            costRepository = new CostRepository()
            {
                Context = new ParkingContext()
            };
        }

        [TestMethod]
        [ExpectedException(typeof(DatabaseException))]
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
        public void AddAlreadyExistentCostPerMinute()
        {
            CostPerMinute aCost = new CostPerMinute()
            {
                Value = 1,
                CountryTag = "UY"
            };

            costRepository.Context.Costs.Add(aCost);

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

            aCost.Value = 2;

            costRepository.Update(aCost);

            Assert.AreEqual(costRepository.Get(aCost.CountryTag).Value, 2);
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
