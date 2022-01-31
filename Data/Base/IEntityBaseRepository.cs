using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Etheater.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T,object>>[]IncludeProperties);

        public Task<T> GetByIdAsync(int Id);

        Task AddAsync(T entity);
        public Task UpdateAsync( T entity);
        Task DeleteAsync(int Id);
    }
}
