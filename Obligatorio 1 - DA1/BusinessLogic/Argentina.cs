using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Argentina
    {
        private readonly DateTime MINIMUM_STARTING_HOUR = DateTime.Today.AddHours(10);
        private readonly DateTime MAXIMUM_HOUR = DateTime.Today.AddHours(18);

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

        public bool IsPhoneNumberValid(string phoneNumber)
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
            return  GetDateTimeNow().ToString("d", new CultureInfo("fr-FR"));
        }

        private bool IsHourAfterActualHour(string hour)
        {
            return GetDateTimeNow() <= DateTime.Parse(GetTodaysDate_dd_MM_yyyy_Only()
                + " " + hour, new CultureInfo("fr-FR"));
        }

        private bool IsHourFormatValid(string hour)
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
                    IsHourValid(HH_half) && IsMinuteValid(mm_half) &&
                    IsHourAfterActualHour(hour);
            }
        }

        private bool IsStartingHourValid(string[] actualMessage)
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

        public bool IsMessageValid(string message)
        {
            string[] messageInArray = MessageToArray(message);

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

        private int StringToInt(string number)
        {
            return Int32.Parse(number);
        }

        public int ExtractMinutes(string message)
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

        public DateTime ExtractFinishingHour(string message)
        {
            DateTime finishingHour = ExtractStartingHour(message);
            finishingHour = finishingHour.AddMinutes(ExtractMinutes(message));
            if (finishingHour > MAXIMUM_HOUR)
            {
                return MAXIMUM_HOUR;
            }
            else return finishingHour;
        }

        public DateTime ExtractStartingHour(string message)
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

        private string FormatLicensePlate(string[] messageSplit)
        {
            if (messageSplit[0].Length == 7)
            {
                StringBuilder licensePlateToExtract = new StringBuilder(messageSplit[0]);
                licensePlateToExtract.Replace(licensePlateToExtract.ToString().Substring(0, 3),
                    licensePlateToExtract.ToString().Substring(0, 3).ToUpper().Trim());
                licensePlateToExtract.Insert(3, " ");
                return licensePlateToExtract.ToString();
            }
            else
            {
                return messageSplit[0].ToUpper().Trim() + " " + messageSplit[1];
            }
        }

        public string ExtractLicensePlate(string message)
        {
            string[] messageInArray = MessageToArray(message);
            return FormatLicensePlate(messageInArray);
        }

        public string[] MessageToArray(string message)
        {
            string[] messageSplit = message.Split(new Char[] { ' ' });
            return ObtainActualMessage(messageSplit);
        }

        public virtual DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }
    }
}
