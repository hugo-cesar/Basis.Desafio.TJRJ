using Basis.Desafio.TJRJ.Domain.Features.Subjects.Dtos;
using MediatR;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Queries.Requests;

public class GetSubjectByIdRequest : IRequest<SubjectDto?>
{
    public GetSubjectByIdRequest(int id) => Id = id;
    public int Id { get; }
}