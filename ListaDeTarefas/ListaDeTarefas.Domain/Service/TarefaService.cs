using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ListaDeTarefas.Data.Interfaces;
using ListaDeTarefas.Domain.Interfaces;
using ListaDeTarefas.Model;

namespace ListaDeTarefas.Domain.Service
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<IEnumerable<Tarefa>> GetAllAsync()
        {
            return await _tarefaRepository.GetAllAsync();
        }

        public async Task<Tarefa> FindAsync(Guid id)
        {
            return await _tarefaRepository.FindAsync(id);
        }

        public async Task AddAsync(Tarefa tarefa)
        {
            await _tarefaRepository.AddAsync(tarefa);
        }

        public async Task SaveChangesAsync()
        {
            await _tarefaRepository.SaveChangesAsync();
        }

        public void Update(Tarefa tarefa)
        {
            _tarefaRepository.Update(tarefa);
        }

        public void Remove(Tarefa tarefa)
        {
            _tarefaRepository.Remove(tarefa);
        }

        public bool Any(Func<Tarefa, bool> func)
        {
            return _tarefaRepository.Any(func);
        }
    }
}