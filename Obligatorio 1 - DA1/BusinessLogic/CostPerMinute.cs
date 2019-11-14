using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public class CostPerMinute
    {
        public int ID { get; set; }
        public int Value { get; set; }
        public string CountryTag { get; set; }
        public CostPerMinute() { }
    }
}