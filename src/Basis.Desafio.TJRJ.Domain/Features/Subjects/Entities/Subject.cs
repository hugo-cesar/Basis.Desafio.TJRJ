using System.Collections.Generic;
using Basis.Desafio.TJRJ.Domain.Features.Books.Entities;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Entities;

public class Subject
{
    public int Id { get; set; }
    public string? Description { get; set; }

    public ICollection<BookSubjects> BookSubjects { get; set; } = new List<BookSubjects>();
}