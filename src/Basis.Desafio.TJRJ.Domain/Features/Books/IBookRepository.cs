using Basis.Desafio.TJRJ.Domain.Features.Books.Entities;
using Basis.Desafio.TJRJ.Domain.Features.Relatorios.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Books;

public interface IBookRepository
{
    Task AddAsync(Book book, CancellationToken cancellationToken);
    Task DeleteAsync(Book book, CancellationToken cancellationToken);
    Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Book>> ListAsync(CancellationToken cancellationToken);
    Task<IEnumerable<PurchaseType>> ListPurchaseTypeAsync(CancellationToken cancellationToken);
    Task<IEnumerable<BooksAuthorsSubjectsReport>> GetReportAsync(CancellationToken cancellationToken);
}