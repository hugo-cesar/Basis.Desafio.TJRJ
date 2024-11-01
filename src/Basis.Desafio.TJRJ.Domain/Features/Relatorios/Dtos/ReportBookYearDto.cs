using System.Collections.Generic;

namespace Basis.Desafio.TJRJ.Domain.Features.Relatorios.Dtos;

public class ReportBookYearDto
{
    public string? Year { get; set; }
    public IEnumerable<string>? Books { get; set; }
}