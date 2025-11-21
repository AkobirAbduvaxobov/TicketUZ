namespace BookingSystem.Api.Dtos;

public class BookingCreateDto
{
    public long UserId { get; set; }
    public long ShowtimeId { get; set; }
    public long SeatId { get; set; }
    public decimal TotalPrice { get; set; }
}
