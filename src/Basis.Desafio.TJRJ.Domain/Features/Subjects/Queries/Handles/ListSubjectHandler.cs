using Basis.Desafio.TJRJ.Domain.Features.Subjects.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Subjects.Queries.Requests;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Queries.Handles;

public class ListSubjectHandler : IRequestHandler<ListSubjectRequest, IEnumerable<SubjectDto>>
{
    private readonly ISubjectRepository _subjectRepository;

    public ListSubjectHandler(ISubjectRepository subjectRepository) => _subjectRepository = subjectRepository;

    public async Task<IEnumerable<SubjectDto>> Handle(ListSubjectRequest request, CancellationToken cancellationToken)
    {
        var list = await _subjectRepository.ListAsync(cancellationToken);

        if (list is null) return Enumerable.Empty<SubjectDto>();

        return list.Select(item => new SubjectDto(item));
    }
}