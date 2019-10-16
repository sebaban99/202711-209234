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
                    throw new BusinessException("Móvil: " + aPhone + "ya registrado");
                }
            }
            return false;
            
        }

        public bool HasEnoughBalance(Account anAccount, Purchase aPurchase)
        {
            if (anAccount.Balance >= aPurchase.AmountOfMinutes * CostPerMinute)
            {
                return true;
            }
            throw new BusinessException("Saldo insuficiente");
        }

        public bool IsNumberPhoneValid(string aPhone)
        {
            string actualPhoneNumber = RemoveSpacesString(aPhone);

            if (ContainsNumbersOnly(actualPhoneNumber) &&
                (PhoneNumberValidationStartingWithNine(actualPhoneNumber)
                || PhoneNumberValidationStartingWithZero(actualPhoneNumber)))
                return true;
            else
            {
                throw new BusinessException("Formato de número de telefono incorrecto");
            }
        }

        private string RemoveSpacesString(string text)
        {
            StringBuilder stringWithoutSpaces = new StringBuilder(text);
            stringWithoutSpaces.Replace(" ", "");
            return stringWithoutSpaces.ToString();
        }

        private bool ContainsNumbersOnly(string message)
        {
            return Regex.IsMatch(message, @"^[0-9]+$");
        }

        private bool ContainsLettersOnly(string message)
        {
            return Regex.IsMatch(message, @"^[a-zA-Z]+$");
        }

        private bool PhoneNumberValidationStartingWithNine(string aPhone)
        {
            return aPhone[0] == '9' && aPhone.Length == 8;
        }

        private bool PhoneNumberValidationStartingWithZero(string aPhone)
        {
            return aPhone[0] == '0' && aPhone[1] == '9' && aPhone.Length == 9;
        }

        public string FormatPhoneNumber(string aPhone)
        {
            aPhone = RemoveSpacesString(aPhone);
            StringBuilder formattedNumber = new StringBuilder(aPhone);

            if (formattedNumber.ToString().Length == 8)
            {
                formattedNumber.Insert(0, 0);
            }
            formattedNumber.Insert(3, " ");
            formattedNumber.Insert(7, " ");
            return formattedNumber.ToString();
        }

        public bool IsLicensePlateValid(string licensePlate)
        {
            licensePlate = RemoveSpacesString(licensePlate);
            if (licensePlate.Length == 7 && ContainsLettersOnly(licensePlate.Substring(0, 3)) &&
                    ContainsNumbersOnly(licensePlate.Substring(3)))
            {
                return true;
            }
            else
            {
                throw new BusinessException("Formato de matricula incorrecto");
            }
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
            licencePlateToConfirm = FormatLicensePlate(licencePlateToConfirm);
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

        public string FormatLicensePlate(string licencePlate)
        {
            licencePlate = RemoveSpacesString(licencePlate);
            StringBuilder formattedLicensePlate = new StringBuilder(licencePlate);
            formattedLicensePlate.Replace(formattedLicensePlate.ToString().Substring(0, 3),
                formattedLicensePlate.ToString().Substring(0, 3).ToUpper().Trim());
            formattedLicensePlate.Insert(3, " ");
            return formattedLicensePlate.ToString();
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