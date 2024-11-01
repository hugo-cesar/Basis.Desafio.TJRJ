using Basis.Desafio.TJRJ.Domain.Features.Books.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Requests;

public class UpdateBookRequest : IRequest<BookDto?>
{
    [JsonIgnore]
    public int Id { get; private set; }
    public string? Title { get; set; }
    public string? Publisher { get; set; }
    public int Edition { get; set; }
    public string? PublicationYear { get; set; }

    public IEnumerable<int> Authors { get; set; } = new List<int>();
    public IEnumerable<int> Subjects { get; set; } = new List<int>();
    public IEnumerable<BookPurchaseTypeDto> PurchaseTypes { get; set; } = new List<BookPurchaseTypeDto>();

    public void SetId(int id) => Id = id;
}