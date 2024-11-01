using MediatR;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Requests;

public class DeleteAuthorRequest : IRequest<bool>
{
    public DeleteAuthorRequest(int id) => Id = id;
    public int Id { get; }
}