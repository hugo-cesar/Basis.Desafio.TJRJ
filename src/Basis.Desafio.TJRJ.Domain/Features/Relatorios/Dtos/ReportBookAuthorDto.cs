using System.Collections.Generic;

namespace Basis.Desafio.TJRJ.Domain.Features.Relatorios.Dtos;

public class ReportBookAuthorDto
{
    public string? Author { get; set; }
    public IEnumerable<string>? Books { get; set; }
}