using APIGateway.Api.Dtos.MovieDtos;
using APIGateway.Api.Services;
using System.Collections.Concurrent;

namespace APIGateway.Api.Services
{
    public class MovieApiService : IMovieApiService
    {
        // Simulated in-memory storage
        private readonly ConcurrentDictionary<long, CinemaHallDto> _cinemaHalls = new();
        private readonly ConcurrentDictionary<long, MovieDto> _movies = new();
        private readonly ConcurrentDictionary<long, SeatDto> _seats = new();
        private readonly ConcurrentDictionary<long, ShowtimeDto> _showtimes = new();

        private long _cinemaHallId = 1;
        private long _movieId = 1;
        private long _seatId = 1;
        private long _showtimeId = 1;

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
        throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");        }

        public async Task<CinemaHallDto> GetCinemaHallByIdAsync(long cinemaHallId)
        {
        throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");        }

        public async Task<List<CinemaHallDto>> GetAllCinemaHallsAsync()
        {
        throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");        }

        public async Task<long> AddMovieAsync(MovieCreateDto movieCreateDto)
        {
        throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task UpdateMovieAsync(MovieUpdateDto movieUpdateDto)
        {
        throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task<MovieDto> GetMovieByIdAsync(long movieId)
        {
        throw new NotImplementedException("wth.");
        }

        public async Task<List<MovieDto>> GetAllMoviesAsync()
        {
        throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");        }

        public async Task DeleteMovieAsync(long movieId)
        {
        throw new NotImplementedException("The 'DoSomething' method is not yet implemented.");
        }

        public async Task<SeatDto> GetSeatByIdAsync(long seatId)
        {
            _seats.TryGetValue(seatId, out var seat);
            return await Task.FromResult(seat);
        }

        public async Task<long> AddShowtimeAsync(ShowtimeCreateDto showtimeCreateDto)
        {
            var id = Interlocked.Increment(ref _showtimeId);
            var dto = new ShowtimeDto
            {
                Id = id,
                MovieId = showtimeCreateDto.MovieId,
                // add other properties
                IsAvailable = false
            };
            _showtimes[id] = dto;
            return await Task.FromResult(id);
        }

        public async Task DeleteShowTimeByIdAsync(long showtimeId)
        {
            _showtimes.TryRemove(showtimeId, out _);
            await Task.CompletedTask;
        }

        public async Task<List<ShowtimeDto>> GetShowtimesAsync()
        {
            return await Task.FromResult(_showtimes.Values.ToList());
        }

        public async Task<ShowtimeDto> GetShowtimeByIdAsync(long showtimeId)
        {
            _showtimes.TryGetValue(showtimeId, out var showtime);
            return await Task.FromResult(showtime);
        }

        public async Task MakeShowtimeAvailableAsync(long showtimeId)
        {
            if (_showtimes.TryGetValue(showtimeId, out var showtime))
            {
                showtime.IsAvailable = true;
            }
            await Task.CompletedTask;
        }

        public async Task UpdateShowtimeAsync(ShowtimeUpdateDto showtimeUpdateDto)
        {
            if (_showtimes.TryGetValue(showtimeUpdateDto.Id, out var showtime))
            {
                showtime.MovieId = showtimeUpdateDto.MovieId;
                // update other properties
            }
            await Task.CompletedTask;
        }
    }
}
