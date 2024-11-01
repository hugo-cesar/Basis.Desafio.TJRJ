using Basis.Desafio.TJRJ.Domain.Features.Authors.Dtos;
using MediatR;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Queries.Requests;

public class GetAuthorByIdRequest : IRequest<AuthorDto?>
{
    public GetAuthorByIdRequest(int id) => Id = id;
    public int Id { get; }
}
