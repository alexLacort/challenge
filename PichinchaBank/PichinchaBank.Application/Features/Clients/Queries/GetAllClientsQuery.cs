using MediatR;
using PichinchaBank.Application.Features.Accounts.Queries;

namespace PichinchaBank.Application.Features.Clients.Queries
{
    public class GetAllClientsQuery : IRequest<IEnumerable<ClientVm>>
    {
    }
}
