using Basis.Desafio.TJRJ.Domain.Features.Subjects.Entities;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Entities;

public class BookSubjects
{
    public int BookId { get; set; }
    public Book? Book { get; set; }

    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }
}