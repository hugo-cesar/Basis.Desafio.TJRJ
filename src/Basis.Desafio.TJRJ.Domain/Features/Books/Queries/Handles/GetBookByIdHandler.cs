using Basis.Desafio.TJRJ.Domain.Features.Books.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Books.Queries.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Queries.Handles;

public class GetBookByIdHandler : IRequestHandler<GetBookByIdRequest, BookDto?>
{
    private readonly IBookRepository _bookRepository;

    public GetBookByIdHandler(IBookRepository bookRepository) => _bookRepository = bookRepository;

    public async Task<BookDto?> Handle(GetBookByIdRequest request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id, cancellationToken);

        if (book is null) return null;

        return new BookDto(book);
    }
}