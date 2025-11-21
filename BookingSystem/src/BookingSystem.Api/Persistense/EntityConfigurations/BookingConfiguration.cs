using BookingSystem.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingSystem.Api.Persistense.EntityConfigurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");

        builder.HasKey(b => b.BookingId);

        builder.Property(b => b.UserId)
               .IsRequired();

        builder.Property(b => b.ShowtimeId)
               .IsRequired();

        builder.Property(b => b.SeatId)
               .IsRequired();

        builder.Property(b => b.TotalPrice)
               .HasPrecision(18, 2)
               .IsRequired();

        builder.Property(b => b.BookingDate)
               .IsRequired();

        builder.Property(b => b.Status)
               .HasConversion<int>()
               .IsRequired();
    }
}
