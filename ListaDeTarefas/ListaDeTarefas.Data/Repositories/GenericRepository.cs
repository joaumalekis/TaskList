using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Data.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApiContext ApiContext;

        protected GenericRepository(ApiContext apiContext)
        {
            ApiContext = apiContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await ApiContext.Set<T>().ToListAsync();
        }

        public async Task<T> FindAsync(Guid id)
        {
            return await ApiContext.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T item)
        {
            await ApiContext.AddAsync(item);
        }

        public void Update(T item)
        {
            ApiContext.Update(item);
        }

        public void Remove(T item)
        {
            ApiContext.Remove(item);
        }

        public async Task SaveChangesAsync()
        {
            await ApiContext.SaveChangesAsync();
        }

        public bool Any(Func<T, bool> func)
        {
            return ApiContext.Set<T>().Any(func);
        }
    }
}