using Basis.Desafio.TJRJ.Domain.Features.Authors.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Books.Entities;
using Basis.Desafio.TJRJ.Domain.Features.Subjects.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Dtos;

public class BookDto
{
    public BookDto(Book? book)
    {
        if (book is not null)
        {
            Id = book.Id;
            Title = book.Title;
            Publisher = book.Publisher;
            Edition = book.Edition;
            PublicationYear = book.PublicationYear;

            Authors = book.BookAuthors.Select(item => new AuthorDto(item.Author));
            Subjects = book.BookSubjects.Select(item => new SubjectDto(item.Subject));
            PurchaseTypes = book.BookPurchaseTypes.Select(item => new BookPurchaseTypeDto { Id = item.PurchaseTypeId, Name = item.PurchaseType?.Name, Price = item.Price});
        }
    }

    public int Id { get; }
    public string? Title { get; }
    public string? Publisher { get; }
    public int Edition { get; }
    public string? PublicationYear { get; }

    public IEnumerable<AuthorDto> Authors { get; set; } = new List<AuthorDto>();
    public IEnumerable<SubjectDto> Subjects { get; set; } = new List<SubjectDto>();
    public IEnumerable<BookPurchaseTypeDto> PurchaseTypes { get; set; } = new List<BookPurchaseTypeDto>();
}