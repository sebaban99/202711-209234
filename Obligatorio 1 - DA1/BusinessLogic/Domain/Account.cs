namespace BusinessLogic.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public int Balance { get; set; }
        public string CountryTag { get; set; }

        public Account() { }

    }   
}