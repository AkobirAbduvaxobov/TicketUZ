namespace MovieSystem.Api.Dtos;

public class ShowtimeDto
{
    public long ShowtimeId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }

    public long MovieId { get; set; }
    public long CinemaHallId { get; set; }

    public string MovieTitle { get; set; }
    public string CinemaHallName { get; set; }
    public List<SeatDto>? Seats { get; set; }  
}
