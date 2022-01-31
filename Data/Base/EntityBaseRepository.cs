using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Etheater.Data.Base
{
    public class EntityBaseRepository <T>: IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext Context;
        public EntityBaseRepository(AppDbContext _Context)
        {
                Context= _Context;
        }
        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }
        

        public async Task DeleteAsync(int Id)
        {
            var entity = await Context.Set<T>().FirstOrDefaultAsync(n=>n.Id==Id);
            EntityEntry entityEntry = Context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await Context.SaveChangesAsync();

            






        }

        public async Task<IEnumerable<T>> GetAllAsync()=> await Context.Set<T>().ToListAsync();

       
        
        
        
        
        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, Object>> []IncludeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
          
           
            query = IncludeProperties.Aggregate(query, (current, IncludeProperty) => current.Include(IncludeProperty));
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id) => await Context.Set<T>().FirstOrDefaultAsync(n=>n.Id==Id);
          
        



       

        public async Task UpdateAsync(T entity)
        {
            EntityEntry entityEntry = Context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
