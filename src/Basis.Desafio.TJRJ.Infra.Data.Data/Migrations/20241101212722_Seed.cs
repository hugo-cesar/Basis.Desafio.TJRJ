using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Livro_Assunto",
                columns: new[] { "Livro_CodL", "Assunto_CodAs" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 7 },
                    { 2, 1 },
                    { 2, 10 },
                    { 3, 1 },
                    { 4, 1 },
                    { 4, 7 },
                    { 5, 2 },
                    { 6, 1 },
                    { 6, 16 },
                    { 7, 1 },
                    { 8, 10 },
                    { 9, 7 },
                    { 10, 1 },
                    { 11, 7 },
                    { 12, 1 },
                    { 13, 1 },
                    { 14, 1 },
                    { 14, 8 },
                    { 15, 1 }
                });

            migrationBuilder.InsertData(
                table: "Livro_Autor",
                columns: new[] { "Autor_CodAu", "Livro_CodL" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 1, 4 },
                    { 4, 5 },
                    { 5, 6 },
                    { 6, 7 },
                    { 7, 8 },
                    { 8, 9 },
                    { 9, 10 },
                    { 10, 11 },
                    { 3, 12 },
                    { 10, 13 },
                    { 1, 14 },
                    { 4, 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 6, 16 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 11, 7 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 14, 8 });

            migrationBuilder.DeleteData(
                table: "Livro_Assunto",
                keyColumns: new[] { "Livro_CodL", "Assunto_CodAs" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 10, 11 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 10, 13 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "Livro_Autor",
                keyColumns: new[] { "Autor_CodAu", "Livro_CodL" },
                keyValues: new object[] { 4, 15 });
        }
    }
}
