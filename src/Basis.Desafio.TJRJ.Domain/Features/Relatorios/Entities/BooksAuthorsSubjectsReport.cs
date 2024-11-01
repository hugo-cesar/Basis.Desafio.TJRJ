using System.ComponentModel.DataAnnotations.Schema;

namespace Basis.Desafio.TJRJ.Domain.Features.Relatorios.Entities;

public class BooksAuthorsSubjectsReport
{
    [Column("Categoria")]
    public string? Category { get; set; }

    [Column("AnoOuAutor")]
    public string? YearOrAuthorOrSubject { get; set; }

    [Column("Livro")]
    public string? Book { get; set; }
}