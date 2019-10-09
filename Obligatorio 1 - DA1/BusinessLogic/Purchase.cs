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
            StartingHour = stringToDateTime(messageSplit);
            FinishingHour = calculateFinishingHour(messageSplit);
            DecreaseBalanceOnAccount(costPerMinute, messageSplit);
     
            //else
            //{

            //    LicensePlate = extractLicensePlate(messageSplit);
            //    StartingHour = stringToDateTime(messageSplit);
            //    int amountOfMinutes = Int32.Parse(messageSplit[1]);
            //    FinishingHour = calculateFinishingHour(messageSplit);
            //    int balanceToDecrease = amountOfMinutes * costPerMinute;
            //    Account = accountReceived;
            //    Account.DecreaseBalance(balanceToDecrease);
            //}

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
            if (messageSplit.Length == 4)
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