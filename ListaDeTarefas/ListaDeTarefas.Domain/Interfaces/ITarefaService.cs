using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ListaDeTarefas.Model;

namespace ListaDeTarefas.Domain.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> GetAllAsync();
        Task<Tarefa> FindAsync(Guid id);
        Task AddAsync(Tarefa tarefa);
        Task SaveChangesAsync();
        void Update(Tarefa tarefa);
        void Remove(Tarefa tarefa);
        bool Any(Func<Tarefa, bool> func);
    }
}