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

        builder.HasData(
            new Book { Id = 1, Title = "Dom Casmurro", Publisher = "Editora A", PublicationYear = "1899", Edition = 1 },
            new Book { Id = 2, Title = "Gabriela, Cravo e Canela", Publisher = "Editora B", PublicationYear = "1958", Edition = 1 },
            new Book { Id = 3, Title = "A Moreninha", Publisher = "Editora C", PublicationYear = "1844", Edition = 1 },
            new Book { Id = 4, Title = "Memórias Póstumas de Brás Cubas", Publisher = "Editora D", PublicationYear = "1881", Edition = 1 },
            new Book { Id = 5, Title = "O Guarani", Publisher = "Editora E", PublicationYear = "1857", Edition = 1 },
            new Book { Id = 6, Title = "O Alquimista", Publisher = "Editora F", PublicationYear = "1988", Edition = 1 },
            new Book { Id = 7, Title = "Cem Anos de Solidão", Publisher = "Editora G", PublicationYear = "1967", Edition = 1 },
            new Book { Id = 8, Title = "Os Sertões", Publisher = "Editora H", PublicationYear = "1902", Edition = 1 },
            new Book { Id = 9, Title = "A Hora da Estrela", Publisher = "Editora I", PublicationYear = "1977", Edition = 1 },
            new Book { Id = 10, Title = "O Primo Basílio", Publisher = "Editora J", PublicationYear = "1878", Edition = 1 },
            new Book { Id = 11, Title = "Vidas Secas", Publisher = "Editora K", PublicationYear = "1938", Edition = 1 },
            new Book { Id = 12, Title = "O Cortiço", Publisher = "Editora L", PublicationYear = "1890", Edition = 1 },
            new Book { Id = 13, Title = "A Paixão segundo G.H.", Publisher = "Editora M", PublicationYear = "1964", Edition = 1 },
            new Book { Id = 14, Title = "Os Maias", Publisher = "Editora N", PublicationYear = "1888", Edition = 1 },
            new Book { Id = 15, Title = "O Guarani", Publisher = "Editora O", PublicationYear = "1857", Edition = 2 });

    }
}