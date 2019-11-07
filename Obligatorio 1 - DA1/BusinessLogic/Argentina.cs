using System;
using System.Text;
using System.Text.RegularExpressions;
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
            if (IsHyphenPositionValid(phoneNumber) &&
                IsPhoneNumberLengthValid(RemoveHyphensFromString(phoneNumber)))
            {
                return true;
            }
            else
            {
                throw new BusinessException("Número de teléfono inválido, " +
                         "guión en primera posición");
            }
        }

        private string[] ObtainActualMessage(string[] messageSplit)
        {
            int notEmptyStrings = 0;
            foreach (string s in messageSplit)
            {
                if (s != "")
                {
                    notEmptyStrings++;
                }
            }
            string[] actualMessage = new string[notEmptyStrings];
            int actualMessageIndex = 0;
            foreach (string s in messageSplit)
            {
                if (s != "")
                {
                    actualMessage[actualMessageIndex] = string.Copy(s);
                    actualMessageIndex++;
                }
            }
            return actualMessage;
        }

        private bool ContainsLettersOnly(string message)
        {
            return Regex.IsMatch(message, @"^[a-zA-Z]+$");
        }

        private bool ContainsNumbersOnly(string message)
        {
            return Regex.IsMatch(message, @"^[0-9]+$");
        }

        private bool IsLicensePlateValid(string[] actualMessage)
        {
            bool IsLicensePlateValid = false;
            if (actualMessage[0].Length == 7)
            {
                 IsLicensePlateValid = 
                    ContainsLettersOnly(actualMessage[0].Substring(0, 3)) &&
                    ContainsNumbersOnly(actualMessage[0].Substring(3));
            }
            else if (actualMessage[0].Length == 3 && actualMessage[1].Length == 4)
            {
                IsLicensePlateValid = ContainsLettersOnly(actualMessage[0]) &&
                    ContainsNumbersOnly(actualMessage[1]);
            }
            if (!IsLicensePlateValid)
            {
                throw new BusinessException("Formato de licencia incorrecto");
            }
            else return true;
        }

        private bool IsMessageLengthValid(string[] actualMessage)
        {
            return actualMessage.Length == 3 || actualMessage.Length == 4;
        }

        public bool IsMessageValid(string message)
        {
            string[] messageSplit = message.Split(new Char[] { ' ' });
            string[] actualMessage = ObtainActualMessage(messageSplit);
            if (IsMessageLengthValid(actualMessage))
            {
                return IsLicensePlateValid(actualMessage);
            }
            else
            {
                throw new BusinessException("Largo de mensaje incorrecto, " +
                    "verificar mensaje");
            }
        }

        public virtual DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }
    }
}
