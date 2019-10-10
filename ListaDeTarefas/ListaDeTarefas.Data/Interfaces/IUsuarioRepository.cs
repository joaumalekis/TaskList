using System.Threading.Tasks;
using ListaDeTarefas.Model;

namespace ListaDeTarefas.Data.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> GetByLogin(string usuario);
    }
}