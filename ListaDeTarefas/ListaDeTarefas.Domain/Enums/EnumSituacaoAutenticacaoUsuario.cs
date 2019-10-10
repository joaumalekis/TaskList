namespace ListaDeTarefas.Domain.Enums
{
    /// <summary>
    /// Enum de situação do usuário
    /// </summary>
    public enum EnumSituacaoAutenticacaoUsuario
    {
        /// <summary>
        /// 0 - Não encontrado
        /// </summary>
        NaoEncontrado,
        /// <summary>
        /// 1 - Autenticado
        /// </summary>
        Autenticado,
        /// <summary>
        /// 2 - Bloqueado
        /// </summary>
        Bloqueado,
        /// <summary>
        /// 3 - Senha inválida
        /// </summary>
        SenhaInvalida,
        /// <summary>
        /// 4 - Não cadastrado
        /// </summary>
        NaoCadastrado,
        /// <summary>
        /// 5 - Usuário ou Senha não informado
        /// </summary>
        UsuarioOuSenhaNaoInformado
    }
}