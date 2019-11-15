using System;
using BusinessLogic.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Test
{
    class AccountRepositoryTest
    {
        private AccountRepository accountRepository;

        [TestInitialize]
        public void SetUpPurchaseRepository()
        {
            accountRepository = new AccountRepository()
            {
                Context = new ParkingContext()
            };
        }

        [TestCleanup]
        public void CleanUp()
        {
            accountRepository.Empty();
        }

        [TestMethod]
        public void GetAllAccountsEmptyDB()
        {
            Assert.AreEqual(accountRepository.GetAll().Count(), 0);
        }

        [TestMethod]
        public void GetAllAccountsNotEmptyDB()
        {
            Account account = new Account()
            {
                Phone = "098 204 265",
                CountryTag = "AR",
                Balance = 0
            };

            accountRepository.Context.Purchases.Add(purchase);

            Assert.AreEqual(accountRepository.GetAll().Count(), 1);
            Assert.IsTrue(accountRepository.GetAll().Contains(purchase));
        }
    }
}
