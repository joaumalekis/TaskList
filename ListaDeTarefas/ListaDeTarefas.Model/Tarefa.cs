using System;
using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefas.Model
{
    public class Tarefa
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataEdicao { get; set; }
        public DateTime? DataRemocao { get; set; }
        public DateTime? DataConclusao { get; set; }

        public StatusTarefa StatusTarefa { get; set; }
    }

    public enum StatusTarefa
    {
        Ativa,
        Concluida,
        Removida
    }
}