using System;
using System.Text;

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

            Account = accountReceived;
            LicensePlate = extractLicensePlate(messageSplit);
            StartingHour = calculateStartingHour(messageSplit);
            FinishingHour = calculateFinishingHour(messageSplit);
            Account.DecreaseBalance(CalculateBalanceToDecrease(costPerMinute, messageSplit));

        }

        private int CalculateBalanceToDecrease(int costPerMinute, string[] messageSplit)
        {
            return extractMinutes(messageSplit) * costPerMinute;

        }

        private string extractLicensePlate(string[] messageSplit)
        {
            if (messageSplit.Length == 4 || messageSplit[0].Length == 3)
            {
                return messageSplit[0] + " " + messageSplit[1];
            }
            else
            {
                StringBuilder sb = new StringBuilder(messageSplit[0]);
                sb.Insert(3, " ");
                return sb.ToString();
            }
        }

        private DateTime calculateStartingHour(string[] messageSplit)
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

        private DateTime calculateFinishingHour(string[] messageSplit)
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