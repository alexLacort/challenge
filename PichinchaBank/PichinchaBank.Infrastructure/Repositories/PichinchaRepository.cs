using Microsoft.EntityFrameworkCore;
using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Domain.Common;
using PichinchaBank.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace PichinchaBank.Infrastructure.Repositories
{
    public class PichinchaRepository<T> : IPichinchaRepository<T> where T : BaseDomainModel
    {
        protected readonly PichinchaBankDbContext context;

        public PichinchaRepository(PichinchaBankDbContext context)
        {
            this.context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public void AddEntity(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void DeleteEntity(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void UpdateEntity(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
