using Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Books.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Books.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Handles;

public class AddBookHandler : IRequestHandler<AddBookRequest, BookDto>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddBookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<BookDto> Handle(AddBookRequest request, CancellationToken cancellationToken)
    {
        var book = new Book().Create(request);

        await _bookRepository.AddAsync(book, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new BookDto(book);
    }
}