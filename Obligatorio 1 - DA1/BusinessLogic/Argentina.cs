using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Argentina : Country
    {
        public Argentina() {

            countryTag = "AR";
        }

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

        private bool Contains2HyphensInARow(string phoneNumber)
        {
            bool areInRow = false;
            for(int i = 0; i < phoneNumber.Length && !areInRow; i++)
            {
                if(i != phoneNumber.Length - 1)
                {
                    areInRow = phoneNumber[i].Equals('-') &&
                        phoneNumber[i + 1].Equals('-');
                }
            }
            return areInRow;
        }

        private string RemoveHyphensFromString(string phoneNumber)
        {
            StringBuilder onlyNumbers = new StringBuilder(phoneNumber);
            onlyNumbers.Replace("-", "");
            return onlyNumbers.ToString();
        }

        public override bool IsPhoneNumberValid(string phoneNumber)
        {
            if (IsHyphenPositionValid(phoneNumber) &&
                !Contains2HyphensInARow(phoneNumber) &&
                IsPhoneNumberLengthValid(RemoveHyphensFromString(phoneNumber)))
            {
                return true;
            }
            else
            {
                throw new BusinessException("Número de teléfono inválido, " +
                    "verifique que no contenga giones en primera o última " +
                    "posición, o seguidos");
            }
        }

        protected override bool AreMinutesValid(string[] actualMessage)
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

        protected override bool IsStartingHourValid(string[] actualMessage)
        {
            if (GetDateTimeNow() < MINIMUM_STARTING_HOUR)
            {
                throw new BusinessException("Parking cerrado," +
                    " horario de 10:00 a 18:00");
            }
            else
            {
                bool IsHourValid = false;
                if (actualMessage[0].Length == 7)
                {
                    if (IsHourFormatValid(actualMessage[1]))
                    {
                        IsHourValid = true;
                    }
                }
                else
                {
                    if (IsHourFormatValid(actualMessage[2]))
                    {
                        IsHourValid = true;
                    }
                }
                if (!IsHourValid)
                {
                    throw new BusinessException("Hora inválida, " +
                            "verifique que la hora inical sea una hora entre la" +
                            " hora actual y las 18:00 con el formato correcto HH:mm");

                }
                else return true;
            }
        }

        private bool IsMessageFormatValid(string[] actualMessage)
        {
            if (actualMessage.Length == 3)
            {
                return actualMessage[0].Length == 7;
            }
            else return actualMessage.Length == 4;
        }

        public override bool IsMessageValid(string message)
        {
            string[] messageInArray = base.MessageToArray(message);

            if (IsMessageFormatValid(messageInArray))
            {
                return IsLicensePlateValid(messageInArray) &&
                    AreMinutesValid(messageInArray) &&
                    IsStartingHourValid(messageInArray);
            }
            else
            {
                throw new BusinessException("Formato de mensaje incorrecto, " +
                    "verificar que todas las partes esten presentes." +
                    " Ej: ABC 1234 10:30 50, ABC1234 10:30 50");
            }
        }

        public override int ExtractMinutes(string message)
        {
            string[] messageInArray = MessageToArray(message);
            if (messageInArray[0].Length == 7)
            {
                return StringToInt(messageInArray[2]);
            }
            else
            {
                return StringToInt(messageInArray[3]);
            }
        }

        public override DateTime ExtractStartingHour(string message)
        {
            string[] messageInArray = MessageToArray(message);

            if (messageInArray[0].Length == 7)
            {
                string dateToParse = GetTodaysDate_dd_MM_yyyy_Only() +
                    " " + messageInArray[1];
                return DateTime.Parse(dateToParse, new CultureInfo("fr-FR"));
            }
            else
            {
                string dateToParse = GetTodaysDate_dd_MM_yyyy_Only() +
                    " " + messageInArray[2];
                return DateTime.Parse(dateToParse, new CultureInfo("fr-FR"));
            }
        }
    }
}
