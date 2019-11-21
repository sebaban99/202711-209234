using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public class CostPerMinute
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string CountryTag { get; set; }
        public CostPerMinute() { }
    }
}