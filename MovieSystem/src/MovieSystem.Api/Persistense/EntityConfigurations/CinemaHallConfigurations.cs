using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieSystem.Api.Entities;

namespace MovieSystem.Api.Persistense.EntityConfigurations;

public class CinemaHallConfigurations : IEntityTypeConfiguration<CinemaHall>
{
    public void Configure(EntityTypeBuilder<CinemaHall> builder)
    {
        builder.ToTable("CinemaHalls");
        builder.HasKey(m => m.CinemaHallId);
        builder.Property(t => t.Name).IsRequired(true);

        builder.HasMany(m => m.Showtimes)
                .WithOne(s => s.CinemaHall)
                .HasForeignKey(s => s.CinemaHallId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}