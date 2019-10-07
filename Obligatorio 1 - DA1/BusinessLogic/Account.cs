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
            string phoneNumberFormat = aPhone.Replace(" ", "");

            if (PhoneNumberValidationOnlyNumbers(phoneNumberFormat) && 
                (PhoneNumberValidationStartWithNine(phoneNumberFormat)
                || PhoneNumberValidationStartWithZero(phoneNumberFormat)))
            {
                this.Phone = aPhone;
                this.Balance = DEFAULT_BALANCE;
            }
            else
            {
                throw new ArgumentException("Formato incorrecto");
            }
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
    }
}
