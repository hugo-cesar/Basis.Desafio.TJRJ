using System.Collections.Generic;

namespace Basis.Desafio.TJRJ.Domain.Features.Relatorios.Dtos;

public class ReportDto
{
    public IEnumerable<ReportBookAuthorDto>? ReportBookAuthors { get; set; }
    public IEnumerable<ReportBookYearDto>? ReportBookYears { get; set; }
    public IEnumerable<ReportSubjectDto>? ReportSubjects { get; set; }
}