using MediatR;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Requests;

public class DeleteSubjectRequest : IRequest<bool>
{
    public DeleteSubjectRequest(int id) => Id = id;
    public int Id { get; }
}