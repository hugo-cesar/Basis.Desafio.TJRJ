using Basis.Desafio.TJRJ.Domain.Features.Authors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Database.Mapping;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Autor");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).HasColumnName("CodAu").UseIdentityColumn();
        builder.Property(item => item.Name).HasColumnName("Nome").HasColumnType("varchar(40)").IsRequired();

        builder.HasData(
          new Author { Id = 1, Name = "Machado de Assis" },
          new Author { Id = 2, Name = "Jorge Amado" },
          new Author { Id = 3, Name = "Clarice Lispector" },
          new Author { Id = 4, Name = "Carlos Drummond de Andrade" },
          new Author { Id = 5, Name = "José Saramago" },
          new Author { Id = 6, Name = "Raquel de Queiroz" },
          new Author { Id = 7, Name = "Guimarães Rosa" },
          new Author { Id = 8, Name = "Érico Veríssimo" },
          new Author { Id = 9, Name = "Lygia Fagundes Telles" },
          new Author { Id = 10, Name = "Adélia Prado" });

        builder.HasMany(a => a.BookAuthors)
            .WithOne(ba => ba.Author)
            .HasForeignKey(ba => ba.AuthorId);
    }
}