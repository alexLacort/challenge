using PichinchaBank.Application.Features.BankingTransactions.Queries;
using PichinchaBank.Application.Models;

namespace PichinchaBank.Application.Contracts.Services
{
    public interface IBankTransactionManager
    {
        Task CreateBankTransaction(BankingTransactionRequest request);
        Task<IEnumerable<ReportResponse>> TransactionReport(GetReportTransactionsQuery request);
    }
}
