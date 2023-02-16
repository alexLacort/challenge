using MediatR;

namespace PichinchaBank.Application.Features.Accounts.Queries
{
    public class GetAccountByIdNumberQuery : IRequest<AccountVm>
    {
        public int AccountNumber { get; set; }
    }
}
