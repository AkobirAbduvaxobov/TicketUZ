namespace MovieSystem.Api.Entities;

public class Seat
{
    public long SeatId { get; set; }
    public int Column { get; set; }
    public int Row { get; set; }
    public bool IsAvailable { get; set; }
    public decimal Price { get; set; }

    public Showtime Showtime { get; set; }
    public long ShowtimeId { get; set; }
}
