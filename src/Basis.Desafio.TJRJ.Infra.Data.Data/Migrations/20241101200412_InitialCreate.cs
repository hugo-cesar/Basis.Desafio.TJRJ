using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assunto",
                columns: table => new
                {
                    CodAs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assunto", x => x.CodAs);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    CodAu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.CodAu);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    CodL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(40)", nullable: false),
                    Editora = table.Column<string>(type: "varchar(40)", nullable: false),
                    Edicao = table.Column<int>(type: "int", nullable: false),
                    AnoPublicacao = table.Column<string>(type: "varchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.CodL);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Compra",
                columns: table => new
                {
                    CodTC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Compra", x => x.CodTC);
                });

            migrationBuilder.CreateTable(
                name: "Livro_Assunto",
                columns: table => new
                {
                    Livro_CodL = table.Column<int>(type: "int", nullable: false),
                    Assunto_CodAs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro_Assunto", x => new { x.Livro_CodL, x.Assunto_CodAs });
                    table.ForeignKey(
                        name: "FK_Livro_Assunto_Assunto_Assunto_CodAs",
                        column: x => x.Assunto_CodAs,
                        principalTable: "Assunto",
                        principalColumn: "CodAs",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_Assunto_Livro_Livro_CodL",
                        column: x => x.Livro_CodL,
                        principalTable: "Livro",
                        principalColumn: "CodL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livro_Autor",
                columns: table => new
                {
                    Livro_CodL = table.Column<int>(type: "int", nullable: false),
                    Autor_CodAu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro_Autor", x => new { x.Livro_CodL, x.Autor_CodAu });
                    table.ForeignKey(
                        name: "FK_Livro_Autor_Autor_Autor_CodAu",
                        column: x => x.Autor_CodAu,
                        principalTable: "Autor",
                        principalColumn: "CodAu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_Autor_Livro_Livro_CodL",
                        column: x => x.Livro_CodL,
                        principalTable: "Livro",
                        principalColumn: "CodL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livro_Tipo_Compra",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    PurchaseTypeId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro_Tipo_Compra", x => new { x.BookId, x.PurchaseTypeId });
                    table.ForeignKey(
                        name: "FK_Livro_Tipo_Compra_Livro_BookId",
                        column: x => x.BookId,
                        principalTable: "Livro",
                        principalColumn: "CodL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_Tipo_Compra_Tipo_Compra_PurchaseTypeId",
                        column: x => x.PurchaseTypeId,
                        principalTable: "Tipo_Compra",
                        principalColumn: "CodTC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Assunto",
                columns: new[] { "CodAs", "Descricao" },
                values: new object[,]
                {
                    { 1, "Ficção" },
                    { 2, "Romance" },
                    { 3, "Aventura" },
                    { 4, "Fantasia" },
                    { 5, "Mistério" },
                    { 6, "Terror" },
                    { 7, "Drama" },
                    { 8, "Comédia" },
                    { 9, "Biografia" },
                    { 10, "História" },
                    { 11, "Poesia" },
                    { 12, "Crônica" },
                    { 13, "Literatura Infantil" },
                    { 14, "Educação" },
                    { 15, "Autoajuda" },
                    { 16, "Ciência" },
                    { 17, "Filosofia" },
                    { 18, "Sociedade" },
                    { 19, "Cultura" },
                    { 20, "Religião" }
                });

            migrationBuilder.InsertData(
                table: "Autor",
                columns: new[] { "CodAu", "Nome" },
                values: new object[,]
                {
                    { 1, "Machado de Assis" },
                    { 2, "Jorge Amado" },
                    { 3, "Clarice Lispector" },
                    { 4, "Carlos Drummond de Andrade" },
                    { 5, "José Saramago" },
                    { 6, "Raquel de Queiroz" },
                    { 7, "Guimarães Rosa" },
                    { 8, "Érico Veríssimo" },
                    { 9, "Lygia Fagundes Telles" },
                    { 10, "Adélia Prado" }
                });

            migrationBuilder.InsertData(
                table: "Livro",
                columns: new[] { "CodL", "Edicao", "AnoPublicacao", "Editora", "Titulo" },
                values: new object[,]
                {
                    { 1, 1, "1899", "Editora A", "Dom Casmurro" },
                    { 2, 1, "1958", "Editora B", "Gabriela, Cravo e Canela" },
                    { 3, 1, "1844", "Editora C", "A Moreninha" },
                    { 4, 1, "1881", "Editora D", "Memórias Póstumas de Brás Cubas" },
                    { 5, 1, "1857", "Editora E", "O Guarani" },
                    { 6, 1, "1988", "Editora F", "O Alquimista" },
                    { 7, 1, "1967", "Editora G", "Cem Anos de Solidão" },
                    { 8, 1, "1902", "Editora H", "Os Sertões" },
                    { 9, 1, "1977", "Editora I", "A Hora da Estrela" },
                    { 10, 1, "1878", "Editora J", "O Primo Basílio" },
                    { 11, 1, "1938", "Editora K", "Vidas Secas" },
                    { 12, 1, "1890", "Editora L", "O Cortiço" },
                    { 13, 1, "1964", "Editora M", "A Paixão segundo G.H." },
                    { 14, 1, "1888", "Editora N", "Os Maias" },
                    { 15, 2, "1857", "Editora O", "O Guarani" }
                });

            migrationBuilder.InsertData(
                table: "Tipo_Compra",
                columns: new[] { "CodTC", "Nome" },
                values: new object[,]
                {
                    { 1, "Balcão" },
                    { 2, "Self-service" },
                    { 3, "Internet" },
                    { 4, "Evento" }
                });

            migrationBuilder.CreateIndex(
                name: "Livro_Assunto_FKIndex1",
                table: "Livro_Assunto",
                column: "Livro_CodL");

            migrationBuilder.CreateIndex(
                name: "Livro_Assunto_FKIndex2",
                table: "Livro_Assunto",
                column: "Assunto_CodAs");

            migrationBuilder.CreateIndex(
                name: "Livro_Autor_FKIndex1",
                table: "Livro_Autor",
                column: "Livro_CodL");

            migrationBuilder.CreateIndex(
                name: "Livro_Autor_FKIndex2",
                table: "Livro_Autor",
                column: "Autor_CodAu");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Tipo_Compra_PurchaseTypeId",
                table: "Livro_Tipo_Compra",
                column: "PurchaseTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro_Assunto");

            migrationBuilder.DropTable(
                name: "Livro_Autor");

            migrationBuilder.DropTable(
                name: "Livro_Tipo_Compra");

            migrationBuilder.DropTable(
                name: "Assunto");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Tipo_Compra");
        }
    }
}
