using PichinchaBank.Domain.Common;

namespace PichinchaBank.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IPichinchaRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
        IClientRepository CustomClientRepository { get; }
        IAccountRepository CustomAccountRepository { get; }
        IBankTransactionRepository CustomBankTransactionRepository { get; }
    }
}
