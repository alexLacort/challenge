using PichinchaBank.Domain.Constans;

namespace PichinchaBank.Application.Models
{
    public class ReportResponse
    {
        public string TransactionDate { get; set; }
        public string Client { get; set; }
        public int AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public int InitialBalance { get; set; }
        public StateType StateType { get; set; }
        public int Amount { get; set; }
        public int Balance { get; set; }
    }
}
