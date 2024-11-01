using Basis.Desafio.TJRJ.Domain.Features.Subjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Database.Mapping;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("Assunto");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).HasColumnName("CodAs").UseIdentityColumn();
        builder.Property(item => item.Description).HasColumnName("Descricao").HasColumnType("varchar(20)").IsRequired();
    }
}