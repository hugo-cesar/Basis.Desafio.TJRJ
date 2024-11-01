using Basis.Desafio.TJRJ.Domain.Features.Books.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Database.Mapping;

public class PurchaseTypeConfiguration : IEntityTypeConfiguration<PurchaseType>
{
    public void Configure(EntityTypeBuilder<PurchaseType> builder)
    {
        builder.ToTable("Tipo_Compra");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).HasColumnName("CodTC").UseIdentityColumn();
        builder.Property(item => item.Name).HasColumnName("Nome").HasColumnType("varchar(20)").IsRequired();

        builder.HasData(
            new PurchaseType { Id = 1, Name = "Balcão" }
            , new PurchaseType { Id = 2, Name = "Self-service" }
            , new PurchaseType { Id = 3, Name = "Internet" }
            , new PurchaseType { Id = 4, Name = "Evento" });
    }
}