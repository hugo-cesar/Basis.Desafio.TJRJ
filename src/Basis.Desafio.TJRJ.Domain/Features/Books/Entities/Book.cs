using Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Requests;
using System.Collections.Generic;
using System.Linq;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Entities;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Publisher { get; set; }
    public int Edition { get; set; }
    public string? PublicationYear { get; set; }

    public ICollection<BookAuthors> BookAuthors { get; set; } = new List<BookAuthors>();
    public ICollection<BookSubjects> BookSubjects { get; set; } = new List<BookSubjects>();
    public ICollection<BookPurchaseType> BookPurchaseTypes { get; set; } = new List<BookPurchaseType>();

    internal Book Create(AddBookRequest request)
    {
        Title = request.Title;
        Publisher = request.Publisher;
        Edition = request.Edition;
        PublicationYear = request.PublicationYear;
        BookAuthors = request.Authors.Select(item => new BookAuthors { AuthorId = item }).ToList();
        BookSubjects = request.Subjects.Select(item => new BookSubjects { SubjectId = item }).ToList();
        BookPurchaseTypes = request.PurchaseTypes.Select(item => new BookPurchaseType { PurchaseTypeId = item.Id, Price = item.Price ?? 0 }).ToList();

        return this;
    }

    internal void Edit(UpdateBookRequest request)
    {
        Title = request.Title;
        Publisher = request.Publisher;
        Edition = request.Edition;
        PublicationYear = request.PublicationYear;
        BookAuthors = request.Authors.Select(item => new BookAuthors { AuthorId = item }).ToList();
        BookSubjects = request.Subjects.Select(item => new BookSubjects { SubjectId = item }).ToList();
        BookPurchaseTypes = request.PurchaseTypes.Select(item => new BookPurchaseType { PurchaseTypeId = item.Id, Price = item.Price ?? 0 }).ToList();
    }
}