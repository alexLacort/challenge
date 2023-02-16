using PichinchaBank.Domain.Constans;

namespace PichinchaBank.Application.Models
{
    public class AccountRequest
    {
        public int AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public int InitialBalance { get; set; }
        public string Identification { get; set; }
    }
}
