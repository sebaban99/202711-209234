using System;

namespace BusinessLogic
{
    public class Argentina
    {
        public Argentina()
        {
        }

        public bool IsPhoneNumberValid(string phoneNumber)
        {
            if(phoneNumber.Length == 6 || phoneNumber.Length == 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}