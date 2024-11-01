using Basis.Desafio.TJRJ.Domain.Features.Authors.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Authors.Queries.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Queries.Handles;

public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdRequest, AuthorDto?>
{
    private readonly IAuthorRepository _authorRepository;

    public GetAuthorByIdHandler(IAuthorRepository authorRepository) => _authorRepository = authorRepository;

    public async Task<AuthorDto?> Handle(GetAuthorByIdRequest request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetByIdAsync(request.Id, cancellationToken);

        if (author is null) return null;

        return new AuthorDto(author);
    }
}