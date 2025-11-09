using AuthSystem.Api.Entities;
using AuthSystem.Api.Persistense.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Api.Persistense;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfigurations());
    }
}

