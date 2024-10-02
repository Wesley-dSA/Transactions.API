using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Transactions;

namespace Transactions.API.Infrastructure.Data;

public class ApplicationDataContext : DbContext
{
    public virtual DbSet<Transaction> Transactions { get; set; }

    public ApplicationDataContext() : base() { }

    public ApplicationDataContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}