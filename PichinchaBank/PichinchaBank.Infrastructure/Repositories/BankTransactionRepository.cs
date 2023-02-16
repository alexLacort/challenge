using Microsoft.EntityFrameworkCore;
using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Application.Models;
using PichinchaBank.Domain;
using PichinchaBank.Infrastructure.Persistence;

namespace PichinchaBank.Infrastructure.Repositories
{
    public class BankTransactionRepository : PichinchaRepository<BankingTransaction>, IBankTransactionRepository
    {
        public BankTransactionRepository(PichinchaBankDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ReportResponse>> ReportTransactions(DateTime initialDate, DateTime endDate, string identification)
        {
            return await context.Clients.Join(context.Accounts, clientEntity => clientEntity.Id, accountEntity => accountEntity.ClientId, (clientEntity, accountEntity) =>
            new
            {
                Name = clientEntity.Name,
                AccounNumber = accountEntity.AccountNumber,
                AccountType = accountEntity.AccountType,
                InitialBalance = accountEntity.InitialBalance,
                Identification = clientEntity.Identification,
                AccountId = accountEntity.Id
            }).Join(context.BankTransactions, accountIdentify => accountIdentify.AccountId, transactions => transactions.AccountId, (accountIdentify, transactions) => new { accountIdentify, transactions })
            .Where(x => x.accountIdentify.Identification == identification && x.transactions.CreateDate >= initialDate && x.transactions.CreateDate <= endDate)
            .Select(s => new ReportResponse
            {
                TransactionDate = s.transactions.CreateDate.Value.ToString("dd/MM/yyyy"),
                Client = s.accountIdentify.Name,
                AccountNumber = s.accountIdentify.AccounNumber,
                AccountType = s.accountIdentify.AccountType,
                InitialBalance = s.accountIdentify.InitialBalance,
                StateType = s.transactions.State,
                Amount = s.transactions.Amount,
                Balance = s.transactions.Balance
            }).ToListAsync();
        }
    }
}
