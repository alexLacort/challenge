using MediatR;
using PichinchaBank.Application.Models;

namespace PichinchaBank.Application.Features.BankingTransactions.Queries
{
    public class GetReportTransactionsQuery : IRequest<IEnumerable<ReportResponse>>
    {
        public string Identification { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
