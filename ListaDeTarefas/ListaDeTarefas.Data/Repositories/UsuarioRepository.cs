using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Data.Interfaces;
using ListaDeTarefas.Model;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Data.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApiContext apiContext) : base(apiContext)
        {
        }

        public Task<Usuario> GetByLogin(string usuario)
        {
            return ApiContext.Usuarios.FirstOrDefaultAsync(p => p.Login.Equals(usuario));
        }
    }
}