using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ListaDeTarefas.Data.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(Guid id);
        Task AddAsync(T item);
        void Update(T item);
        void Remove(T item);
        Task SaveChangesAsync();
        bool Any(Func<T, bool> func);
    }
}