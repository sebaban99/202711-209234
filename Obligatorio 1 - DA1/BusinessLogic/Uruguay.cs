using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Uruguay
    {
        private readonly DateTime MINIMUM_STARTING_HOUR = DateTime.Today.AddHours(10);
        private readonly DateTime MAXIMUM_HOUR = DateTime.Today.AddHours(18);

        private const string MESSAGE_FORMAT_XXX_YYYY_T_HHMM = "tipo 1";
        private const string MESSAGE_FORMAT_XXXYYYY_T_HHMM = "tipo 2";
        private const string MESSAGE_FORMAT_XXX_YYYY_T = "tipo 3";
        private const string MESSAGE_FORMAT_XXXYYYY_T = "tipo 4";

        private string actualMessageFormat;

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

        public virtual DateTime GetDateTimeNow()
        {
            return DateTime.Now;
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

        private bool IsHourValid(string hours)
        {
            return Int32.Parse(hours) >= 10 && Int32.Parse(hours) < 18;
        }

        private bool IsMinuteValid(string minutes)
        {
            return Int32.Parse(minutes) < 60;
        }

        private string GetTodaysDate_dd_MM_yyyy_Only()
        {
            return GetDateTimeNow().ToString("d", new CultureInfo("fr-FR"));
        }

        private bool IsHourAfterActualHour(string hour)
        {
            return GetDateTimeNow() <= DateTime.Parse(GetTodaysDate_dd_MM_yyyy_Only() + " " + hour,
                new CultureInfo("fr-FR"));
        }

        private bool IsMessageStartingHourValid(string hour)
        {
            if (hour.IndexOf(':') != hour.Length / 2)
            {
                return false;
            }
            else
            {
                string HH_half = hour.Substring(0, hour.IndexOf(':'));
                string mm_half = hour.Substring(hour.IndexOf(':') + 1);

                return HH_half.Length == 2 && mm_half.Length == 2 &&
                    ContainsNumbersOnly(HH_half) && ContainsNumbersOnly(mm_half) &&
                    IsHourValid(HH_half) && IsMinuteValid(mm_half) && IsHourAfterActualHour(hour);
            }
        }

        private int StringToInt(string number)
        {
            return Int32.Parse(number);
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

        private bool AreMinutesValid(string[] actualMessage)
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


        private bool IsStartingHourValid(string[] actualMessage)
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
                    IsHourValid = IsMessageStartingHourValid(actualMessage[3]);
                }
                else
                {
                    IsHourValid = IsMessageStartingHourValid(actualMessage[2]);
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

        public bool IsMessageValid(string message)
        {
            string[] messageSplit = message.Split(new Char[] { ' ' });
            string[] actualMessage = ObtainActualMessage(messageSplit);

            IdentifyMessageFormat(actualMessage);

            if (ValidMessageLengths(actualMessage))
            {
                return IsLicensePlateValid(actualMessage) &&
                    AreMinutesValid(actualMessage) &&
                    IsStartingHourValid(actualMessage);
            }
            else
            {
                throw new BusinessException("Mensaje incorrecto. Ej: ABC 1234 60 10:00");
            }
        }

        public int ExtractMinutes(string message)
        {
            string[] messageSplit = message.Split(new Char[] { ' ' });
            string[] actualMessage = ObtainActualMessage(messageSplit);

            IdentifyMessageFormat(actualMessage);

            if (actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T_HHMM) ||
               actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T))
            {
                return StringToInt(actualMessage[2]);
            }
            else
            {
                return StringToInt(actualMessage[1]);
            }
        }

        public DateTime ExtractStartingHour(string message)
        {
            string[] messageSplit = message.Split(new Char[] { ' ' });
            string[] actualMessage = ObtainActualMessage(messageSplit);

            IdentifyMessageFormat(actualMessage);

            if (actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T_HHMM))
            {
                string dateToParse = GetTodaysDate_dd_MM_yyyy_Only() + " " + actualMessage[3];
                return DateTime.Parse(dateToParse, new CultureInfo("fr-FR"));
            }
            else if (actualMessageFormat.Equals(MESSAGE_FORMAT_XXXYYYY_T) ||
                actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T))
            {
                return GetDateTimeNow();
            }
            else
            {
                string toParse = GetTodaysDate_dd_MM_yyyy_Only() + " " + actualMessage[2];
                return DateTime.Parse(toParse, new CultureInfo("fr-FR"));
            }
        }
    }
}
