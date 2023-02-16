using PichinchaBank.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PichinchaBank.Application.Contracts.Persistence
{
    public interface IPichinchaRepository<T> where T : BaseDomainModel
    {
        #region Query
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        #endregion


        #region Command
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
        #endregion
    }
}
