using PichinchaBank.Application.Models;
using PichinchaBank.Domain;

namespace PichinchaBank.Application.Contracts.Persistence
{
    public interface IBankTransactionRepository : IPichinchaRepository<BankingTransaction>
    {   
        #region Query
        Task<IEnumerable<ReportResponse>> ReportTransactions(DateTime initialDate, DateTime endDate, string identification);
        #endregion
    }
}
