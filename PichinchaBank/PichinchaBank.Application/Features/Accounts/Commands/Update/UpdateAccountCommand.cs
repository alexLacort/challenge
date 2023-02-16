using MediatR;
using PichinchaBank.Domain.Constans;

namespace PichinchaBank.Application.Features.Accounts.Commands.Update
{
    public class UpdateAccountCommand : IRequest
    {
        public int AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public int InitialBalance { get; set; }
        public StateType State { get; set; }
    }
}
