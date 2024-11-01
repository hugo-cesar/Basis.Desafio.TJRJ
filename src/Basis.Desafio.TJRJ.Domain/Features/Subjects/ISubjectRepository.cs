using Basis.Desafio.TJRJ.Domain.Features.Subjects.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects;

public interface ISubjectRepository
{
    Task AddAsync(Subject subject, CancellationToken cancellationToken);
    Task DeleteAsync(Subject subject, CancellationToken cancellationToken);
    Task<Subject?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Subject>> ListAsync(CancellationToken cancellationToken);
}