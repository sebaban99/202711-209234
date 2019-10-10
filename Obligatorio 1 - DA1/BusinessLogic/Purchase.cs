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

        private bool isModified_NumbersOnMessage;

        private readonly DateTime MINIMUM_STARTING_HOUR = DateTime.Today.AddHours(10);
        private readonly DateTime MAXIMUM_HOUR = DateTime.Today.AddHours(18);

        public Purchase(int costPerMinute, string message, Account accountReceived)
        {
            string[] messageSplit = message.Split(new Char[] { ' ' });
            string[] actualMessage = ObtainActualMessage(messageSplit);
            isModified_NumbersOnMessage = false;

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
                    DateTime requestedStartingHour = DateTime.Parse(getTodaysDate_dd_MM_yyyy_Only() + " " + messageSplit[3]);
                    if (requestedStartingHour >= MINIMUM_STARTING_HOUR && requestedStartingHour < MAXIMUM_HOUR)
                    {
                        return requestedStartingHour;
                    }
                    else
                    {
                        throw new InvalidMessageFormatException("Mensaje incorrecto.Ej: ABC 1234 60 10:00");
                    }
                }
                else
                {
                    throw new InvalidMessageFormatException("Mensaje incorrecto.Ej: ABC 1234 60 10:00");
                }
            }
            else if (messageSplit.Length == 2 || messageSplit[0].Length == 3)
            {
                DateTime actualHour = DateTime.Now;
                if (actualHour >= MINIMUM_STARTING_HOUR && actualHour < MAXIMUM_HOUR)
                {
                    return actualHour;
                }
                else
                {
                    throw new InvalidMessageFormatException("Mensaje incorrecto.Ej: ABC 1234 60 10:00");
                }
            }
            else if (HourFormatValidation(messageSplit[2]))
            {
                DateTime requestedStartingHour = DateTime.Parse(getTodaysDate_dd_MM_yyyy_Only() + " " + messageSplit[2]);
                if (requestedStartingHour >= MINIMUM_STARTING_HOUR && requestedStartingHour < MAXIMUM_HOUR)
                {
                    return requestedStartingHour;
                }
                else
                {
                    throw new InvalidMessageFormatException("Mensaje incorrecto.Ej: ABC 1234 60 10:00");
                }
            }
            else
            {
                throw new InvalidMessageFormatException("Mensaje incorrecto.Ej: ABC 1234 60 10:00");
            }
        }

        private int ExtractMinutes(string[] messageSplit)
        {
            int amountOfMinutes = 0;
            if (!isModified_NumbersOnMessage)
            {
                if (messageSplit[0].Length == 3)
                {
                    if (IsMultipleOf30(messageSplit[2]))
                    {
                        amountOfMinutes = StringToInt(messageSplit[2]);
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
                        amountOfMinutes = StringToInt(messageSplit[1]);
                        return amountOfMinutes;
                    }
                    else
                    {
                        throw new InvalidMessageFormatException("Mensaje incorrecto.Ej: ABC 1234 60 10:00");
                    }
                }
            }
            else
            {
                if (messageSplit[0].Length == 3)
                {
                    amountOfMinutes = StringToInt(messageSplit[2]);
                    return amountOfMinutes;
                }
                else
                {
                    amountOfMinutes = StringToInt(messageSplit[1]);
                    return amountOfMinutes;
                }
            }

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

        public void ModifyMinutesInMessage(ref string[] message, int minutesToInsert)
        {
            if (message[0].Length == 3)
            {
                message[2] = minutesToInsert + "";
            }
            else
            {
                message[1] = minutesToInsert + "";
            }
            isModified_NumbersOnMessage = true;
        }

        private DateTime CalculateFinishingHour(string[] messageSplit)
        {
            if (StartingHour != null)
            {
                if (StartingHour.AddMinutes(ExtractMinutes(messageSplit)) > MAXIMUM_HOUR)
                {
                    TimeSpan minutesUntilMaximumHour = MAXIMUM_HOUR - StartingHour;
                    ModifyMinutesInMessage(ref messageSplit, (int)minutesUntilMaximumHour.TotalMinutes);
                    return MAXIMUM_HOUR;
                }
                else
                {
                    return StartingHour.AddMinutes(ExtractMinutes(messageSplit));
                }
            }
            else
            {
                throw new ArgumentNullException();
            }


        }
    }
}