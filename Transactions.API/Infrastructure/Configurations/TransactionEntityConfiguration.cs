using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transactions.API.Services.Models;

namespace Transactions.API.Infrastructure.Configurations;

public class TransactionEntityConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction");

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasMaxLength(1000);

        builder.Property(e =>e.Idsender)
            .IsRequired()
            .HasMaxLength(1000);
        
        builder.Property(e => e.IdRecipient)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(e => e.Valor)
            .HasDefaultValue(0)
            .HasColumnType("decimal");


        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.Idsender)
            .IsUnique();

        builder.HasIndex(e => e.IdRecipient)
            .IsUnique();
           
    }
}