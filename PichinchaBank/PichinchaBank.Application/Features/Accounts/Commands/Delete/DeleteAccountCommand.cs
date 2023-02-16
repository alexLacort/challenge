using MediatR;

namespace PichinchaBank.Application.Features.Accounts.Commands.Delete
{
    public class DeleteAccountCommand : IRequest
    {
        public int AccountNumber { get; set; }
    }
}
