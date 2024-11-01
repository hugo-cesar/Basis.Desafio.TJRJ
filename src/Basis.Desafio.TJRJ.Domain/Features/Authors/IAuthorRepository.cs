using Basis.Desafio.TJRJ.Domain.Features.Authors.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors;

public interface IAuthorRepository
{
    Task AddAsync(Author author, CancellationToken cancellationToken);
    Task DeleteAsync(Author author, CancellationToken cancellationToken);
    Task<Author?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Author>> ListAsync(CancellationToken cancellationToken);
}