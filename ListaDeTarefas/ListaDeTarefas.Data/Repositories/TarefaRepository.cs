using ListaDeTarefas.Data.Interfaces;
using ListaDeTarefas.Model;

namespace ListaDeTarefas.Data.Repositories
{
    public class TarefaRepository : GenericRepository<Tarefa> , ITarefaRepository
    {
        public TarefaRepository(ApiContext apiContext) : base(apiContext)
        {
        }
    }
}