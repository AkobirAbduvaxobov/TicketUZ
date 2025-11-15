using APIGateway.Api.Dtos.MovieDtos;

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

    public Task<SeatDto> GetSeatByIdAsync(long seatId)
    {
        throw new NotImplementedException();
    }

    public Task<ShowtimeDto> GetShowtimeByIdAsync(long showtimeId)
    {
        throw new NotImplementedException();
    }

    public Task<List<ShowtimeDto>> GetShowtimesAsync()
    {
        throw new NotImplementedException();
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
