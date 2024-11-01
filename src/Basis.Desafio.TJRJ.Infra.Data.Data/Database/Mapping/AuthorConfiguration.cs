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
            new Author { Id = 1, Name = "Nome 1" }
            , new Author { Id = 2, Name = "Nome 2" }
            , new Author { Id = 3, Name = "Nome 3" });

        builder.HasMany(a => a.BookAuthors)
            .WithOne(ba => ba.Author)
            .HasForeignKey(ba => ba.AuthorId);
    }
}