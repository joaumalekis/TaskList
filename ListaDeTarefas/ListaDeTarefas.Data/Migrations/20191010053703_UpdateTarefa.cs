using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListaDeTarefas.Data.Migrations
{
    public partial class UpdateTarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Status_StatusId",
                table: "Tarefas");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_StatusId",
                table: "Tarefas");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("6b050e42-c54a-4a8f-bfef-c7ea09dbf308"));

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRemocao",
                table: "Tarefas",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEdicao",
                table: "Tarefas",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataConclusao",
                table: "Tarefas",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "StatusTarefa",
                table: "Tarefas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "Senha" },
                values: new object[] { new Guid("d9135e33-9763-493c-9c36-e9fa427e150e"), "Admin", "Administrador", "12345" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("d9135e33-9763-493c-9c36-e9fa427e150e"));

            migrationBuilder.DropColumn(
                name: "StatusTarefa",
                table: "Tarefas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRemocao",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEdicao",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataConclusao",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Tarefas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "Senha" },
                values: new object[] { new Guid("6b050e42-c54a-4a8f-bfef-c7ea09dbf308"), "Admin", "Administrador", "12345" });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_StatusId",
                table: "Tarefas",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Status_StatusId",
                table: "Tarefas",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
