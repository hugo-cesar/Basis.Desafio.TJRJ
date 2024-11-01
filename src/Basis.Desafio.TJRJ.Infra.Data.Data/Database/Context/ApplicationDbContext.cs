using Basis.Desafio.TJRJ.Domain;
using Basis.Desafio.TJRJ.Domain.Features.Authors.Entities;
using Basis.Desafio.TJRJ.Domain.Features.Books.Entities;
using Basis.Desafio.TJRJ.Domain.Features.Relatorios.Entities;
using Basis.Desafio.TJRJ.Domain.Features.Subjects.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Database.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<BookAuthors> BookAuthors { get; set; }
    public DbSet<BookSubjects> BookSubjects { get; set; }
    public DbSet<PurchaseType> PurchaseTypes { get; set; }
    public DbSet<BookPurchaseType> BookPurchaseTypes { get; set; }
    public DbSet<BooksAuthorsSubjectsReport> BooksAuthorsSubjectsReports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}