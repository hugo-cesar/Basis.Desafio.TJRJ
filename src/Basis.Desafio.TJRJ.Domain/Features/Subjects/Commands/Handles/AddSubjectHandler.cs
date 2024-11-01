using Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Subjects.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Subjects.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Handles;

public class AddSubjectHandler : IRequestHandler<AddSubjectRequest, SubjectDto>
{
    private readonly ISubjectRepository _subjectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddSubjectHandler(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork)
    {
        _subjectRepository = subjectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<SubjectDto> Handle(AddSubjectRequest request, CancellationToken cancellationToken)
    {
        var subject = new Subject { Description = request.Description };

        await _subjectRepository.AddAsync(subject, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new SubjectDto(subject);
    }
}