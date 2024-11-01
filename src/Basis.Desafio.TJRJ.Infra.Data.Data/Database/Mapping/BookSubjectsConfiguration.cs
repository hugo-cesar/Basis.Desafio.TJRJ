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

        builder.HasData(
            new BookSubjects { BookId = 1, SubjectId = 1 }, // Dom Casmurro - Ficção
            new BookSubjects { BookId = 1, SubjectId = 7 }, // Dom Casmurro - Drama
            new BookSubjects { BookId = 2, SubjectId = 1 }, // Gabriela, Cravo e Canela - Ficção
            new BookSubjects { BookId = 2, SubjectId = 10 }, // Gabriela, Cravo e Canela - História
            new BookSubjects { BookId = 3, SubjectId = 1 }, // A Moreninha - Ficção
            new BookSubjects { BookId = 4, SubjectId = 1 }, // Memórias Póstumas de Brás Cubas - Ficção
            new BookSubjects { BookId = 4, SubjectId = 7 }, // Memórias Póstumas de Brás Cubas - Drama
            new BookSubjects { BookId = 5, SubjectId = 2 }, // O Guarani - Romance
            new BookSubjects { BookId = 6, SubjectId = 1 }, // O Alquimista - Ficção
            new BookSubjects { BookId = 6, SubjectId = 16 }, // O Alquimista - Filosofia
            new BookSubjects { BookId = 7, SubjectId = 1 }, // Cem Anos de Solidão - Ficção
            new BookSubjects { BookId = 8, SubjectId = 10 }, // Os Sertões - História
            new BookSubjects { BookId = 9, SubjectId = 7 }, // A Hora da Estrela - Drama
            new BookSubjects { BookId = 10, SubjectId = 1 }, // O Primo Basílio - Ficção
            new BookSubjects { BookId = 11, SubjectId = 7 }, // Vidas Secas - Drama
            new BookSubjects { BookId = 12, SubjectId = 1 }, // O Cortiço - Ficção
            new BookSubjects { BookId = 13, SubjectId = 1 }, // A Paixão segundo G.H. - Ficção
            new BookSubjects { BookId = 14, SubjectId = 1 }, // Os Maias - Ficção
            new BookSubjects { BookId = 14, SubjectId = 8 }, // Os Maias - Sociedade
            new BookSubjects { BookId = 15, SubjectId = 1 }  // O Guarani - Ficção
        );
    }
}