namespace MovieSystem.Api.Dtos;

public class SeatDto
{
    public long SeatId { get; set; }
    public int Column { get; set; }
    public int Row { get; set; }
    public bool IsAvailable { get; set; }
    public decimal Price { get; set; }

}
