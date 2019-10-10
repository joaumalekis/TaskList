using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using ListaDeTarefas.Auth;
using ListaDeTarefas.Domain.Dtos;
using ListaDeTarefas.Domain.Enums;
using ListaDeTarefas.Domain.Interfaces;
using ListaDeTarefas.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors;
using Microsoft.IdentityModel.Tokens;

namespace ListaDeTarefas.Controllers
{
    /// <summary>
    /// Api para retorno dos dados das tarefas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        /// <inheritdoc />
        public AuthController(IUsuarioService scaUsuarioService)
        {
            _usuarioService = scaUsuarioService;
        }

        /// <summary>
        /// Retorna a lista de tarefas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { teste = "Teste" });
        }

        /// <summary>
        /// Autentica o usuário
        /// </summary>
        /// <param name="usuarioLoginDto">Dto de autenticação do usuário</param>
        /// <returns>Retorna do Dto com dados de autenticação</returns>
        [AllowAnonymous]
        [HttpPost]
        [EnableCors("ListaDeTarefasMePolicy")]
        public async Task<IActionResult> Post([FromBody] UsuarioLoginDto usuarioLoginDto,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            var tokenDto = await _usuarioService.ValidarLogin(usuarioLoginDto);

            switch (tokenDto.SituacaoAutenticacaoUsuario)
            {
                case EnumSituacaoAutenticacaoUsuario.Autenticado:
                    var name = $"{tokenDto.Login}_PhoenixEs";
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(name, ApiResource.Login),
                        new[] {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                            new Claim(JwtRegisteredClaimNames.UniqueName, name)
                        }
                    );

                    var dataCriacao = DateTime.Now;
                    var dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                    {
                        Issuer = tokenConfigurations.Issuer,
                        Audience = tokenConfigurations.Audience,
                        SigningCredentials = signingConfigurations.SigningCredentials,
                        Subject = identity,
                        NotBefore = dataCriacao,
                        Expires = dataExpiracao
                    });
                    var token = handler.WriteToken(securityToken);

                    tokenDto.AccessToken = token;
                    tokenDto.CriadoEm = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss");
                    tokenDto.ExpiraEm = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss");
                    tokenDto.Mensagem = ApiResource.OK;

                    return Ok(tokenDto);

                case EnumSituacaoAutenticacaoUsuario.NaoEncontrado:
                    tokenDto.Mensagem = ApiResource.Usuario_nao_encontrado;
                    return NotFound(tokenDto);
                case EnumSituacaoAutenticacaoUsuario.Bloqueado:
                    tokenDto.Mensagem = ApiResource.Usuario_bloqueado;
                    return Unauthorized(tokenDto);
                case EnumSituacaoAutenticacaoUsuario.SenhaInvalida:
                    tokenDto.Mensagem = ApiResource.Senha_invalida;
                    return Unauthorized(tokenDto);
                case EnumSituacaoAutenticacaoUsuario.UsuarioOuSenhaNaoInformado:
                    tokenDto.Mensagem = ApiResource.Usuario_ou_senha_nao_foi_informado;
                    return Unauthorized(tokenDto);
                default:
                    return BadRequest();
            }
        }
    }
}