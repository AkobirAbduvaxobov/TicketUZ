using BookingSystem.Api.Entities;

namespace BookingSystem.Api.Dtos;

public class BookingGetDto
{
    public long BookingId { get; set; }
    public long UserId { get; set; }
    public long ShowtimeId { get; set; }
    public long SeatId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime BookingDate { get; set; }
    public BookingStatus Status { get; set; }
}
