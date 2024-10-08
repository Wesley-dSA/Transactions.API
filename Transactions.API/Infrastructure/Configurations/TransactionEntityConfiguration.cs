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
            .HasMaxLength(100);
        
    }
}