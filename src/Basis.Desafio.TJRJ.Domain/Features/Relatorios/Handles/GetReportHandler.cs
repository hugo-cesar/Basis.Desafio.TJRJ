using Basis.Desafio.TJRJ.Domain.Features.Books;
using Basis.Desafio.TJRJ.Domain.Features.Relatorios.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Relatorios.Entities;
using Basis.Desafio.TJRJ.Domain.Features.Relatorios.Requests;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.Desafio.TJRJ.Domain.Features.Relatorios.Handles;

public class GetReportHandler : IRequestHandler<GetReportRequest, ReportDto>
{
    private readonly IBookRepository _bookRepository;

    public GetReportHandler(IBookRepository bookRepository) => _bookRepository = bookRepository;

    public async Task<ReportDto> Handle(GetReportRequest request, CancellationToken cancellationToken)
    {
        var result = await _bookRepository.GetReportAsync(cancellationToken);

        return TransformReports(result);
    }

    public ReportDto TransformReports(IEnumerable<BooksAuthorsSubjectsReport> reports)
    {
        var reportDto = new ReportDto
        {
            ReportBookAuthors = reports
                .Where(r => r.Category.Equals("Livros por Autor", System.StringComparison.InvariantCultureIgnoreCase))
                .GroupBy(r => r.YearOrAuthorOrSubject)
                .Select(g => new ReportBookAuthorDto
                {
                    Author = g.Key,
                    Books = g.Select(r => r.Book).Distinct()
                }),

            ReportBookYears = reports
                .Where(r => r.Category.Equals("Livros por Ano", System.StringComparison.InvariantCultureIgnoreCase))
                .GroupBy(r => r.YearOrAuthorOrSubject)
                .Select(g => new ReportBookYearDto
                {
                    Year = g.Key,
                    Books = g.Select(r => r.Book).Distinct()
                }),

            ReportSubjects = reports
                .Where(r => r.Category.Equals("Assuntos com Livros", System.StringComparison.InvariantCultureIgnoreCase))
                .GroupBy(r => r.YearOrAuthorOrSubject)
                .Select(g => new ReportSubjectDto
                {
                    Subject = g.Key,
                    Books = g.Select(r => r.Book).Distinct()
                })
        };

        return reportDto;
    }
}