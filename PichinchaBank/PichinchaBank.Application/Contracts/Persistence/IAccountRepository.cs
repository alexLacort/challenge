using PichinchaBank.Domain;

namespace PichinchaBank.Application.Contracts.Persistence
{
    public interface IAccountRepository : IPichinchaRepository<Account>
    {
        Task<Account> GetAccountByAccountNumber(int accountNumber);

        Task<IEnumerable<Account>> GetAccountByClient(int clientId);
    }
}
