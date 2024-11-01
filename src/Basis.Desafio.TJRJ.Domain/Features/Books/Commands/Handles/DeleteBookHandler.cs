using Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Handles;

public class DeleteBookHandler : IRequestHandler<DeleteBookRequest, bool>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id, cancellationToken);
        if (book is null) return false;

        await _bookRepository.DeleteAsync(book!, cancellationToken);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}