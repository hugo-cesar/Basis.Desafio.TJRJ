using System.Collections.Generic;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Entities;

public class PurchaseType
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<BookPurchaseType> BookPurchaseTypes { get; set; } = new List<BookPurchaseType>();
}
