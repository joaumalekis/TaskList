using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListaDeTarefas.Data.Migrations
{
    public partial class CreateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "Senha" },
                values: new object[] { new Guid("6b050e42-c54a-4a8f-bfef-c7ea09dbf308"), "Admin", "Administrador", "12345" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("6b050e42-c54a-4a8f-bfef-c7ea09dbf308"));
        }
    }
}
