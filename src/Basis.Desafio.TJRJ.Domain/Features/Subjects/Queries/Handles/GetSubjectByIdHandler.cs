using Basis.Desafio.TJRJ.Domain.Features.Subjects.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Subjects.Queries.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Queries.Handles;

public class GetSubjectByIdHandler : IRequestHandler<GetSubjectByIdRequest, SubjectDto?>
{
    private readonly ISubjectRepository _subjectRepository;

    public GetSubjectByIdHandler(ISubjectRepository subjectRepository) => _subjectRepository = subjectRepository;

    public async Task<SubjectDto?> Handle(GetSubjectByIdRequest request, CancellationToken cancellationToken)
    {
        var subject = await _subjectRepository.GetByIdAsync(request.Id, cancellationToken);

        if (subject is null) return null;

        return new SubjectDto(subject);
    }
}