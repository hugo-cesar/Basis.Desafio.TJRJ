using Basis.Desafio.TJRJ.Domain.Features.Authors.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Queries.Requests;

public class ListAuthorRequest : IRequest<IEnumerable<AuthorDto>> { }