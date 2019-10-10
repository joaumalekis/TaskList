using System.Collections.Generic;
using System.Threading.Tasks;
using ListaDeTarefas.Data.Interfaces;
using ListaDeTarefas.Domain.Dtos;
using ListaDeTarefas.Domain.Enums;
using ListaDeTarefas.Domain.Interfaces;
using ListaDeTarefas.Model;

namespace ListaDeTarefas.Domain.Service
{
    public class UsuarioService : IUsuarioService
    {


        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<TokenDto> ValidarLogin(UsuarioLoginDto usuarioLoginDto)
        {
            if (string.IsNullOrEmpty(usuarioLoginDto?.Usuario) || string.IsNullOrEmpty(usuarioLoginDto.Senha))
                return new TokenDto
                {
                    SituacaoAutenticacaoUsuario = EnumSituacaoAutenticacaoUsuario.UsuarioOuSenhaNaoInformado
                };


            var usuario = await _usuarioRepository.GetByLogin(usuarioLoginDto.Usuario);

            if (usuario == null)
                return new TokenDto
                {
                    SituacaoAutenticacaoUsuario = EnumSituacaoAutenticacaoUsuario.NaoEncontrado
                };


            if (!usuario.Senha.Equals(usuarioLoginDto.Senha))
                return new TokenDto
                {
                    SituacaoAutenticacaoUsuario = EnumSituacaoAutenticacaoUsuario.SenhaInvalida
                };

            return new TokenDto
            {
                SituacaoAutenticacaoUsuario = EnumSituacaoAutenticacaoUsuario.Autenticado,
                Nome = usuario.Nome,
                Login = usuario.Login
            };
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }
    }
}