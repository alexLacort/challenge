using Microsoft.EntityFrameworkCore;
using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Domain;
using PichinchaBank.Infrastructure.Persistence;

namespace PichinchaBank.Infrastructure.Repositories
{
    public class ClientRepository : PichinchaRepository<Client>, IClientRepository
    {
        public ClientRepository(PichinchaBankDbContext context) : base(context)
        {
        }

        public async Task<Client> GetClientByIdentification(string identification)
        {
            return await context.Clients!.Where(c => c.Identification == identification).FirstOrDefaultAsync();
        }
    }
}
