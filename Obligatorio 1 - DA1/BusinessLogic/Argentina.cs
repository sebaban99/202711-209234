using System;

namespace BusinessLogic
{
    public class Argentina
    {
        public Argentina()
        {
        }

        private bool IsPhoneNumberLengthValid(string phoneNumber)
        {
            if (phoneNumber.Length == 6 || phoneNumber.Length == 7)
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
            return IsPhoneNumberLengthValid(phoneNumber);
        }


    }
}