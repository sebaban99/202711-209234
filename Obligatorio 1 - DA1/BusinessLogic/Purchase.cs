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
            LicensePlate = messageSplit[0] + " " + messageSplit[1];
            StartingHour = DateTime.Parse(DateTime.Today.ToString("dd/MM/yyyy") + " " + messageSplit[3]);
            int amountOfMinutes = Int32.Parse(messageSplit[2]);
            FinishingHour = StartingHour.AddMinutes(amountOfMinutes);
        }
    }
}