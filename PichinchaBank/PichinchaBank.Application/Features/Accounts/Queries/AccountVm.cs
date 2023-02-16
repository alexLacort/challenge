using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PichinchaBank.Domain.Constans;

namespace PichinchaBank.Application.Features.Accounts.Queries
{
    public class AccountVm
    {
        public int AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public int InitialBalance { get; set; }
        public StateType State { get; set; }
        public int Id { get; set; }
    }
}
