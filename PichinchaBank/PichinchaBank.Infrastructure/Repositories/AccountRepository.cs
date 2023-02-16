using Microsoft.EntityFrameworkCore;
using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Domain;
using PichinchaBank.Infrastructure.Persistence;

namespace PichinchaBank.Infrastructure.Repositories
{
    public class AccountRepository : PichinchaRepository<Account>, IAccountRepository
    {
        public AccountRepository(PichinchaBankDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Account>> GetAccountByClient(int clientId)
        {
            return await context.Accounts!.Where(a => a.ClientId == clientId).ToListAsync();
        }

        public async Task<Account> GetAccountByAccountNumber(int accountNumber)
        {
            return await context.Accounts!.Where(c => c.AccountNumber == accountNumber).FirstOrDefaultAsync();
        }
    }
}
