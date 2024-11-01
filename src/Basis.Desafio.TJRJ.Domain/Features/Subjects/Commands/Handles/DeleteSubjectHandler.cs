using Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Handles;

public class DeleteSubjectHandler : IRequestHandler<DeleteSubjectRequest, bool>
{
    private readonly ISubjectRepository _subjectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSubjectHandler(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork)
    {
        _subjectRepository = subjectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteSubjectRequest request, CancellationToken cancellationToken)
    {
        var subject = await _subjectRepository.GetByIdAsync(request.Id, cancellationToken);

        if (subject is null) return false;

        await _subjectRepository.DeleteAsync(subject!, cancellationToken);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}