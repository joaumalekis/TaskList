namespace ListaDeTarefas.Domain.Dtos
{
    /// <summary>
    /// Dto de autenticação do usuário
    /// </summary>
    public class UsuarioLoginDto
    {
        /// <summary>
        /// Login do usuário
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        public string Senha { get; set; }
    }
}