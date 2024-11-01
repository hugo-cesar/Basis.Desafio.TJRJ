using Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Handles;

public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorRequest, bool>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAuthorHandler(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteAuthorRequest request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetByIdAsync(request.Id, cancellationToken);

        if (author is null) return false;

        await _authorRepository.DeleteAsync(author!, cancellationToken);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}