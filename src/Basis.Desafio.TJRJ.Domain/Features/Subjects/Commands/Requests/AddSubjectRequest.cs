using Basis.Desafio.TJRJ.Domain.Features.Subjects.Dtos;
using MediatR;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Requests;

public class AddSubjectRequest : IRequest<SubjectDto>
{
    public string? Description { get; set; }
}