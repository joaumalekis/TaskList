using System;
using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefas.Model
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}