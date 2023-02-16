using MediatR;
using PichinchaBank.Domain.Constans;

namespace PichinchaBank.Application.Features.BankingTransactions.Commands.Create
{
    public class CreateBankTransactionCommand : IRequest
    {
        public TransactionType TransactionType { get; set; }
        public int Amount { get; set; }
        public int AccountNumber { get; set; }

        public int Balance { get; set; }
        public int AccountId { get; set; }
    }
}
