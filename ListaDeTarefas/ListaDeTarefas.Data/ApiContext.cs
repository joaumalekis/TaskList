using ListaDeTarefas.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace ListaDeTarefas.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var usuarioAdm = new Usuario { Nome = "Administrador", Senha = "12345", Id = Guid.NewGuid(), Login = "Admin" };

            modelBuilder.Entity<Usuario>().HasData(usuarioAdm);
        }
    }
}