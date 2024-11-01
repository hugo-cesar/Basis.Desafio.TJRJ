using Basis.Desafio.TJRJ.Domain.Features.Authors.Entities;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Entities;

public class BookAuthors
{
    public int BookId { get; set; }
    public Book? Book { get; set; }

    public int AuthorId { get; set; }
    public Author? Author { get; set; }
}