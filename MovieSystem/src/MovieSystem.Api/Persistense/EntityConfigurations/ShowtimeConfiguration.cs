using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieSystem.Api.Entities;

namespace MovieSystem.Api.Persistense.EntityConfigurations;

public class ShowtimeConfiguration : IEntityTypeConfiguration<Showtime>
{
    public void Configure(EntityTypeBuilder<Showtime> builder)
    {
        builder.ToTable("Showtimes");
        builder.HasKey(s => s.ShowtimeId);
        builder.Property(s => s.MinPrice).IsRequired(true);
        builder.Property(s => s.MaxPrice).IsRequired(true);
        builder.Property(s => s.MaxRow).IsRequired(true);
        builder.Property(s => s.MaxColumn).IsRequired(true);
        builder.Property(s => s.EndTime).IsRequired(false);

        builder.HasMany(m => m.Seats)
                .WithOne(s => s.Showtime)
                .HasForeignKey(s => s.ShowtimeId)
                .OnDelete(DeleteBehavior.Restrict);

    }
}