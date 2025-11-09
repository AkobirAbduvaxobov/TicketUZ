using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieSystem.Api.Entities;

namespace MovieSystem.Api.Persistense.EntityConfigurations;

public class SeatConfigurations : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.ToTable("Seats");
        builder.HasKey(s => s.SeatId);
        builder.Property(s => s.Row).IsRequired(true);
        builder.Property(s => s.Column).IsRequired(true);
    }
}
