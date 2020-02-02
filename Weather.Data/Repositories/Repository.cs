using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Weather.Core.Repositories;

namespace Weather.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Adds T object to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Task</returns>
        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        /// <summary>
        /// Adds range of T objects to the database
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>Task</returns>
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
        }

        /// <summary>
        /// Finds list of T objects by condition expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>List of T</returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        /// <summary>
        /// Gets all the objects
        /// </summary>
        /// <returns>List of T</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Gets T object by integer identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T object</returns>
        public ValueTask<T> GetByIdAsync(int id)
        {
            return Context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Gets T object by long integer identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T object</returns>
        public ValueTask<T> GetByIdAsync(long id)
        {
            return Context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Removes T object
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Remove range of T objects
        /// </summary>
        /// <param name="entities"></param>
        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        /// <summary>
        /// Gets single T object by condition expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().SingleOrDefaultAsync(predicate);
        }
    }
}
