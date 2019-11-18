using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Parking
    {
        public Country ActualCountry { get; set; }
        private ParkingRepository<Purchase> purchaseRepository;
        private ParkingRepository<Account> accountRepository;
        private ParkingRepository<CostPerMinute> costRepository;
        private const int INICIAL_DEFAULT_COSTPERMINUTE = 1;

        public Parking(ParkingRepository<Purchase> purchaseRepository,
            ParkingRepository<Account> accountRepository,
            ParkingRepository<CostPerMinute> costRepository)
        {
            this.purchaseRepository = purchaseRepository;
            this.accountRepository = accountRepository;
            this.costRepository = costRepository;
            ActualCountry = new Uruguay();
            LoadInicialCost();
        }

        public void UpdateCost(int newValue)
        {
            CostPerMinute newCost = GetActualCost();
            newCost.Value = newValue;
            costRepository.Update(newCost);
        }

        private void LoadInicialCost()
        {
            CostPerMinute inicialCostUy = new CostPerMinute()
            {
                Value = INICIAL_DEFAULT_COSTPERMINUTE,
                CountryTag = "UY"
            };

            CostPerMinute inicialCostAr = new CostPerMinute()
            {
                Value = INICIAL_DEFAULT_COSTPERMINUTE,
                CountryTag = "AR"
            };
            CostPerMinute a = GetActualCost();
            if (a == null)
            {
                costRepository.Add(inicialCostUy);
                costRepository.Add(inicialCostAr);
            }
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return accountRepository.GetAll();
        }

        public IEnumerable<Purchase> GetAllPurchases()
        {
            return purchaseRepository.GetAll();
        }

        public void AddAccount(Account anAccount)
        {
            accountRepository.Add(anAccount);
        }

        private void AddPurchase(Purchase aPurchase)
        {
            purchaseRepository.Add(aPurchase);
        }

        public Account RetrieveAccount(string aPhone)
        {
            Account retrievedAccount =
                accountRepository.Get(aPhone, ActualCountry.GetCountryTag());
            if (retrievedAccount == null)
            {
                throw new BusinessException("Móvil no registrado");
            }
            return retrievedAccount;
        }

        public bool IsAccountAlreadyRegistered(string aPhone)
        {
            Account retrievedAccount =
               accountRepository.Get(aPhone, ActualCountry.GetCountryTag());
            if (retrievedAccount == null)
            {
                return false;
            }
            throw new BusinessException("Móvil: " + aPhone + " ya registrado");
        }

        public CostPerMinute GetActualCost()
        {
            CostPerMinute a = costRepository.Get
                     ("", ActualCountry.GetCountryTag());
            return a;
        }

        private bool HasEnoughBalance(Account anAccount, Purchase aPurchase)
        {
            if (anAccount.Balance >= aPurchase.AmountOfMinutes * GetActualCost().Value)
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
                throw new BusinessException("Error, elija una hora para el dia" +
                    " de hoy que este entre las 10:00 y las 18:00");
            }
        }

        private bool IsPurchaseInRange(Purchase aPurchase, DateTime theMoment)
        {
            return theMoment >= aPurchase.StartingHour &&
                theMoment <= aPurchase.FinishingHour;
        }

        public bool IsPurchaseActive(string licencePlateToConfirm, DateTime theMoment)
        {
            licencePlateToConfirm =
                ActualCountry.FormatLicensePlate(licencePlateToConfirm);
            if (IsDateChosenInRange(theMoment))
            {
                foreach (Purchase p in purchaseRepository.GetAll())
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
                AddPurchase(aPurchase);
            }
        }
    }
}