using Basis.Desafio.TJRJ.Domain.Features.Authors;
using Basis.Desafio.TJRJ.Domain.Features.Authors.Entities;
using Basis.Desafio.TJRJ.Infra.Data.Data.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Repositories;

public class AuthorRepository(ApplicationDbContext context) : IAuthorRepository
{
    public async Task AddAsync(Author author, CancellationToken cancellationToken)
        => await context.Set<Author>().AddAsync(author, cancellationToken);

    public Task DeleteAsync(Author author, CancellationToken cancellationToken)
    {
        context.Authors.Remove(author);
        return Task.CompletedTask;
    }

    public async Task<Author?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.Set<Author>().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task<IEnumerable<Author>> ListAsync(CancellationToken cancellationToken)
        => await context.Set<Author>().ToListAsync(cancellationToken);
}