using Basis.Desafio.TJRJ.Domain.Features.Books.Dtos;
using MediatR;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Queries.Requests;

public class GetBookByIdRequest : IRequest<BookDto?>
{
    public GetBookByIdRequest(int id) => Id = id;
    public int Id { get; }
}