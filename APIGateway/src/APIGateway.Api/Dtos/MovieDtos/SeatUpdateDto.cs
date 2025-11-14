
namespace MovieSystem.Api.Dtos;

public class SeatUpdateDto
{
    public long SeatId { get; set; }

    public string SeatNumber { get; set; }

    public string Row { get; set; }

    public bool IsVip { get; set; } = false;

    public long CinemaHallId { get; set; }
}
