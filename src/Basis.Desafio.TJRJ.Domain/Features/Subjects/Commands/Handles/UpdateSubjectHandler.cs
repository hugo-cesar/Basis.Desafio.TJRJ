using Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Subjects.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Handles;

public class UpdateSubjectHandler : IRequestHandler<UpdateSubjectRequest, SubjectDto?>
{
    private readonly ISubjectRepository _subjectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSubjectHandler(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork)
    {
        _subjectRepository = subjectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<SubjectDto?> Handle(UpdateSubjectRequest request, CancellationToken cancellationToken)
    {
        var subject = await _subjectRepository.GetByIdAsync(request.Id, cancellationToken);

        if (subject is null) return null;

        subject.Description = request.Description;
        await _unitOfWork.SaveChangesAsync();

        return new SubjectDto(subject);
    }
}