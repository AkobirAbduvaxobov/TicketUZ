using APIGateway.Api.Dtos.MovieDtos;
using MovieSystem.Api.Dtos;
using Newtonsoft.Json;
using static Google.Apis.Requests.BatchRequest;

namespace APIGateway.Api.Services;

public class MovieApiService : IMovieApiService
{
    private readonly HttpClient _httpClient;

    public MovieApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

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
        //var response = await _httpClient.GetAsync($"api/showtime");

        //if (!response.IsSuccessStatusCode)
        //{
        //    throw new HttpRequestException($"Failed to get shortimes: {response.StatusCode}");
        //}

        //return await response.Content.ReadAsStringAsync();

        throw new NotImplementedException();

    }

    public async Task MakeShowtimeAvailableAsync(long showtimeId)
    {
        var response = await _httpClient.PutAsync($"api/showtime/{showtimeId}/available", null);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to make shortime available: {response.StatusCode}");
        }
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
