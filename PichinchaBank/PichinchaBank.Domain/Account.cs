using PichinchaBank.Domain.Common;
using PichinchaBank.Domain.Constans;

namespace PichinchaBank.Domain
{
    public class Account : BaseDomainModel
    {
        public int AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public int InitialBalance { get; set; }

        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }
    }
}
