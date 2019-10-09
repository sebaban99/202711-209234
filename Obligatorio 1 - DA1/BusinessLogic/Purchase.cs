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

        public Purchase(int costPerMinute, string message)
        {
            string[] messageSplit = message.Split(new Char[] { ' ' });
            LicensePlate = extractLicensePlate(messageSplit);
            StartingHour = stringToDateTime(messageSplit);
            int amountOfMinutes = extractMinutes(messageSplit);
            FinishingHour = calculateFinishingHour(amountOfMinutes);
        }

        private string extractLicensePlate(string[] messageSplit)
        {
            return messageSplit[0] + " " + messageSplit[1];
        }

        private DateTime stringToDateTime(string[] messageSplit)
        {
            return DateTime.Parse(getTodaysDate_dd_MM_yyyy() + " " + messageSplit[3]);
        }

        private int extractMinutes(string[] messageSplit)
        {
            return Int32.Parse(messageSplit[2]);
        }
        private string getTodaysDate_dd_MM_yyyy()
        {
            return DateTime.Today.ToString("dd/MM/yyyy");
        }

        private DateTime calculateFinishingHour(int amountOfMinutes)
        {
            if (StartingHour != null)
                return StartingHour.AddMinutes(amountOfMinutes);
            else
                throw new ArgumentNullException();

        }
    }
}