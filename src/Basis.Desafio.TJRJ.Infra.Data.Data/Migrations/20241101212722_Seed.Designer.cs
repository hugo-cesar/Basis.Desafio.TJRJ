﻿// <auto-generated />
using Basis.Desafio.TJRJ.Infra.Data.Data.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241101212722_Seed")]
    partial class Seed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Authors.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodAu");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Autor", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Machado de Assis"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jorge Amado"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Clarice Lispector"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Carlos Drummond de Andrade"
                        },
                        new
                        {
                            Id = 5,
                            Name = "José Saramago"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Raquel de Queiroz"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Guimarães Rosa"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Érico Veríssimo"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Lygia Fagundes Telles"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Adélia Prado"
                        });
                });

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Books.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodL");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Edition")
                        .HasColumnType("int")
                        .HasColumnName("Edicao");

                    b.Property<string>("PublicationYear")
                        .IsRequired()
                        .HasColumnType("varchar(4)")
                        .HasColumnName("AnoPublicacao");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Editora");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.ToTable("Livro", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Edition = 1,
                            PublicationYear = "1899",
                            Publisher = "Editora A",
                            Title = "Dom Casmurro"
                        },
                        new
                        {
                            Id = 2,
                            Edition = 1,
                            PublicationYear = "1958",
                            Publisher = "Editora B",
                            Title = "Gabriela, Cravo e Canela"
                        },
                        new
                        {
                            Id = 3,
                            Edition = 1,
                            PublicationYear = "1844",
                            Publisher = "Editora C",
                            Title = "A Moreninha"
                        },
                        new
                        {
                            Id = 4,
                            Edition = 1,
                            PublicationYear = "1881",
                            Publisher = "Editora D",
                            Title = "Memórias Póstumas de Brás Cubas"
                        },
                        new
                        {
                            Id = 5,
                            Edition = 1,
                            PublicationYear = "1857",
                            Publisher = "Editora E",
                            Title = "O Guarani"
                        },
                        new
                        {
                            Id = 6,
                            Edition = 1,
                            PublicationYear = "1988",
                            Publisher = "Editora F",
                            Title = "O Alquimista"
                        },
                        new
                        {
                            Id = 7,
                            Edition = 1,
                            PublicationYear = "1967",
                            Publisher = "Editora G",
                            Title = "Cem Anos de Solidão"
                        },
                        new
                        {
                            Id = 8,
                            Edition = 1,
                            PublicationYear = "1902",
                            Publisher = "Editora H",
                            Title = "Os Sertões"
                        },
                        new
                        {
                            Id = 9,
                            Edition = 1,
                            PublicationYear = "1977",
                            Publisher = "Editora I",
                            Title = "A Hora da Estrela"
                        },
                        new
                        {
                            Id = 10,
                            Edition = 1,
                            PublicationYear = "1878",
                            Publisher = "Editora J",
                            Title = "O Primo Basílio"
                        },
                        new
                        {
                            Id = 11,
                            Edition = 1,
                            PublicationYear = "1938",
                            Publisher = "Editora K",
                            Title = "Vidas Secas"
                        },
                        new
                        {
                            Id = 12,
                            Edition = 1,
                            PublicationYear = "1890",
                            Publisher = "Editora L",
                            Title = "O Cortiço"
                        },
                        new
                        {
                            Id = 13,
                            Edition = 1,
                            PublicationYear = "1964",
                            Publisher = "Editora M",
                            Title = "A Paixão segundo G.H."
                        },
                        new
                        {
                            Id = 14,
                            Edition = 1,
                            PublicationYear = "1888",
                            Publisher = "Editora N",
                            Title = "Os Maias"
                        },
                        new
                        {
                            Id = 15,
                            Edition = 2,
                            PublicationYear = "1857",
                            Publisher = "Editora O",
                            Title = "O Guarani"
                        });
                });

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Books.Entities.BookAuthors", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("Livro_CodL");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("Autor_CodAu");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId")
                        .HasDatabaseName("Livro_Autor_FKIndex2");

                    b.HasIndex("BookId")
                        .HasDatabaseName("Livro_Autor_FKIndex1");

                    b.ToTable("Livro_Autor", (string)null);

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1
                        },
                        new
                        {
                            BookId = 1,
                            AuthorId = 2
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 2
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 3
                        },
                        new
                        {
                            BookId = 4,
                            AuthorId = 1
                        },
                        new
                        {
                            BookId = 5,
                            AuthorId = 4
                        },
                        new
                        {
                            BookId = 6,
                            AuthorId = 5
                        },
                        new
                        {
                            BookId = 7,
                            AuthorId = 6
                        },
                        new
                        {
                            BookId = 8,
                            AuthorId = 7
                        },
                        new
                        {
                            BookId = 9,
                            AuthorId = 8
                        },
                        new
                        {
                            BookId = 10,
                            AuthorId = 9
                        },
                        new
                        {
                            BookId = 11,
                            AuthorId = 10
                        },
                        new
                        {
                            BookId = 12,
                            AuthorId = 3
                        },
                        new
                        {
                            BookId = 13,
                            AuthorId = 10
                        },
                        new
                        {
                            BookId = 14,
                            AuthorId = 1
                        },
                        new
                        {
                            BookId = 15,
                            AuthorId = 4
                        });
                });

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Books.Entities.BookPurchaseType", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Valor");

                    b.HasKey("BookId", "PurchaseTypeId");

                    b.HasIndex("PurchaseTypeId");

                    b.ToTable("Livro_Tipo_Compra", (string)null);
                });

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Books.Entities.BookSubjects", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("Livro_CodL");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnName("Assunto_CodAs");

                    b.HasKey("BookId", "SubjectId");

                    b.HasIndex("BookId")
                        .HasDatabaseName("Livro_Assunto_FKIndex1");

                    b.HasIndex("SubjectId")
                        .HasDatabaseName("Livro_Assunto_FKIndex2");

                    b.ToTable("Livro_Assunto", (string)null);

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            SubjectId = 1
                        },
                        new
                        {
                            BookId = 1,
                            SubjectId = 7
                        },
                        new
                        {
                            BookId = 2,
                            SubjectId = 1
                        },
                        new
                        {
                            BookId = 2,
                            SubjectId = 10
                        },
                        new
                        {
                            BookId = 3,
                            SubjectId = 1
                        },
                        new
                        {
                            BookId = 4,
                            SubjectId = 1
                        },
                        new
                        {
                            BookId = 4,
                            SubjectId = 7
                        },
                        new
                        {
                            BookId = 5,
                            SubjectId = 2
                        },
                        new
                        {
                            BookId = 6,
                            SubjectId = 1
                        },
                        new
                        {
                            BookId = 6,
                            SubjectId = 16
                        },
                        new
                        {
                            BookId = 7,
                            SubjectId = 1
                        },
                        new
                        {
                            BookId = 8,
                            SubjectId = 10
                        },
                        new
                        {
                            BookId = 9,
                            SubjectId = 7
                        },
                        new
                        {
                            BookId = 10,
                            SubjectId = 1
                        },
                        new
                        {
                            BookId = 11,
                            SubjectId = 7
                        },
                        new
                        {
                            BookId = 12,
                            SubjectId = 1
                        },
                        new
                        {
                            BookId = 13,
                            SubjectId = 1
                        },
                        new
                        {
                            BookId = 14,
                            SubjectId = 1
                        },
                        new
                        {
                            BookId = 14,
                            SubjectId = 8
                        },
                        new
                        {
                            BookId = 15,
                            SubjectId = 1
                        });
                });

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Books.Entities.PurchaseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodTC");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Tipo_Compra", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Balcão"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Self-service"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Internet"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Evento"
                        });
                });

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Relatorios.Entities.BooksAuthorsSubjectsReport", b =>
                {
                    b.Property<string>("Book")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Livro");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Categoria");

                    b.Property<string>("YearOrAuthorOrSubject")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AnoOuAutor");

                    b.ToTable((string)null);

                    b.ToView("vw_LivrosAutoresAssuntos", (string)null);
                });

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Subjects.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodAs");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Assunto", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Ficção"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Romance"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Aventura"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Fantasia"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Mistério"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Terror"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Drama"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Comédia"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Biografia"
                        },
                        new
                        {
                            Id = 10,
                            Description = "História"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Poesia"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Crônica"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Literatura Infantil"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Educação"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Autoajuda"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Ciência"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Filosofia"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Sociedade"
                        },
                        new
                        {
                            Id = 19,
                            Description = "Cultura"
                        },
                        new
                        {
                            Id = 20,
                            Description = "Religião"
                        });
                });

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Books.Entities.BookAuthors", b =>
                {
                    b.HasOne("Basis.Desafio.TJRJ.Domain.Features.Authors.Entities.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Basis.Desafio.TJRJ.Domain.Features.Books.Entities.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Books.Entities.BookPurchaseType", b =>
                {
                    b.HasOne("Basis.Desafio.TJRJ.Domain.Features.Books.Entities.Book", "Book")
                        .WithMany("BookPurchaseTypes")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Basis.Desafio.TJRJ.Domain.Features.Books.Entities.PurchaseType", "PurchaseType")
                        .WithMany("BookPurchaseTypes")
                        .HasForeignKey("PurchaseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("PurchaseType");
                });

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Books.Entities.BookSubjects", b =>
                {
                    b.HasOne("Basis.Desafio.TJRJ.Domain.Features.Books.Entities.Book", "Book")
                        .WithMany("BookSubjects")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Basis.Desafio.TJRJ.Domain.Features.Subjects.Entities.Subject", "Subject")
                        .WithMany("BookSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Authors.Entities.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Books.Entities.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("BookPurchaseTypes");

                    b.Navigation("BookSubjects");
                });

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Books.Entities.PurchaseType", b =>
                {
                    b.Navigation("BookPurchaseTypes");
                });

            modelBuilder.Entity("Basis.Desafio.TJRJ.Domain.Features.Subjects.Entities.Subject", b =>
                {
                    b.Navigation("BookSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}