using MediatR;
using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Application.Models;

namespace PichinchaBank.Application.Features.BankingTransactions.Queries
{
    public class GetReportTransactionsHandler : IRequestHandler<GetReportTransactionsQuery, IEnumerable<ReportResponse>>
    {
        private readonly IUnitOfWork uow;

        public GetReportTransactionsHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<ReportResponse>> Handle(GetReportTransactionsQuery request, CancellationToken cancellationToken)
        {
            return await uow.CustomBankTransactionRepository.ReportTransactions(request.InitialDate, request.EndDate, request.Identification);
        }
    }
}
