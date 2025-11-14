
namespace MovieSystem.Api.Dtos;

public class ShowtimeCreateDto
{
    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public decimal MinPrice { get; set; }

    public decimal MaxPrice { get; set; }
    public decimal MaxRow { get; set; }
    public decimal MaxColumn { get; set; }

    public long MovieId { get; set; }

    public long CinemaHallId { get; set; }
}
