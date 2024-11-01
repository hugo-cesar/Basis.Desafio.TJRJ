using MediatR;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Requests;

public class DeleteBookRequest : IRequest<bool>
{
    public DeleteBookRequest(int id) => Id = id;
    public int Id { get; }
}