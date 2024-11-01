using Basis.Desafio.TJRJ.Domain.Features.Books.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Database.Mapping;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Livro");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).HasColumnName("CodL").UseIdentityColumn();
        builder.Property(item => item.Title).HasColumnName("Titulo").HasColumnType("varchar(40)").IsRequired();
        builder.Property(item => item.Publisher).HasColumnName("Editora").HasColumnType("varchar(40)").IsRequired();
        builder.Property(item => item.PublicationYear).HasColumnName("AnoPublicacao").HasColumnType("varchar(4)").IsRequired();
        builder.Property(item => item.Edition).HasColumnName("Edicao").HasColumnType("int").IsRequired();

        builder
            .HasMany(b => b.BookAuthors)
            .WithOne(ba => ba.Book)
            .HasForeignKey(ba => ba.BookId);
    }
}