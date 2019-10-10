using ListaDeTarefas.Domain.Enums;

namespace ListaDeTarefas.Domain.Dtos
{
    /// <summary>
    /// Dto de retorno da autenticação
    /// </summary>
    public class TokenDto
    {
        /// <summary>
        /// Data de criaçao do token
        /// </summary>
        public string CriadoEm { get; set; }

        /// <summary>
        /// Data de experição do token
        /// </summary>
        public string ExpiraEm { get; set; }

        /// <summary>
        /// Token de acesso
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Mensagem { get; set; }

        

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Login do usuário
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Situação da autenticação do usuário
        /// </summary>
        public EnumSituacaoAutenticacaoUsuario SituacaoAutenticacaoUsuario { get; set; }
    }
}