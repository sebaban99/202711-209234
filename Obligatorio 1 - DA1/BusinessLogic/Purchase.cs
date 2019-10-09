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
            if (messageSplit.Length == 3)
            {
                if(messageSplit[0].Length == 3)
                {
                    Account = accountReceived;
                    LicensePlate = messageSplit[0] + " " + messageSplit[1];
                    StartingHour = DateTime.Now;
                    FinishingHour = StartingHour.AddMinutes(Int32.Parse(messageSplit[2]));
                    Account.Balance -= Int32.Parse(messageSplit[2]) * costPerMinute;
                }
                else
                {
                    Account = accountReceived;
                    LicensePlate = extractLicensePlate(messageSplit);
                    StartingHour = stringToDateTime(messageSplit);
                    FinishingHour = calculateFinishingHour(messageSplit);
                    DecreaseBalanceOnAccount(costPerMinute, messageSplit);
                }
            }
            else
            {
                Account = accountReceived;
                LicensePlate = extractLicensePlate(messageSplit);
                StartingHour = stringToDateTime(messageSplit);
                FinishingHour = calculateFinishingHour(messageSplit);
                DecreaseBalanceOnAccount(costPerMinute, messageSplit);
            }
        }

        private void DecreaseBalanceOnAccount(int costPerMinute, string[] messageSplit)
        {
            int balanceToDecrease = extractMinutes(messageSplit) * costPerMinute;
            Account.DecreaseBalance(balanceToDecrease);
        }

        private string extractLicensePlate(string[] messageSplit)
        {
            if (messageSplit.Length == 4)
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

        private DateTime stringToDateTime(string[] messageSplit)
        {
            if (messageSplit.Length == 2)
            {
                return DateTime.Now;
            }
            else if (messageSplit.Length == 4)
            {
                return DateTime.Parse(getTodaysDate_dd_MM_yyyy() + " " + messageSplit[3]);
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