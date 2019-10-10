using System.Collections.Generic;
using System.Threading.Tasks;
using ListaDeTarefas.Domain.Dtos;
using ListaDeTarefas.Model;

namespace ListaDeTarefas.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task<TokenDto> ValidarLogin(UsuarioLoginDto usuarioLoginDto);
        Task<IEnumerable<Usuario>> GetAllAsync();
    }
}