using AutoMapper;
using MediatR;
using PichinchaBank.Application.Contracts.Services;
using PichinchaBank.Application.Exceptions;
using PichinchaBank.Application.Features.Accounts.Commands.Update;
using PichinchaBank.Application.Features.Accounts.Queries;
using PichinchaBank.Application.Features.BankingTransactions.Commands.Create;
using PichinchaBank.Application.Features.BankingTransactions.Queries;
using PichinchaBank.Application.Models;

namespace PichinchaBank.Application.Services
{
    public class BankTransactionManager : IBankTransactionManager
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public BankTransactionManager(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task CreateBankTransaction(BankingTransactionRequest request)
        {
            var accountExist = await mediator.Send(new GetAccountByIdNumberQuery { AccountNumber = request.AccountNumber });
            if (accountExist == null)
            {
                throw new NotFoundException($"The account {request.AccountNumber} associated with the bank transaction doesn't exist");
            }
            int calculateBalance = 0;
            switch (request.TransactionType)
            {
                case Domain.Constans.TransactionType.Withdrawals:
                    calculateBalance = accountExist.InitialBalance - request.Amount;
                    if (calculateBalance < 0)
                    {
                        throw new InsufficientFundsException($"The account number: {request.AccountNumber} dont have enough funds");
                    }
                    break;
                case Domain.Constans.TransactionType.Deposit:
                    calculateBalance = accountExist.InitialBalance + request.Amount;
                    break;
            }

            var transaction = mapper.Map<CreateBankTransactionCommand>(request);
            transaction.AccountId = accountExist.Id;
            transaction.Balance = calculateBalance;
            accountExist.InitialBalance = calculateBalance;

            await mediator.Send(transaction);

            var updateAccountBalance = mapper.Map<UpdateAccountCommand>(accountExist);
            await mediator.Send(updateAccountBalance);
        }

        public async Task<IEnumerable<ReportResponse>> TransactionReport(GetReportTransactionsQuery request)
        {
            return await mediator.Send(request);
        }
    }
}
