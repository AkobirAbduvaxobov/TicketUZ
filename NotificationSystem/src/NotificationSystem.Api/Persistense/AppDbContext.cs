using NotificationSystem.Api.Persistense.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using NotificationSystem.Api.Entities;

namespace NotificationSystem.Api.Persistense;

public class AppDbContext : DbContext
{
    public DbSet<Notification> Notifications { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}

