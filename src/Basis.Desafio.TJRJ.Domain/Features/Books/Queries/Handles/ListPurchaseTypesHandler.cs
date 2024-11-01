using Basis.Desafio.TJRJ.Domain.Features.Books.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Books.Queries.Requests;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Queries.Handles;

public class ListPurchaseTypesHandler : IRequestHandler<ListPurchaseTypesRequest, IEnumerable<BookPurchaseTypeDto>>
{
    private readonly IBookRepository _bookRepository;

    public ListPurchaseTypesHandler(IBookRepository bookRepository) => _bookRepository = bookRepository;

    public async Task<IEnumerable<BookPurchaseTypeDto>> Handle(ListPurchaseTypesRequest request, CancellationToken cancellationToken)
    {
        var list = await _bookRepository.ListPurchaseTypeAsync(cancellationToken);

        if (list is null) return Enumerable.Empty<BookPurchaseTypeDto>();

        return list.Select(item => new BookPurchaseTypeDto { Id = item.Id, Name = item.Name });
    }
}