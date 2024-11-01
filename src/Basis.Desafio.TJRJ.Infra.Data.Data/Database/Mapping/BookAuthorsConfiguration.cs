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

        builder.HasData(
            new BookAuthors { BookId = 1, AuthorId = 1 }, // Dom Casmurro - Machado de Assis
            new BookAuthors { BookId = 1, AuthorId = 2 }, // Dom Casmurro - Autor adicional
            new BookAuthors { BookId = 2, AuthorId = 2 }, // Gabriela, Cravo e Canela - Jorge Amado
            new BookAuthors { BookId = 3, AuthorId = 3 }, // A Moreninha - Joaquim Manuel de Macedo
            new BookAuthors { BookId = 4, AuthorId = 1 }, // Memórias Póstumas de Brás Cubas - Machado de Assis
            new BookAuthors { BookId = 5, AuthorId = 4 }, // O Guarani - José de Alencar
            new BookAuthors { BookId = 6, AuthorId = 5 }, // O Alquimista - Paulo Coelho
            new BookAuthors { BookId = 7, AuthorId = 6 }, // Cem Anos de Solidão - Gabriel García Márquez
            new BookAuthors { BookId = 8, AuthorId = 7 }, // Os Sertões - Euclides da Cunha
            new BookAuthors { BookId = 9, AuthorId = 8 }, // A Hora da Estrela - Clarice Lispector
            new BookAuthors { BookId = 10, AuthorId = 9 }, // O Primo Basílio - Eça de Queirós
            new BookAuthors { BookId = 11, AuthorId = 10 }, // Vidas Secas - Graciliano Ramos
            new BookAuthors { BookId = 12, AuthorId = 3 }, // O Cortiço - Aluísio Azevedo
            new BookAuthors { BookId = 13, AuthorId = 10 }, // A Paixão segundo G.H. - Clarice Lispector
            new BookAuthors { BookId = 14, AuthorId = 1 }, // Os Maias - Eça de Queirós
            new BookAuthors { BookId = 15, AuthorId = 4 }  // O Guarani - José de Alencar
        );
    }
}