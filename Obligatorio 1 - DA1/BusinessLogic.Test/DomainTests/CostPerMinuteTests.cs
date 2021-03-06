﻿using System;
using System.Diagnostics.CodeAnalysis;
using BusinessLogic.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Test
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CostPerMinuteTests
    {
        [TestMethod]
        public void CreateCostPerMinute()
        {
            CostPerMinute cost = new CostPerMinute
            {
                Value = 2,
                CountryTag = "UY"
            };
            Assert.AreEqual(cost.Value, 2);
            Assert.AreEqual(cost.CountryTag, "UY");
        }
    }
}
