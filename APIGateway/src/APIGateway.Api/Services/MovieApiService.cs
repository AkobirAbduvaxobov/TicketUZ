using System.Net.Http;
using System.Text.Json;
using APIGateway.Api.Dtos;
using APIGateway.Api.Dtos.MovieDtos;
using MovieSystem.Api.Dtos;

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

    public async Task<List<CinemaHallDto>> GetAllCinemaHallsAsync()
    {
        var _httpClient = new HttpClient();

        var cinameHall = await _httpClient.GetFromJsonAsync<List<CinemaHallDto>>("cinemahalls");
        return cinameHall;
    }

    public async Task<List<MovieDto>> GetAllMoviesAsync()
    {
        var _httpClient = new HttpClient();

        var movies = await _httpClient.GetFromJsonAsync<List<MovieDto>>("movies");
        return movies;
    }

    public Task<CinemaHallDto> GetCinemaHallByIdAsync(long cinemaHallId)
    {
        throw new NotImplementedException();
    }

    public Task<MovieDto> GetMovieByIdAsync(long movieId)
    {
        throw new NotImplementedException();
    }

    public Task<SeatDto> GetSeatByIdAsync(long seatId)
    {
        throw new NotImplementedException();
    }

    public Task<ShowtimeDto> GetShowtimeByIdAsync(long showtimeId)
    {
        throw new NotImplementedException();
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
