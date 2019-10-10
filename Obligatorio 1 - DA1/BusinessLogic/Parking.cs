using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Parking
    {
        private List<Account> accounts;
        private List<Purchase> purchases;
        public int CostPerMinute { get; set; }

        public Parking()
        {
            this.accounts = new List<Account>();
            this.purchases = new List<Purchase>();
            this.CostPerMinute = 1;
        }

        public List<Account> GetAllAccounts()
        {
            return accounts;
        }

        public List<Purchase> GetAllPurchases()
        {
            return purchases;
        }

        public void AddAccount(Account anAccount)
        {
            accounts.Add(anAccount);
        }

        public void AddPurchase(Purchase aPurchase)
        {
            purchases.Add(aPurchase);
        }
    }
}