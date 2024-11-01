using Basis.Desafio.TJRJ.Domain.Features.Books.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Database.Mapping;

public class BookSubjectsConfiguration : IEntityTypeConfiguration<BookSubjects>
{
    public void Configure(EntityTypeBuilder<BookSubjects> builder)
    {
        builder.ToTable("Livro_Assunto");

        builder.HasKey(ba => new { ba.BookId, ba.SubjectId });

        builder
            .Property(ba => ba.BookId)
            .HasColumnName("Livro_CodL");

        builder
            .Property(ba => ba.SubjectId)
            .HasColumnName("Assunto_CodAs");

        builder
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookSubjects)
            .HasForeignKey(ba => ba.BookId);

        builder
            .HasOne(ba => ba.Subject)
            .WithMany(a => a.BookSubjects)
            .HasForeignKey(ba => ba.SubjectId);

        builder.HasIndex(ba => ba.BookId).HasDatabaseName("Livro_Assunto_FKIndex1");
        builder.HasIndex(ba => ba.SubjectId).HasDatabaseName("Livro_Assunto_FKIndex2");
    }
}