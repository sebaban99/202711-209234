using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Purchase
    {
        public string LicensePlate { get; set; }
        public DateTime StartingHour { get; set; }
        public DateTime FinishingHour { get; set; }
        public int AmountOfMinutes { get; set; }


        private readonly DateTime MINIMUM_STARTING_HOUR = DateTime.Today.AddHours(10);
        private readonly DateTime MAXIMUM_HOUR = DateTime.Today.AddHours(18);

        private const string MESSAGE_FORMAT_XXX_YYYY_T_HHMM = "tipo 1";
        private const string MESSAGE_FORMAT_XXXYYYY_T_HHMM = "tipo 2";
        private const string MESSAGE_FORMAT_XXX_YYYY_T = "tipo 3";
        private const string MESSAGE_FORMAT_XXXYYYY_T = "tipo 4";

        private string actualMessageFormat;

        public Purchase() { }

        public void SetPurchaseProperties(string message)
        {
            string[] messageSplit = message.Split(new Char[] { ' ' });
            string[] actualMessage = ObtainActualMessage(messageSplit);

            IdentifyMessageFormat(actualMessage);

            if (ValidMessageLengths(actualMessage))
            {
                LicensePlate = ExtractLicensePlate(actualMessage);
                StartingHour = CalculateStartingHour(actualMessage);
                FinishingHour = CalculateFinishingHour(actualMessage);
            }
            else
            {
                throw new BusinessException("Mensaje incorrecto. Ej: ABC 1234 60 10:00");
            }
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

        private bool IsLicensePlateExtractValid(string[] messageSplit)
        {
            if (messageSplit[0].Length == 7)
            {
                return ContainsLettersOnly(messageSplit[0].Substring(0, 3)) &&
                    ContainsNumbersOnly(messageSplit[0].Substring(3));
            }
            else if (messageSplit[0].Length == 3 && messageSplit[1].Length == 4)
            {
                return ContainsLettersOnly(messageSplit[0]) &&
                    ContainsNumbersOnly(messageSplit[1]);
            }
            else return false;
        }

        private string FormatLicensePlateExtract(string[] messageSplit)
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

        private string ExtractLicensePlate(string[] messageSplit)
        {
            if (IsLicensePlateExtractValid(messageSplit))
            {
                return FormatLicensePlateExtract(messageSplit);
            }
            else
            {
                throw new BusinessException("Mensaje incorrecto, formato de " +
                    " licencia inválida. Ej: ABC 1234 60 10:00");
            }

        }

        private bool ContainsLettersOnly(string message)
        {
            return Regex.IsMatch(message, @"^[a-zA-Z]+$");
        }

        private bool ContainsNumbersOnly(string message)
        {
            return Regex.IsMatch(message, @"^[0-9]+$");
        }

        private bool IsHourValid(string hours)
        {
            return Int32.Parse(hours) >= 10 && Int32.Parse(hours) < 18;
        }

        private bool IsMinuteValid(string minutes)
        {
            return Int32.Parse(minutes) < 60;
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

        private DateTime CalculateStartingHour(string[] messageSplit)
        {
            if (GetDateTimeNow() < MINIMUM_STARTING_HOUR || GetDateTimeNow() >= MAXIMUM_HOUR)
            {
                throw new BusinessException("Parking cerrado, horario de 10:00 a 18:00");
            }
            else
            {
                if (actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T_HHMM))
                {
                    if (IsMessageStartingHourValid(messageSplit[3]))
                    {
                        string dateToParse = GetTodaysDate_dd_MM_yyyy_Only() + " " + messageSplit[3];
                        return DateTime.Parse(dateToParse, new CultureInfo("fr-FR"));
                    }
                    throw new BusinessException("Hora inválida, verifique que la hora " +
                        "inical sea una hora entre la hora actual y las 18:00" +
                        " con el formato correcto HH:mm");
                }
                else if (actualMessageFormat.Equals(MESSAGE_FORMAT_XXXYYYY_T) ||
                    actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T))
                {
                    return GetDateTimeNow();
                }
                else if (IsMessageStartingHourValid(messageSplit[2]))
                {
                    string toParse = GetTodaysDate_dd_MM_yyyy_Only() + " " + messageSplit[2];
                    return DateTime.Parse(toParse, new CultureInfo("fr-FR"));
                }
                throw new BusinessException("Hora incorrecta, verifique que la hora" +
                    " ingresada este entre la hora actual y las 18" +
                    " y tenga el formato correcto HH:mm");
            }
        }

        private int ExtractMinutes(string[] messageSplit)
        {
            int minutes = 0;
            if (actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T_HHMM) ||
                actualMessageFormat.Equals(MESSAGE_FORMAT_XXX_YYYY_T))
            {
                if (IsMultipleOf30(messageSplit[2]))
                {
                    minutes = StringToInt(messageSplit[2]);
                    return minutes;
                }
            }
            else
            {
                if (IsMultipleOf30(messageSplit[1]))
                {
                    minutes = StringToInt(messageSplit[1]);
                    return minutes;
                }
            }
            throw new BusinessException("Mensaje incorrecto, cantidad de" +
                " minutos es 0 o no es múltiplo de 30");
        }

        private int StringToInt(string number)
        {
            return Int32.Parse(number);
        }

        private bool IsMultipleOf30(string number)
        {
            return StringToInt(number) % 30 == 0 && StringToInt(number) != 0;
        }

        private string GetTodaysDate_dd_MM_yyyy_Only()
        {
            return DateTime.Now.ToString("d", new CultureInfo("fr-FR"));
        }

        private DateTime CalculateFinishingHour(string[] messageSplit)
        {
            int minutesExtractedFromMessage = ExtractMinutes(messageSplit);
            if (StartingHour.AddMinutes(minutesExtractedFromMessage) > MAXIMUM_HOUR)
            {
                TimeSpan minutesUntilMaximumHour = MAXIMUM_HOUR - StartingHour;
                AmountOfMinutes = (int)minutesUntilMaximumHour.TotalMinutes;
                return MAXIMUM_HOUR;
            }
            else
            {
                AmountOfMinutes = minutesExtractedFromMessage;
                return StartingHour.AddMinutes(ExtractMinutes(messageSplit));
            }
        }

        public virtual DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }
    }
}