using System;
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

        public Purchase(string message)
        {
            string[] messageSplit = message.Split(new Char[] { ' ' });
            string[] actualMessage = ObtainActualMessage(messageSplit);

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

        private static bool ValidMessageLengths(string[] message)
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

        private bool ValidateLicensePlateExtract(string[] messageSplit)
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

        private string FormatExtract(string[] messageSplit)
        {
            if (messageSplit[0].Length == 7)
            {
                StringBuilder licensePlateToExtract = new StringBuilder(messageSplit[0]);
                licensePlateToExtract.Insert(3, " ");
                return licensePlateToExtract.ToString();
            }
            else
            {
                return messageSplit[0] + " " + messageSplit[1];
            }
        }

        private string ExtractLicensePlate(string[] messageSplit)
        {
            if (ValidateLicensePlateExtract(messageSplit))
            {
                return FormatExtract(messageSplit);
            }
            else
            {
                throw new BusinessException("Mensaje incorrecto.Ej: ABC 1234 60 10:00");
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

        private bool HourFormatValidation(string hour)
        {
            if (hour.IndexOf(':') == hour.Length / 2)
            {
                string HH_half = hour.Substring(0, hour.IndexOf(':'));
                string mm_half = hour.Substring(hour.IndexOf(':') + 1);

                return HH_half.Length == 2 && mm_half.Length == 2 &&
                    ContainsNumbersOnly(HH_half) && ContainsNumbersOnly(mm_half);
            }
            return false;
        }

        private DateTime CalculateStartingHour(string[] messageSplit)
        {
            if (messageSplit.Length == 4)
            {
                if (HourFormatValidation(messageSplit[3]))
                {
                    DateTime requestedStartingHour = DateTime.Parse(getTodaysDate_dd_MM_yyyy_Only() + " " + messageSplit[3]);
                    if (requestedStartingHour >= MINIMUM_STARTING_HOUR && requestedStartingHour < MAXIMUM_HOUR)
                    {
                        return requestedStartingHour;
                    }
                }
            }
            else if (messageSplit.Length == 2 || messageSplit[0].Length == 3)
            {
                DateTime actualHour = DateTime.Now;
                if (actualHour >= MINIMUM_STARTING_HOUR && actualHour < MAXIMUM_HOUR)
                {
                    return actualHour;
                }
            }
            else if (HourFormatValidation(messageSplit[2]))
            {
                DateTime requestedStartingHour = DateTime.Parse(getTodaysDate_dd_MM_yyyy_Only() + " " + messageSplit[2]);
                if (requestedStartingHour >= MINIMUM_STARTING_HOUR && requestedStartingHour < MAXIMUM_HOUR)
                {
                    return requestedStartingHour;
                }
            }
            throw new BusinessException("Mensaje incorrecto.Ej: ABC 1234 60 10:00");
        }

        private int ExtractMinutes(string[] messageSplit)
        {
            int minutes = 0;
            if (messageSplit[0].Length == 3)
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
            throw new BusinessException("Mensaje incorrecto.Ej: ABC 1234 60 10:00");
        }

        private int StringToInt(string number)
        {
            return Int32.Parse(number);
        }

        private bool IsMultipleOf30(string number)
        {

            return StringToInt(number) % 30 == 0 && StringToInt(number) != 0;
        }

        private string getTodaysDate_dd_MM_yyyy_Only()
        {
            return DateTime.Today.ToString("dd/MM/yyyy");
        }

        private DateTime CalculateFinishingHour(string[] messageSplit)
        {
            if (StartingHour.AddMinutes(ExtractMinutes(messageSplit)) > MAXIMUM_HOUR)
            {
                TimeSpan minutesUntilMaximumHour = MAXIMUM_HOUR - StartingHour;
                AmountOfMinutes = (int)minutesUntilMaximumHour.TotalMinutes;
                return MAXIMUM_HOUR;
            }
            else
            {
                AmountOfMinutes = ExtractMinutes(messageSplit);
                return StartingHour.AddMinutes(ExtractMinutes(messageSplit));
            }
        }
    }
}