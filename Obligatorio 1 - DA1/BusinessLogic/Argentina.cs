using System;
using System.Text;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Argentina
    {
        public Argentina() { }

        private bool IsPhoneNumberLengthValid(string phoneNumber)
        {
            return phoneNumber.Length == 6 || phoneNumber.Length == 7 ||
                phoneNumber.Length == 8;
        }

        private bool IsHyphenPositionValid(string phoneNumber)
        {
            return phoneNumber.IndexOf("-") != 0 &&
                phoneNumber.IndexOf("-") != phoneNumber.Length - 1;
        }

        private string RemoveHyphensFromString(string phoneNumber)
        {
            StringBuilder onlyNumbers = new StringBuilder(phoneNumber);
            onlyNumbers.Replace("-", "");
            return onlyNumbers.ToString();
        }

        public bool IsPhoneNumberValid(string phoneNumber)
        {
            if (IsHyphenPositionValid(phoneNumber))
            {
                return IsPhoneNumberLengthValid(RemoveHyphensFromString(phoneNumber));
            }
            else
            {
                throw new BusinessException("Número de teléfono inválido, " +
                         "guión en primera posición");
            }
        }
    }
}
