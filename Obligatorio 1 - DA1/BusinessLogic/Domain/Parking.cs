using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Parking
    {
        private List<Account> accounts;
        private List<Purchase> purchases;
        public int CostPerMinute { get; set; }
        public Country ActualCountry { get; set; }

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

        private void AddPurchase(Purchase aPurchase)
        {
            purchases.Add(aPurchase);
        }

        public Account RetrieveAccount(string aPhone)
        {

            foreach (Account ac in accounts)
            {
                if (ac.Phone == aPhone)
                {
                    return ac;
                }
            }
            throw new BusinessException("Móvil no registrado");
        }

        public bool IsAccountAlreadyRegistered(string aPhone)
        {
            foreach (Account ac in accounts)
            {
                if (ac.Phone == aPhone)
                {
                    throw new BusinessException("Móvil: " + aPhone + " ya registrado");
                }
            }
            return false;

        }

        private bool HasEnoughBalance(Account anAccount, Purchase aPurchase)
        {
            if (anAccount.Balance >= aPurchase.AmountOfMinutes * CostPerMinute)
            {
                return true;
            }
            throw new BusinessException("Saldo insuficiente");
        }

        private bool IsDateChosenInRange(DateTime theMoment)
        {
            if (theMoment.Date <= DateTime.Today.Date &&
                theMoment.Hour >= 10 && theMoment.Hour < 18)
            {
                return true;
            }
            else
            {
                throw new BusinessException("Error, elija una hora para el dia de hoy que este entre las 10:00 y las 18:00");
            }
        }

        private bool IsPurchaseInRange(Purchase aPurchase, DateTime theMoment)
        {
            return theMoment >= aPurchase.StartingHour &&
                theMoment <= aPurchase.FinishingHour;
        }

        public bool IsPurchaseActive(string licencePlateToConfirm, DateTime theMoment)
        {
            licencePlateToConfirm = ActualCountry.FormatLicensePlate(licencePlateToConfirm);
            if (IsDateChosenInRange(theMoment))
            {
                foreach (Purchase p in purchases)
                {
                    if (p.LicensePlate.Equals(licencePlateToConfirm) &&
                        IsPurchaseInRange(p, theMoment))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void MakePurchase(String aPhone, Purchase aPurchase)
        {
            Account newAccount = RetrieveAccount(aPhone);

            if (HasEnoughBalance(newAccount, aPurchase))
            {
                this.AddPurchase(aPurchase);
            }
        }
    }
}