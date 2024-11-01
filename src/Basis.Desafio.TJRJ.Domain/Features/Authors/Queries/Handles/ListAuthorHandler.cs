using Basis.Desafio.TJRJ.Domain.Features.Authors.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Authors.Queries.Requests;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Queries.Handles;

public class ListAuthorHandler : IRequestHandler<ListAuthorRequest, IEnumerable<AuthorDto>>
{
    private readonly IAuthorRepository _authorRepository;

    public ListAuthorHandler(IAuthorRepository authorRepository) => _authorRepository = authorRepository;

    public async Task<IEnumerable<AuthorDto>> Handle(ListAuthorRequest request, CancellationToken cancellationToken)
    {
        var list = await _authorRepository.ListAsync(cancellationToken);

        if (list is null) return Enumerable.Empty<AuthorDto>();

        return list.Select(author => new AuthorDto(author));
    }
}