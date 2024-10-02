using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Transactions;
using Transactions.API.Services.Models;

namespace Transactions.API.Infrastructure.Configurations;

public class TransactionEntityConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction");

        builder.Property(e => e.IdTransaction)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("(DATEDIFF(SECOND, '1970-01-01', GETUTCDATE()))");

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(u => u.Document)
            .IsRequired()
            .HasMaxLength(14);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(u => u.BirthDate)
            .IsRequired();

        builder.Property(u => u.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(u => u.Balance)
            .HasDefaultValue(0m)
            .HasColumnType("decimal(18,4)");

        builder.HasIndex(u => u.Document)
            .IsUnique();
    }
}