using APIGateway.Api.Dtos.MovieDtos;
using System.Text.Json;

namespace APIGateway.Api.Services;

public class MovieApiService : IMovieApiService
{
    public Task<long> AddCinemaHallAsync(CinemaHallCreateDto cinemaHallCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<long> AddMovieAsync(MovieCreateDto movieCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<long> AddShowtimeAsync(ShowtimeCreateDto showtimeCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCinemaHallAsync(long cinemaHallId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMovieAsync(long movieId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteShowTimeByIdAsync(long showtimeId)
    {
        throw new NotImplementedException();
    }

    public Task<List<CinemaHallDto>> GetAllCinemaHallsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<MovieDto>> GetAllMoviesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CinemaHallDto> GetCinemaHallByIdAsync(long cinemaHallId)
    {
        throw new NotImplementedException();
    }

    public Task<MovieDto> GetMovieByIdAsync(long movieId)
    {
        throw new NotImplementedException();
    }

    public async Task<SeatDto> GetSeatByIdAsync(long seatId)
    {
        var httpClient = new HttpClient();

        var response = await httpClient.GetAsync("There is no such endpoint yet");
        var content = await response.Content.ReadAsStringAsync();
        return new SeatDto { };
    }

    public async Task<ShowtimeDto> GetShowtimeByIdAsync(long showtimeId)
    {
        var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"the correct path with /{showtimeId}");
        var content = await response.Content.ReadAsStringAsync();
        return new ShowtimeDto { };
    }

    public async Task<List<ShowtimeDto>> GetShowtimesAsync()
    {
        HttpClient httpClient = new HttpClient();

        var response = await httpClient.GetAsync("Here should be Path");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to get shortimes: {response.StatusCode}");
        }

        var json = await response.Content.ReadAsStringAsync();
        var showtimes = JsonSerializer.Deserialize<List<ShowtimeDto>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return showtimes;
    public async Task<List<ShowtimeDto>> GetShowtimesAsync()
    {
        var httpClient = new HttpClient();

        var response = await httpClient.GetAsync("the correct path with ");
        var content = await response.Content.ReadAsStringAsync();
        List<ShowtimeDto> res = new List<ShowtimeDto>();
        return res;
    }

    public Task MakeShowtimeAvailableAsync(long showtimeId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCinemaHallAsync(CinemaHallUpdateDto cinemaHallUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMovieAsync(MovieUpdateDto movieUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateShowtimeAsync(ShowtimeUpdateDto showtimeUpdateDto)
    {
        throw new NotImplementedException();
    }
}
