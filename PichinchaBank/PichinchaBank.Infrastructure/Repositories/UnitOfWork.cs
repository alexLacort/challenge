using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Domain.Common;
using System.Collections;
using PichinchaBank.Infrastructure.Persistence;

namespace PichinchaBank.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable repositories;
        private readonly PichinchaBankDbContext context;
        private IClientRepository clienteRepository;
        private IAccountRepository accountRepository;
        private IBankTransactionRepository bankTransactionRepository;

        public UnitOfWork(PichinchaBankDbContext context)
        {
            this.context = context;
        }

        public PichinchaBankDbContext GetDataBaseContext => context;

        public IClientRepository CustomClientRepository => clienteRepository ??= new ClientRepository(context);

        public IAccountRepository CustomAccountRepository => accountRepository ??= new AccountRepository(context);

        public IBankTransactionRepository CustomBankTransactionRepository => bankTransactionRepository??= new BankTransactionRepository(context);

        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IPichinchaRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (repositories == null)
            {
                repositories = new Hashtable();
            }
            // obtener el nombre de la entidad que se esta trabajando
            var typeEntityName = typeof(TEntity).Name;
            if (!repositories.ContainsKey(typeEntityName))
            {
                var repositoryType = typeof(PichinchaRepository<>);
                var repositoryInstance = Activator.CreateInstance(
                    repositoryType.MakeGenericType(typeof(TEntity)),
                    context);
                repositories.Add(typeEntityName, repositoryInstance);
            }
            return (IPichinchaRepository<TEntity>)repositories[typeEntityName];
        }
    }
}
