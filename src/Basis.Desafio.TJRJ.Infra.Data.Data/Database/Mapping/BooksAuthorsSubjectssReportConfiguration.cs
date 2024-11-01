using Basis.Desafio.TJRJ.Domain.Features.Relatorios.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Database.Mapping;

public class BooksAuthorsSubjectssReportConfiguration : IEntityTypeConfiguration<BooksAuthorsSubjectsReport>
{
    public void Configure(EntityTypeBuilder<BooksAuthorsSubjectsReport> builder)
    {
        builder.HasNoKey();
        builder.ToView("vw_LivrosAutoresAssuntos");
    }
}