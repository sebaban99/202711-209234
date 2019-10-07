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
            if (StartOfPhoneNumberValidation(phoneNumberFormat) && 
                (phoneNumberFormat.Length == 9 || phoneNumberFormat.Length == 8))
            {
                this.Phone = aPhone;
                this.Balance = DEFAULT_BALANCE;
            }
            else
            {
                throw new ArgumentException("Formato incorrecto");
            }
        }

        public bool StartOfPhoneNumberValidation(string aPhone)
        {
            return aPhone[0] == '0' && aPhone[1] == '9' || aPhone[0] == '9';
        }
    }
}
