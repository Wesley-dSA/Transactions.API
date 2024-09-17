using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Transactions.API.Services.Models;

namespace Transactions.API.Infrastructure.Data;

public class ApplicationDataContext : DbContext
{
    public virtual DbSet<Transactions> idTransactions { get; set; }

    public ApplicationDataContext() : base() { }

    public ApplicationDataContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}