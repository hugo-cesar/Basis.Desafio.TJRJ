using Basis.Desafio.TJRJ.Domain.Features.Books.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Requests;

public class AddBookRequest : IRequest<BookDto>
{
    public string? Title { get; set; }
    public string? Publisher { get; set; }
    public int Edition { get; set; }
    public string? PublicationYear { get; set; }

    public IEnumerable<int> Authors { get; set; } = new List<int>();
    public IEnumerable<int> Subjects { get; set; } = new List<int>();
    public IEnumerable<BookPurchaseTypeDto> PurchaseTypes { get; set; } = new List<BookPurchaseTypeDto>();
}