namespace APIGateway.Api.Dtos.MovieDtos;

public class ShowtimeAvailableDto
{
    public bool ShowtimeExists { get; set; }
    public bool SeatExists { get; set; }
    public bool SeatAvailable { get; set; }
}
