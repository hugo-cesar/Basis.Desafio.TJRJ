using Basis.Desafio.TJRJ.Domain.Features.Subjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Database.Mapping;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("Assunto");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).HasColumnName("CodAs").UseIdentityColumn();
        builder.Property(item => item.Description).HasColumnName("Descricao").HasColumnType("varchar(20)").IsRequired();

        builder.HasData(
            new Subject { Id = 1, Description = "Ficção" },
            new Subject { Id = 2, Description = "Romance" },
            new Subject { Id = 3, Description = "Aventura" },
            new Subject { Id = 4, Description = "Fantasia" },
            new Subject { Id = 5, Description = "Mistério" },
            new Subject { Id = 6, Description = "Terror" },
            new Subject { Id = 7, Description = "Drama" },
            new Subject { Id = 8, Description = "Comédia" },
            new Subject { Id = 9, Description = "Biografia" },
            new Subject { Id = 10, Description = "História" },
            new Subject { Id = 11, Description = "Poesia" },
            new Subject { Id = 12, Description = "Crônica" },
            new Subject { Id = 13, Description = "Literatura Infantil" },
            new Subject { Id = 14, Description = "Educação" },
            new Subject { Id = 15, Description = "Autoajuda" },
            new Subject { Id = 16, Description = "Ciência" },
            new Subject { Id = 17, Description = "Filosofia" },
            new Subject { Id = 18, Description = "Sociedade" },
            new Subject { Id = 19, Description = "Cultura" },
            new Subject { Id = 20, Description = "Religião" });
    }
}