using Basis.Desafio.TJRJ.Domain.Features.Books.Entities;
using System.Collections.Generic;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Entities;

public class Author
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<BookAuthors> BookAuthors { get; set; } = new List<BookAuthors>();
}