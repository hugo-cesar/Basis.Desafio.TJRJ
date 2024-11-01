﻿using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
