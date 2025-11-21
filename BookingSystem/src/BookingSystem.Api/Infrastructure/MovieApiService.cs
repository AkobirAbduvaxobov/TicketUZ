
namespace BookingSystem.Api.Infrastructure;

public class MovieApiService : IMovieApiService
{
    private readonly HttpClient _client;

    public MovieApiService(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("MovieSystem"); 
    }

    public async Task<bool> ValidateShowtime(long showtimeId, long seatId, decimal TotalPrice)
    {
        var response = await _client.GetAsync($"api/showtimes/{showtimeId}/seats/{seatId}/validate");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<bool>();
    }
}
