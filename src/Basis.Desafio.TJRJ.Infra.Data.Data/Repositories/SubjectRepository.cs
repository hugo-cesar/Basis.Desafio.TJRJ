using Basis.Desafio.TJRJ.Domain.Features.Subjects;
using Basis.Desafio.TJRJ.Domain.Features.Subjects.Entities;
using Basis.Desafio.TJRJ.Infra.Data.Data.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Repositories;

public class SubjectRepository(ApplicationDbContext context) : ISubjectRepository
{
    public async Task AddAsync(Subject subject, CancellationToken cancellationToken)
        => await context.Set<Subject>().AddAsync(subject, cancellationToken);

    public Task DeleteAsync(Subject subject, CancellationToken cancellationToken)
    {
        context.Subjects.Remove(subject);
        return Task.CompletedTask;
    }

    public async Task<Subject?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.Set<Subject>().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task<IEnumerable<Subject>> ListAsync(CancellationToken cancellationToken)
        => await context.Set<Subject>().ToListAsync(cancellationToken);
}