using Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Books.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Handles;

internal class UpdateBookHandler : IRequestHandler<UpdateBookRequest, BookDto?>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<BookDto?> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id, cancellationToken);

        if (book is null) return null;

        book.Edit(request);

        await _unitOfWork.SaveChangesAsync();

        return new BookDto(book);
    }
}