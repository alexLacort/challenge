using MediatR;
using PichinchaBank.Domain.Constans;

namespace PichinchaBank.Application.Features.Accounts.Commands.Create
{
    public class CreateAccountCommand : IRequest<int>
    {
        public int AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public int InitialBalance { get; set; }
        public string Identification { get; set; }
        public int ClientId { get; set; }

    }
}
