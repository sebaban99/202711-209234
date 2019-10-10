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
            return extractMinutes(messageSplit) * costPerMinute;
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

        private bool ValidateLicensePlateExtract(string[] messageSplit)
        {
            if (messageSplit[0].Length == 7)
            {
                return true;
            }
            else if (messageSplit[0].Length == 3)
            {
                return Regex.IsMatch(messageSplit[0], @"^[a-zA-Z]+$") &&
                    Regex.IsMatch(messageSplit[1], @"^[0-9]+$");
            }
            else return false;
        }

        private string FormatExtract(string[] messageSplit)
        {
            if(messageSplit[0].Length == 7)
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

        private DateTime CalculateStartingHour(string[] messageSplit)
        {
            if (messageSplit.Length == 4)
            {
                return DateTime.Parse(getTodaysDate_dd_MM_yyyy() + " " + messageSplit[3]);
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

        private int extractMinutes(string[] messageSplit)
        {
            if (messageSplit.Length == 4)
            {
                return Int32.Parse(messageSplit[2]);
            }
            else if (messageSplit[0].Length == 3)
            {
                return Int32.Parse(messageSplit[2]);
            }
            else
            {
                return Int32.Parse(messageSplit[1]);
            }
        }
        private string getTodaysDate_dd_MM_yyyy()
        {
            return DateTime.Today.ToString("dd/MM/yyyy");
        }

        private DateTime CalculateFinishingHour(string[] messageSplit)
        {
            if (StartingHour != null)
            {
                return StartingHour.AddMinutes(extractMinutes(messageSplit));
            }
            else
            {
                throw new ArgumentNullException();
            }


        }
    }
}