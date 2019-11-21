using System;

namespace BusinessLogic.Domain
{
    public class Purchase
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public DateTime StartingHour { get; set; }
        public DateTime FinishingHour { get; set; }
        public int AmountOfMinutes { get; set; }
        public string CountryTag { get; set; }

        public Purchase() { }
    }
}