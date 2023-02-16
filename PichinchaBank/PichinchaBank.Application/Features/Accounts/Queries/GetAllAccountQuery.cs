using MediatR;

namespace PichinchaBank.Application.Features.Accounts.Queries
{
    public class GetAllAccountQuery : IRequest<IEnumerable<AccountVm>>
    {
    }
}
