using Basis.Desafio.TJRJ.Domain.Features.Subjects.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Queries.Requests;

public class ListSubjectRequest : IRequest<IEnumerable<SubjectDto>> { }