using System.Collections.Generic;

namespace Basis.Desafio.TJRJ.Domain.Features.Relatorios.Dtos;

public class ReportSubjectDto
{
    public string? Subject { get; set; }
    public IEnumerable<string>? Books { get; set; }
}