using PaymentSystem.Api.Persistense.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Api.Entities;

namespace PaymentSystem.Api.Persistense;

public class AppDbContext : DbContext
{
    public DbSet<Payment> Payments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}

