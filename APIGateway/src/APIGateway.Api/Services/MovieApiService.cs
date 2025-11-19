using APIGateway.Api.Dtos;
using APIGateway.Api.Dtos.MovieDtos;

namespace APIGateway.Api.Services;

public class MovieApiService : IMovieApiService
{
    private readonly HttpClient _client;

    public MovieApiService(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("MovieSystem");
    }

    public async Task<long> AddCinemaHallAsync(CinemaHallCreateDto cinemaHallCreateDto)
    {
        var response = await _client.PostAsJsonAsync("api/cinemahalls", cinemaHallCreateDto);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<long>();
    }

    public async Task<long> AddMovieAsync(MovieCreateDto movieCreateDto)
    {
        var response = await _client.PostAsJsonAsync("api/movies", movieCreateDto);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<long>();
    }

    public async Task<long> AddShowtimeAsync(ShowtimeCreateDto showtimeCreateDto)
    {
        var response = await _client.PostAsJsonAsync("api/showtimes", showtimeCreateDto);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<long>();
    }

    public async Task<List<CinemaHallDto>> GetAllCinemaHallsAsync()
    {
        var response = await _client.GetAsync("api/cinemahalls");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<CinemaHallDto>>()
               ?? new List<CinemaHallDto>();
    }


    public async Task<List<MovieDto>> GetAllMoviesAsync()
    {
        var response = await _client.GetAsync("api/movies");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<MovieDto>>()
               ?? new List<MovieDto>();
    }

    public async Task<List<ShowtimeDto>> GetAllShowtimesAsync()
    {
        var response = await _client.GetAsync("api/showtimes");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<ShowtimeDto>>()
               ?? new List<ShowtimeDto>();
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
        throw new NotImplementedException();
    }

    public async Task<ShowtimeDto> GetShowtimeByIdAsync(long showtimeId)
    {
        throw new NotImplementedException();
    }

   
    public async Task MakeShowtimeAvailableAsync(long showtimeId)
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
