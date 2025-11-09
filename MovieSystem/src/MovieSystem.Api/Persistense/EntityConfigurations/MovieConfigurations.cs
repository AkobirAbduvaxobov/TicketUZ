using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieSystem.Api.Entities;

namespace MovieSystem.Api.Persistense.EntityConfigurations;

public class MovieConfigurations : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
        builder.HasKey(m => m.MovieId);
        builder.Property(t => t.Title).IsRequired(true).HasMaxLength(100);
        builder.Property(t => t.Description).IsRequired(true).HasMaxLength(400);
        builder.Property(t => t.Language).IsRequired(true);
        builder.Property(t => t.Genre).IsRequired(true);

        builder.HasMany(m => m.Showtimes)
                .WithOne(s => s.Movie)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
