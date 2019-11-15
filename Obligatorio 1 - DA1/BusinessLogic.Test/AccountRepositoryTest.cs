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
    }
}
