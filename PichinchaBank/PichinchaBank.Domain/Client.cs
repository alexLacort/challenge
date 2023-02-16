namespace PichinchaBank.Domain
{
    public class Client : Person
    {   
        public string Password { get; set; }

        public ICollection<Account>? Accounts { get; set; }
    }
}
