using PichinchaBank.Domain;

namespace PichinchaBank.Application.Contracts.Persistence
{
    public interface IClientRepository: IPichinchaRepository<Client>
    {
        Task<Client> GetClientByIdentification(string identification);
    }
}
