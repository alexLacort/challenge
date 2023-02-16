using PichinchaBank.Domain.Common;
using PichinchaBank.Domain.Constans;

namespace PichinchaBank.Domain
{
    public class BankingTransaction: BaseDomainModel
    {   
        public TransactionType TransactionType { get; set; }
        public int Amount { get; set; }
        public int Balance { get; set; }

        public int AccountId { get; set; }
        public virtual Account? Account { get; set; }
    }
}
