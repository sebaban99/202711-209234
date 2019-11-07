using System;
using System.Text;

namespace BusinessLogic
{
    public class Argentina
    {
        public Argentina()
        {
        }

        private bool IsPhoneNumberLengthValid(string phoneNumber)
        {
            if (phoneNumber.Length == 6 || phoneNumber.Length == 7 ||
                phoneNumber.Length == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPhoneNumberValid(string phoneNumber)
        {
            StringBuilder onlyNumbers = new StringBuilder(phoneNumber);
            onlyNumbers.Replace("-", "");
            return IsPhoneNumberLengthValid(onlyNumbers.ToString());
        }


    }
}