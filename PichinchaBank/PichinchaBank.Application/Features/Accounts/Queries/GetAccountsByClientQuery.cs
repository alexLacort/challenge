using MediatR;

using PichinchaBank.Domain;

namespace PichinchaBank.Application.Features.Accounts.Queries
{
    public class GetAccountsByClientQuery : IRequest<IEnumerable<AccountVm>>
    {
        public int ClientId { get; set; }
    }
}
