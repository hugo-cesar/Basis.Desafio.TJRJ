using Basis.Desafio.TJRJ.Domain.Features.Books.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.Desafio.TJRJ.Infra.Data.Data.Database.Mapping;

public class BookPurchaseTypeConfiguration : IEntityTypeConfiguration<BookPurchaseType>
{
    public void Configure(EntityTypeBuilder<BookPurchaseType> builder)
    {
        builder.ToTable("Livro_Tipo_Compra");

        builder.HasKey(ba => new { ba.BookId, ba.PurchaseTypeId });

        builder.Property(bpt => bpt.Price).HasColumnName("Valor").HasColumnType("decimal(18,2)").IsRequired();

        builder.HasOne(bpt => bpt.Book)
            .WithMany(b => b.BookPurchaseTypes)
            .HasForeignKey(bpt => bpt.BookId);

        builder.HasOne(bpt => bpt.PurchaseType)
            .WithMany(pt => pt.BookPurchaseTypes)
            .HasForeignKey(bpt => bpt.PurchaseTypeId);
    }
}