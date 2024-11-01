namespace Basis.Desafio.TJRJ.Domain.Features.Books.Entities;

public class BookPurchaseType
{
    public int BookId { get; set; }
    public Book? Book { get; set; }

    public int PurchaseTypeId { get; set; }
    public PurchaseType? PurchaseType { get; set; }

    public decimal Price { get; set; }
}