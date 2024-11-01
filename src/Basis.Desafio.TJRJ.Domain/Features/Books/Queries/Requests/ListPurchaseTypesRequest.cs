using Basis.Desafio.TJRJ.Domain.Features.Books.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Queries.Requests;

public class ListPurchaseTypesRequest : IRequest<IEnumerable<BookPurchaseTypeDto>> { }