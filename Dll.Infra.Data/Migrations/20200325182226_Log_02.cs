using Microsoft.EntityFrameworkCore.Migrations;

namespace Dll.Infra.Data.Migrations
{
    public partial class Log_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_UsuarioLogadoLog",
                table: "Log");

            migrationBuilder.DropIndex(
                name: "IX_Log_IdUsuaruioLogado",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "UsuarioLogado");

            migrationBuilder.DropColumn(
                name: "IdUsuaruioLogado",
                table: "Log");

            migrationBuilder.RenameColumn(
                name: "DataInclusa0",
                table: "UsuarioLogado",
                newName: "DataInclusao");

            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "UsuarioLogado",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioLogado",
                table: "Log",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Log_IdUsuarioLogado",
                table: "Log",
                column: "IdUsuarioLogado");

            migrationBuilder.AddForeignKey(
                name: "fk_UsuarioLogadoLog",
                table: "Log",
                column: "IdUsuarioLogado",
                principalTable: "UsuarioLogado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_UsuarioLogadoLog",
                table: "Log");

            migrationBuilder.DropIndex(
                name: "IX_Log_IdUsuarioLogado",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "IP",
                table: "UsuarioLogado");

            migrationBuilder.DropColumn(
                name: "IdUsuarioLogado",
                table: "Log");

            migrationBuilder.RenameColumn(
                name: "DataInclusao",
                table: "UsuarioLogado",
                newName: "DataInclusa0");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "UsuarioLogado",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuaruioLogado",
                table: "Log",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Log_IdUsuaruioLogado",
                table: "Log",
                column: "IdUsuaruioLogado");

            migrationBuilder.AddForeignKey(
                name: "fk_UsuarioLogadoLog",
                table: "Log",
                column: "IdUsuaruioLogado",
                principalTable: "UsuarioLogado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
