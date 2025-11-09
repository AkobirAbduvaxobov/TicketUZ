namespace MovieSystem.Api.Dtos;

public class CinemaHallDto
{
    public long CinemaHallId { get; set; }
    public string Name { get; set; }
    public int TotalSeats { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<SeatDto> Seats { get; set; }
}
