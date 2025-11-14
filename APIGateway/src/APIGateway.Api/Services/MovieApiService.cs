using APIGateway.Api.Dtos.MovieDtos;
using APIGateway.Api.Services;
using System.Text.Json;

namespace APIGateway.Api.Services
{
    public class MovieApiService : IMovieApiService
    {
        public async Task<long> AddCinemaHallAsync(CinemaHallCreateDto cinemaHallCreateDto)
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task UpdateCinemaHallAsync(CinemaHallUpdateDto cinemaHallUpdateDto)
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task DeleteCinemaHallAsync(long cinemaHallId)
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task<CinemaHallDto> GetCinemaHallByIdAsync(long cinemaHallId)
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task<List<CinemaHallDto>> GetAllCinemaHallsAsync()
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task<long> AddMovieAsync(MovieCreateDto movieCreateDto)
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task UpdateMovieAsync(MovieUpdateDto movieUpdateDto)
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task<string> GetMovieByIdAsync(long movieId)
        {
            var movie = new MovieDto { Id = movieId /* populate other properties if needed */ };
            return await Task.FromResult(JsonSerializer.Serialize(movie));
        }

        public async Task<string> GetAllMoviesAsync()
        {
            var movies = new List<MovieDto>
            {
                new MovieDto { Id = 1 },
                new MovieDto { Id = 2 }
            };
            return await Task.FromResult(JsonSerializer.Serialize(movies));
        }

        public async Task DeleteMovieAsync(long movieId)
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task<SeatDto> GetSeatByIdAsync(long seatId)
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task<long> AddShowtimeAsync(ShowtimeCreateDto showtimeCreateDto)
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task DeleteShowTimeByIdAsync(long showtimeId)
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task<List<ShowtimeDto>> GetShowtimesAsync()
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task<ShowtimeDto> GetShowtimeByIdAsync(long showtimeId)
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task MakeShowtimeAvailableAsync(long showtimeId)
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task UpdateShowtimeAsync(ShowtimeUpdateDto showtimeUpdateDto)
        {
            throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }
    }
}
