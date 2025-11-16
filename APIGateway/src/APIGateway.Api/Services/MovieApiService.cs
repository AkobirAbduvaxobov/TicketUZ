using APIGateway.Api.Dtos.MovieDtos;
using MovieSystem.Api.Dtos;

namespace APIGateway.Api.Services;

public class MovieApiService : IMovieApiService
{
    private readonly List<CinemaHallDto> _cinemaHalls = new();
    private readonly List<MovieDto> _movies = new();
    private long _cinemaHallId = 1;
    private long _movieId = 1;

    public Task<long> AddCinemaHallAsync(CinemaHallCreateDto cinemaHallCreateDto)
    {
        var hall = new CinemaHallDto
        {
            CinemaHallId = _cinemaHallId++,
            Name = cinemaHallCreateDto.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        _cinemaHalls.Add(hall);
        return Task.FromResult(hall.CinemaHallId);
    }

    public Task<long> AddMovieAsync(MovieCreateDto movieCreateDto)
    {
        var movie = new MovieDto
        {
            MovieId = _movieId++,
            Title = movieCreateDto.Title,
            Description = movieCreateDto.Description,
            DurationMinutes = movieCreateDto.DurationMinutes,
            Language = movieCreateDto.Language,
            Genre = movieCreateDto.Genre,
            ReleaseDate = movieCreateDto.ReleaseDate ?? DateTime.UtcNow,
            Rating = movieCreateDto.Rating ?? 0,
            IsActive = movieCreateDto.IsActive,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        _movies.Add(movie);
        return Task.FromResult(movie.MovieId);
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
