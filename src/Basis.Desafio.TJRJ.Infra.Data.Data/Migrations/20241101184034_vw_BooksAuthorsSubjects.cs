using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Migrations
{
    /// <inheritdoc />
    public partial class vw_BooksAuthorsSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS [dbo].[vw_LivrosAutoresAssuntos]
                                 GO
                                 SET ANSI_NULLS ON
                                 GO
                                 SET QUOTED_IDENTIFIER ON
                                 GO
                                 CREATE VIEW [dbo].[vw_LivrosAutoresAssuntos] AS
                                 WITH LivroPorAno AS (
                                     SELECT l.AnoPublicacao, l.Titulo AS Livro
                                     FROM dbo.Livro l
                                 ),
                                 LivrosPorAutor AS (
                                     SELECT a.Nome AS Autor, l.Titulo AS Livro
                                     FROM dbo.Autor a
                                     LEFT JOIN dbo.Livro_Autor la ON a.CodAu = la.Autor_CodAu
                                     LEFT JOIN dbo.Livro l ON la.Livro_CodL = l.CodL
                                 ),
                                 AssuntosComLivros AS (
                                     SELECT asu.Descricao AS Assunto, l.Titulo AS Livro
                                     FROM dbo.Assunto asu
                                     JOIN dbo.Livro_Assunto la ON asu.CodAs = la.Assunto_CodAs
                                     JOIN dbo.Livro l ON la.Livro_CodL = l.CodL
                                 )
                                 
                                 SELECT 
                                     'Livros por Ano' AS Categoria,
                                     AnoPublicacao AS AnoOuAutor,
                                     Livro
                                 FROM LivroPorAno
                                 
                                 UNION ALL
                                 
                                 SELECT 
                                     'Livros por Autor' AS Categoria,
                                     Autor AS AnoOuAutor,
                                     Livro
                                 FROM LivrosPorAutor
                                 
                                 UNION ALL
                                 
                                 SELECT 
                                     'Assuntos com Livros' AS Categoria,
                                     Assunto AS AnoOuAutor,
                                     Livro
                                 FROM AssuntosComLivros;
                                 GO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS [dbo].[vw_LivrosAutoresAssuntos]");
        }
    }
}
