using APIGateway.Api.Dtos.MovieDtos;
using System.Net.Http;
using System.Text.Json;

namespace APIGateway.Api.Services;

public class MovieApiService : IMovieApiService
{
    public Task<long> AddCinemaHallAsync(CinemaHallCreateDto cinemaHallCreateDto)
    {
        var hall = new CinemaHallCreateDto
        {
            Name = cinemaHallCreateDto.Name,
            TotalSeats = cinemaHallCreateDto.TotalSeats
        };

        long generatedId = DateTime.Now.Ticks;
        return Task.FromResult(generatedId);
    }

    public Task<long> AddMovieAsync(MovieCreateDto movieCreateDto)
    {
        var movie = new MovieCreateDto
        {
            Title = movieCreateDto.Title,
            Description = movieCreateDto.Description,
            DurationMinutes = movieCreateDto.DurationMinutes,
            Language = movieCreateDto.Language,
            Genre = movieCreateDto.Genre,
            ReleaseDate = movieCreateDto.ReleaseDate,
            Rating = movieCreateDto.Rating
        };

        long generatedId = DateTime.Now.Ticks;
        return Task.FromResult(generatedId);
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
        var httpClient = new HttpClient();

        var response = await httpClient.GetAsync("the correct path with ");
        var content = await response.Content.ReadAsStringAsync();
        List<ShowtimeDto> res = new List<ShowtimeDto>();
        return res;
    }

    public async  Task MakeShowtimeAvailableAsync(long showtimeId)
    {
        HttpClient httpClient = new HttpClient();

        var response = await httpClient.PostAsync($"your-api-path/showtimes/{showtimeId}/available",null);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"Failed to make showtime available: {response.StatusCode}"
            );
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
