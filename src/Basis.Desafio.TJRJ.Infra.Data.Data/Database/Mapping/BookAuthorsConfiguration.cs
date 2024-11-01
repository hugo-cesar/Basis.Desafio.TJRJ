using Basis.Desafio.TJRJ.Domain.Features.Books.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Database.Mapping;

public class BookAuthorsConfiguration : IEntityTypeConfiguration<BookAuthors>
{
    public void Configure(EntityTypeBuilder<BookAuthors> builder)
    {
        builder.ToTable("Livro_Autor");

        builder.HasKey(ba => new { ba.BookId, ba.AuthorId });

        builder
            .Property(ba => ba.BookId)
            .HasColumnName("Livro_CodL");

        builder
            .Property(ba => ba.AuthorId)
            .HasColumnName("Autor_CodAu");

        builder
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.BookId);

        builder
            .HasOne(ba => ba.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(ba => ba.AuthorId);

        builder.HasIndex(ba => ba.BookId).HasDatabaseName("Livro_Autor_FKIndex1");
        builder.HasIndex(ba => ba.AuthorId).HasDatabaseName("Livro_Autor_FKIndex2");
    }
}