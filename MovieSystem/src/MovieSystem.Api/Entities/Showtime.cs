namespace MovieSystem.Api.Entities;

public class Showtime
{
    public long ShowtimeId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
    public int MaxRow { get; set; }
    public int MaxColumn { get; set; }
    public ICollection<Seat> Seats { get; set; }

    public long MovieId { get; set; }
    public Movie Movie { get; set; }

    public long CinemaHallId { get; set; }
    public CinemaHall CinemaHall { get; set; }
}
