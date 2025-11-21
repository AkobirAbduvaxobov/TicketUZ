using BookingSystem.Api.Entities;
using BookingSystem.Api.Persistense.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Api.Persistense;

public class AppDbContext : DbContext
{
    public DbSet<Booking> Bookings { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new BookingConfiguration());
    }
}

