using PichinchaBank.Domain.Constans;

namespace PichinchaBank.Application.Models
{
    public class BankingTransactionRequest
    {
        public TransactionType TransactionType { get; set; }
        public int Amount { get; set; }
        public int AccountNumber { get; set; }
    }
}
