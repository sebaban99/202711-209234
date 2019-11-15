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
        public void SetUpAccountRepository()
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
                Phone = "1-234567",
                CountryTag = "AR",
                Balance = 0
            };

            accountRepository.Context.Accounts.Add(account);

            Assert.AreEqual(accountRepository.GetAll().Count(), 1);
            Assert.IsTrue(accountRepository.GetAll().Contains(account));
        }

        [TestMethod]
        public void AddAccount()
        {
            Account account = new Account()
            {
                Phone = "1-234567",
                CountryTag = "AR",
                Balance = 0
            };

            accountRepository.Add(account);

            Assert.AreEqual(accountRepository.GetAll().Count(), 1);
            Assert.IsTrue(accountRepository.GetAll().Contains(account));
        }

        [TestMethod]
        [ExpectedException(typeof(DatabaseException))]
        public void AddNullAccount()
        {
            Account account = null;

            accountRepository.Add(account);
        }

        [TestMethod]
        public void GetAccount()
        {
            Account accountAR = new Account()
            {
                Phone = "9-8204265",
                CountryTag = "AR",
                Balance = 0
            };

            Account accountUY = new Account()
            {
                Phone = "098 204 265",
                CountryTag = "UY",
                Balance = 0
            };

            accountRepository.Context.Accounts.Add(accountAR);
            accountRepository.Context.Accounts.Add(accountUY);

            Assert.AreEqual(accountRepository.Get("098 204 265", "UY"), accountUY);
        }

        [TestMethod]
        public void GetInexistentAccount()
        {
            Assert.AreEqual(accountRepository.Get("098 204 265", "UY"), null);
        }

        [TestMethod]
        public void UpdateBalanceAccount()
        {
            Account accountUY = new Account()
            {
                Phone = "098 204 265",
                CountryTag = "UY",
                Balance = 0
            };

            accountRepository.Context.Accounts.Add(accountUY);

            accountUY.Balance = 100;

            accountRepository.Update(accountUY);

            Assert.AreEqual(accountRepository.
                Get(accountUY.Phone, accountUY.CountryTag).Balance, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(DatabaseException))]
        public void UpdateBalanceInexistentAccount()
        {
            Account accountUY = new Account()
            {
                Phone = "098 204 265",
                CountryTag = "UY",
                Balance = 0
            };

            accountUY.Balance = 100;

            accountRepository.Update(accountUY);
        }

    }
}
