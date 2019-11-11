using System;
using System.Text;
using System.Text.RegularExpressions;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Uruguay
    {
        public Uruguay() { }

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

        public bool IsPhoneNumberValid(string phoneNumber)
        {
            string actualPhoneNumber = RemoveSpacesString(phoneNumber);
            if (ContainsNumbersOnly(actualPhoneNumber) &&
                (PhoneNumberValidationStartingWithNine(actualPhoneNumber)
                || PhoneNumberValidationStartingWithZero(actualPhoneNumber)))
            {
                return true;
            }
            else
            {
                throw new BusinessException("Formato de número de telefono incorrecto");
            }
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
    }
}