using Basis.Desafio.TJRJ.Domain.Features.Books;
using Basis.Desafio.TJRJ.Domain.Features.Books.Entities;
using Basis.Desafio.TJRJ.Domain.Features.Relatorios.Entities;
using Basis.Desafio.TJRJ.Infra.Data.Data.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Repositories;

public class BookRepository(ApplicationDbContext context) : IBookRepository
{
    public async Task AddAsync(Book book, CancellationToken cancellationToken)
        => await context.Set<Book>().AddAsync(book, cancellationToken);

    public Task DeleteAsync(Book book, CancellationToken cancellationToken)
    {
        context.Books.Remove(book);
        return Task.CompletedTask;
    }

    public async Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.Set<Book>()
                        .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
                        .Include(b => b.BookSubjects).ThenInclude(bs => bs.Subject)
                        .Include(b => b.BookPurchaseTypes).ThenInclude(bs => bs.PurchaseType)
                        .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task<IEnumerable<Book>> ListAsync(CancellationToken cancellationToken)
        => await context.Set<Book>()
                        .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
                        .Include(b => b.BookSubjects).ThenInclude(bs => bs.Subject)
                        .Include(b => b.BookPurchaseTypes).ThenInclude(bs => bs.PurchaseType)
                        .ToListAsync(cancellationToken);

    public async Task<IEnumerable<PurchaseType>> ListPurchaseTypeAsync(CancellationToken cancellationToken)
        => await context.Set<PurchaseType>().ToListAsync(cancellationToken);

    public async Task<IEnumerable<BooksAuthorsSubjectsReport>> GetReportAsync(CancellationToken cancellationToken)
      => await context.Set<BooksAuthorsSubjectsReport>()
                      .OrderBy(r => r.Category)
                      .ThenBy(r => r.YearOrAuthorOrSubject)
                      .ToListAsync(cancellationToken);
}