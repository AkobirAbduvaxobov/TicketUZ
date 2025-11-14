namespace MovieSystem.Api.Dtos;

public class MovieDto
{
    public long MovieId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int DurationMinutes { get; set; }
    public string Language { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Rating { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
