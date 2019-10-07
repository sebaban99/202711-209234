using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Account
    {
        public string Phone { get; set; }
        public object Balance { get; set; }

        private const int DEFAULT_BALANCE = 0;

        public Account(string aPhone)
        {
            StringBuilder ab = new StringBuilder(aPhone);
            ab.Replace(" ", "");

            if (PhoneNumberValidation(ab.ToString()))
            {
                aPhone = FormatNumber(ab);
                this.Phone = aPhone;
                this.Balance = DEFAULT_BALANCE;
            }
            else
            {
                throw new ArgumentException("Formato incorrecto");
            }
        }

        public string FormatNumber(StringBuilder aPhone)
        {
            if (aPhone.ToString().Length == 8)
            {
                aPhone.Insert(0, 0);
            }
            aPhone.Insert(3, " ");
            aPhone.Insert(7, " ");
            return aPhone.ToString();
        }

        public bool PhoneNumberValidation(string aPhone)
        {
            return PhoneNumberValidationOnlyNumbers(aPhone) &&
                (PhoneNumberValidationStartWithNine(aPhone)
                || PhoneNumberValidationStartWithZero(aPhone));
        }

        public bool PhoneNumberValidationOnlyNumbers(string aPhone)
        {
            foreach (char c in aPhone)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }

        public bool PhoneNumberValidationStartWithNine(string aPhone)
        {
            return aPhone[0] == '9' && aPhone.Length == 8;
        }

        public bool PhoneNumberValidationStartWithZero(string aPhone)
        {
            return aPhone[0] == '0' && aPhone[1] == '9' && aPhone.Length == 9;
        }

        public object DecreaseBalance(int v)
        {
            throw new NotImplementedException();
        }
    }
}
