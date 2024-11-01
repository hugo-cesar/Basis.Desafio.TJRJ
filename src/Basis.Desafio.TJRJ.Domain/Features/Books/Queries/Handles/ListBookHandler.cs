using Basis.Desafio.TJRJ.Domain.Features.Books.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Books.Queries.Requests;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Queries.Handles;

public class ListBookHandler : IRequestHandler<ListBookRequest, IEnumerable<BookDto>>
{
    private readonly IBookRepository _bookRepository;

    public ListBookHandler(IBookRepository bookRepository) => _bookRepository = bookRepository;

    public async Task<IEnumerable<BookDto>> Handle(ListBookRequest request, CancellationToken cancellationToken)
    {
        var list = await _bookRepository.ListAsync(cancellationToken);

        if (list is null) return Enumerable.Empty<BookDto>();

        return list.Select(item => new BookDto(item));
    }
}