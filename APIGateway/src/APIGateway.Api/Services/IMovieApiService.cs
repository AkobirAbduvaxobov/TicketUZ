using APIGateway.Api.Dtos.MovieDtos;

namespace APIGateway.Api.Services;

public interface IMovieApiService
{
    Task<long> AddCinemaHallAsync(CinemaHallCreateDto cinemaHallCreateDto);
    Task UpdateCinemaHallAsync(CinemaHallUpdateDto cinemaHallUpdateDto);
    Task DeleteCinemaHallAsync(long cinemaHallId);
    Task<CinemaHallDto> GetCinemaHallByIdAsync(long cinemaHallId);
    Task<List<CinemaHallDto>> GetAllCinemaHallsAsync();


    Task<long> AddMovieAsync(MovieCreateDto movieCreateDto);
    Task UpdateMovieAsync(MovieUpdateDto movieUpdateDto);
    Task<MovieDto> GetMovieByIdAsync(long movieId);
    Task<List<MovieDto>> GetAllMoviesAsync();
    Task DeleteMovieAsync(long movieId);

    Task<SeatDto> GetSeatByIdAsync(long seatId);


    Task<long> AddShowtimeAsync(ShowtimeCreateDto showtimeCreateDto);
    Task DeleteShowTimeByIdAsync(long showtimeId);
    Task<List<ShowtimeDto>> GetAllShowtimesAsync();
    Task<ShowtimeDto> GetShowtimeByIdAsync(long showtimeId);
    Task MakeShowtimeAvailableAsync(long showtimeId);
    Task UpdateShowtimeAsync(ShowtimeUpdateDto showtimeUpdateDto);

}