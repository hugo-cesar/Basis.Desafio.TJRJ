using Basis.Desafio.TJRJ.Domain.Features.Relatorios.Dtos;
using MediatR;

namespace Basis.Desafio.TJRJ.Domain.Features.Relatorios.Requests;

public record GetReportRequest : IRequest<ReportDto> { }