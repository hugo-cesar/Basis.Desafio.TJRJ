using Basis.Desafio.TJRJ.Domain.Features.Authors.Dtos;
using MediatR;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Requests;

public class AddAuthorRequest : IRequest<AuthorDto>
{
    public string? Name { get; set; }
}