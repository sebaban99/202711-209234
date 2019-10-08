using System;

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
            throw new NotImplementedException();
        }
    }
}