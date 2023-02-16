using PichinchaBank.Application.Features.Clients.Commands.Create;
using PichinchaBank.Application.Features.Clients.Commands.Delete;

namespace PichinchaBank.Application.Contracts.Services
{
    public interface IClientManager
    {
        Task DeleteClient(DeleteClientCommand request);

        Task<int> CreateClient(CreateClientCommand request);
    }
}
