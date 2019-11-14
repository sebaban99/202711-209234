using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Uruguay : Country
    {
        private const string MESSAGE_FORMAT_XXX_YYYY_T_HHMM = "tipo 1";
        private const string MESSAGE_FORMAT_XXXYYYY_T_HHMM = "tipo 2";
        private const string MESSAGE_FORMAT_XXX_YYYY_T = "tipo 3";
        private const string MESSAGE_FORMAT_XXXYYYY_T = "tipo 4";

        private string actualMessageFormat;

        public Uruguay() {

            countryTag = "UY";
        }

        private string RemoveSpacesString(string text)
        {
            StringBuilder stringWithoutSpaces = new StringBuilder(text);
            stringWithoutSpaces.Replace(" ", "");
            return stringWithoutSpaces.ToString();
        }

        private bool PhoneNumberValidationStartingWithNine(string aPhone)
        {
            return aPhone[0] == '9' && aPhone.Length == 8;
        }

        private bool PhoneNumberValidationStartingWithZero(string aPhone)
        {
            return aPhone[0] == '0' && aPhone[1] == '9' && aPhone.Length == 9;
        }

        public override bool IsPhoneNumberValid(string phoneNumber)
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

        public override string FormatPhoneNumber(string aPhone)
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

        private void IdentifyMessageFormat(string[] message)
        {
            if (message.Length == 4)
            {
                actualMessageFormat = MESSAGE_FORMAT_XXX_YYYY_T_HHMM;
            }
            else if (message.Length == 2)
            {
                actualMessageFormat = MESSAGE_FORMAT_XXXYYYY_T;
            }
            else if (message[0].Length == 3)
            {
                actualMessageFormat = MESSAGE_FORMAT_XXX_YYYY_T;
            }
            else
            {
                actualMessageFormat = MESSAGE_FORMAT_XXXYYYY_T_HHMM;
            }
        }

        private bool ValidMessageLengths(string[] message)
        {
            return message.Length == 4 || message.Length == 3 ||
                message.Length == 2;
        }

        private bool IsMultipleOf30(string number)
        {
            if (StringToInt(number) % 30 == 0 && StringToInt(number) != 0)
            {
                return true;
            }
            else
            {
                throw new BusinessException("Mensaje incorrecto, cantidad de" +
               " minutos es 0 o no es múltiplo de 30");
            }
        }

        protected override bool AreMinutesValid(string[] actualMessage)
        {
            if (actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T_HHMM) ||
               actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T))
            {
                return IsMultipleOf30(actualMessage[2]);
            }
            else
            {
                return IsMultipleOf30(actualMessage[1]);
            }
        }

        protected override bool IsStartingHourValid(string[] actualMessage)
        {
            if (GetDateTimeNow() < MINIMUM_STARTING_HOUR ||
                GetDateTimeNow() >= MAXIMUM_HOUR)
            {
                throw new BusinessException("Parking cerrado," +
                    " horario de 10:00 a 18:00");
            }
            else if (actualMessageFormat.Equals(MESSAGE_FORMAT_XXXYYYY_T) ||
                    actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T))
            {
                return true;
            }
            else
            {
                bool IsHourValid = false;
                if (actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T_HHMM))
                {
                    IsHourValid = IsHourFormatValid(actualMessage[3]);
                }
                else
                {
                    IsHourValid = IsHourFormatValid(actualMessage[2]);
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

        public override bool IsMessageValid(string message)
        {
            string[] messageInArray = MessageToArray(message);

            IdentifyMessageFormat(messageInArray);

            if (ValidMessageLengths(messageInArray))
            {
                return IsLicensePlateValid(messageInArray) &&
                    AreMinutesValid(messageInArray) &&
                    IsStartingHourValid(messageInArray);
            }
            else
            {
                throw new BusinessException("Mensaje incorrecto. Ej: ABC 1234 60 10:00");
            }
        }

        public override int ExtractMinutes(string message)
        {
            string[] messageInArray = MessageToArray(message);

            IdentifyMessageFormat(messageInArray);

            if (actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T_HHMM) ||
               actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T))
            {
                return StringToInt(messageInArray[2]);
            }
            else
            {
                return StringToInt(messageInArray[1]);
            }
        }

        public override DateTime ExtractStartingHour(string message)
        {
            string[] messageInArray = MessageToArray(message);

            IdentifyMessageFormat(messageInArray);

            if (actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T_HHMM))
            {
                string dateToParse = GetTodaysDate_dd_MM_yyyy_Only() + " " + messageInArray[3];
                return DateTime.Parse(dateToParse, new CultureInfo("fr-FR"));
            }
            else if (actualMessageFormat.Equals(MESSAGE_FORMAT_XXXYYYY_T) ||
                actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T))
            {
                return GetDateTimeNow();
            }
            else
            {
                string toParse = GetTodaysDate_dd_MM_yyyy_Only() + " " + messageInArray[2];
                return DateTime.Parse(toParse, new CultureInfo("fr-FR"));
            }
        }
        
        public override DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }
    }
}
