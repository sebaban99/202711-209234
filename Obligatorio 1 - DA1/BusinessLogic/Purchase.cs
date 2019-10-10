using System;
using System.Text;
using System.Text.RegularExpressions;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Purchase
    {
        public Account Account { get; set; }
        public string LicensePlate { get; set; }
        public DateTime StartingHour { get; set; }
        public DateTime FinishingHour { get; set; }

        public Purchase(int costPerMinute, string message, Account accountReceived)
        {
            string[] messageSplit = message.Split(new Char[] { ' ' });
            string[] actualMessage = ObtainActualMessage(messageSplit);
            if (validMessageLengths(actualMessage))
            {
                Account = accountReceived;
                LicensePlate = ExtractLicensePlate(actualMessage);
                StartingHour = CalculateStartingHour(actualMessage);
                FinishingHour = CalculateFinishingHour(actualMessage);
                Account.DecreaseBalance(CalculateBalanceToDecrease(costPerMinute, actualMessage));
            }
            else
            {
                throw new InvalidMessageFormatException("Mensaje incorrecto. Ej: ABC 1234 60 10:00");
            }


        }

        private static bool validMessageLengths(string[] actualMessage)
        {
            return actualMessage.Length == 4 || actualMessage.Length == 3 || actualMessage.Length == 2;
        }

        private string[] ObtainActualMessage(string[] messageSplit)
        {
            int notSpaceStrings = 0;
            foreach (string s in messageSplit)
            {
                if (s != "")
                {
                    notSpaceStrings++;
                }
            }
            string[] actualMessage = new string[notSpaceStrings];
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


        private int CalculateBalanceToDecrease(int costPerMinute, string[] messageSplit)
        {
            return ExtractMinutes(messageSplit) * costPerMinute;
        }

        private string ExtractLicensePlate(string[] messageSplit)
        {
            if (ValidateLicensePlateExtract(messageSplit))
            {
                return FormatExtract(messageSplit);
            }
            else
            {
                throw new InvalidMessageFormatException("Mensaje incorrecto.Ej: ABC 1234 60 10:00");
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

        private bool HourFormatValidation(string hour)
        {
            if (hour.Contains(":") && hour.IndexOf(':') != hour.Length)
            {
                string HH_half = hour.Substring(0, hour.IndexOf(':'));
                string mm_half = hour.Substring(hour.IndexOf(':') + 1);

                if (HH_half.Length == 2 && mm_half.Length == 2)
                {
                    if (ContainsNumbersOnly(HH_half) && ContainsNumbersOnly(mm_half))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private DateTime CalculateStartingHour(string[] messageSplit)
        {
            if (messageSplit.Length == 4)
            {
                if (HourFormatValidation(messageSplit[3]))
                {
                    return DateTime.Parse(getTodaysDate_dd_MM_yyyy() + " " + messageSplit[3]);
                }
                else
                {
                    throw new InvalidMessageFormatException("Mensaje incorrecto.Ej: ABC 1234 60 10:00");
                }
            }
            else if (messageSplit.Length == 2 || messageSplit[0].Length == 3)
            {
                return DateTime.Now;
            }
            else
            {
                return DateTime.Parse(getTodaysDate_dd_MM_yyyy() + " " + messageSplit[2]);
            }
        }



        private int ExtractMinutes(string[] messageSplit)
        {
            int amountOfMinutes = 0;
            if (messageSplit[0].Length == 3)
            {
                if (IsMultipleOf30(messageSplit[2]))
                {
                    amountOfMinutes = stringToInt(messageSplit[2]);
                    return amountOfMinutes;
                }
                else
                {
                    throw new InvalidMessageFormatException("Mensaje incorrecto.Ej: ABC 1234 60 10:00");
                }
            }
            else
            {
                if (IsMultipleOf30(messageSplit[1]))
                {
                    amountOfMinutes = stringToInt(messageSplit[1]);
                    return amountOfMinutes;
                }
                else
                {
                    throw new InvalidMessageFormatException("Mensaje incorrecto.Ej: ABC 1234 60 10:00");
                }
            }
        }

        private int stringToInt(string number)
        {
            return Int32.Parse(number);
        }

        private bool IsMultipleOf30(string number)
        {
            return Int32.Parse(number) % 30 == 0;
        }

        private string getTodaysDate_dd_MM_yyyy()
        {
            return DateTime.Today.ToString("dd/MM/yyyy");
        }

        private DateTime CalculateFinishingHour(string[] messageSplit)
        {
            if (StartingHour != null)
            {
                return StartingHour.AddMinutes(ExtractMinutes(messageSplit));
            }
            else
            {
                throw new ArgumentNullException();
            }


        }
    }
}