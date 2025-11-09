namespace MovieSystem.Api.Dtos;

public class SeatDto
{
    public long SeatId { get; set; }
    public string SeatNumber { get; set; }
    public string Row { get; set; }
    public bool IsVip { get; set; }

    public long CinemaHallId { get; set; }
}
