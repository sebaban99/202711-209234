using System;
using System.Text;
using System.Text.RegularExpressions;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Argentina
    {
        private readonly DateTime MINIMUM_STARTING_HOUR = DateTime.Today.AddHours(10);

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
            bool isLicensePlateValid = false;
            if (actualMessage[0].Length == 7)
            {
                 isLicensePlateValid = 
                    ContainsLettersOnly(actualMessage[0].Substring(0, 3)) &&
                    ContainsNumbersOnly(actualMessage[0].Substring(3));
            }
            else if (actualMessage[0].Length == 3 && actualMessage[1].Length == 4)
            {
                isLicensePlateValid = ContainsLettersOnly(actualMessage[0]) &&
                    ContainsNumbersOnly(actualMessage[1]);
            }
            if (!isLicensePlateValid)
            {
                throw new BusinessException("Formato de licencia incorrecto");
            }
            else return true;
        }

        private bool AreMinutesValid(string[] actualMessage)
        {
            bool areMinutesValid = false;
            if (actualMessage[0].Length == 7)
            {
                areMinutesValid = ContainsNumbersOnly(actualMessage[2]) &&
                    Int32.Parse(actualMessage[2]) > 0;
            }
            else
            {
                areMinutesValid = ContainsNumbersOnly(actualMessage[3]) &&
                    Int32.Parse(actualMessage[3]) > 0;
            }
            if (!areMinutesValid)
            {
                throw new BusinessException("Minutos inexistentes o inválidos," +
                    "verifique que sean un entero mayor que 0");
            }
            else return true;
        }

        private bool IsStartingHourValid(string[] actualMessage)
        {
            if(GetDateTimeNow() < MINIMUM_STARTING_HOUR)
            {
                throw new BusinessException("Parking cerrado, horario de 10:00 a 18:00");
            }
            else return true;
        }

        private bool IsMessageFormatValid(string[] actualMessage)
        {
            if (actualMessage.Length == 3)
            {
                return actualMessage[0].Length == 7;
            }
            else return actualMessage.Length == 4;
        }

        public bool IsMessageValid(string message)
        {
            string[] messageSplit = message.Split(new Char[] { ' ' });
            string[] actualMessage = ObtainActualMessage(messageSplit);
            if (IsMessageFormatValid(actualMessage))
            {
                return IsLicensePlateValid(actualMessage) &&
                    AreMinutesValid(actualMessage) &&
                    IsStartingHourValid(actualMessage);
            }
            else
            {
                throw new BusinessException("Formato de mensaje incorrecto, " +
                    "verificar que todas las partes esten presentes." +
                    " Ej: ABC 1234 10:30 50, ABC1234 10:30 50");
            }
        }

        public virtual DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }
    }
}
