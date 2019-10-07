﻿using System;
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
                LengthOfNumberValidation(phoneNumberFormat))
            {
                this.Phone = aPhone;
                this.Balance = DEFAULT_BALANCE;
            }
            else
            {
                throw new ArgumentException("Formato incorrecto");
            }
        }

        public bool LengthOfNumberValidation(string aPhone)
        {
            return aPhone.Length == 9 || aPhone.Length == 8;
        }

        public bool StartOfPhoneNumberValidation(string aPhone)
        {
            return aPhone[0] == '0' && aPhone[1] == '9' || aPhone[0] == '9';
        }
    }
}