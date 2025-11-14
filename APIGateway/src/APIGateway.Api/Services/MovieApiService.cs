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
            var id = Interlocked.Increment(ref _cinemaHallId);
            var dto = new CinemaHallDto
            {
                Id = id,
                Name = cinemaHallCreateDto.Name,
                // add other properties
            };
            _cinemaHalls[id] = dto;
            return await Task.FromResult(id);
        }

        public async Task UpdateCinemaHallAsync(CinemaHallUpdateDto cinemaHallUpdateDto)
        {
            if (_cinemaHalls.TryGetValue(cinemaHallUpdateDto.Id, out var hall))
            {
                hall.Name = cinemaHallUpdateDto.Name;
                // update other properties
            }
            await Task.CompletedTask;
        }

        public async Task DeleteCinemaHallAsync(long cinemaHallId)
        {
            _cinemaHalls.TryRemove(cinemaHallId, out _);
            await Task.CompletedTask;
        }

        public async Task<CinemaHallDto> GetCinemaHallByIdAsync(long cinemaHallId)
        {
            _cinemaHalls.TryGetValue(cinemaHallId, out var hall);
            return await Task.FromResult(hall);
        }

        public async Task<List<CinemaHallDto>> GetAllCinemaHallsAsync()
        {
            return await Task.FromResult(_cinemaHalls.Values.ToList());
        }

        public async Task<long> AddMovieAsync(MovieCreateDto movieCreateDto)
        {
            var id = Interlocked.Increment(ref _movieId);
            var dto = new MovieDto
            {
                Id = id,
                Title = movieCreateDto.Title,
                // add other properties
            };
            _movies[id] = dto;
            return await Task.FromResult(id);
        }

        public async Task UpdateMovieAsync(MovieUpdateDto movieUpdateDto)
        {
            if (_movies.TryGetValue(movieUpdateDto.Id, out var movie))
            {
                movie.Title = movieUpdateDto.Title;
                // update other properties
            }
            await Task.CompletedTask;
        }

        public async Task<MovieDto> GetMovieByIdAsync(long movieId)
        {
            _movies.TryGetValue(movieId, out var movie);
            return await Task.FromResult(movie);
        }

        public async Task<List<MovieDto>> GetAllMoviesAsync()
        {
            return await Task.FromResult(_movies.Values.ToList());
        }

        public async Task DeleteMovieAsync(long movieId)
        {
            _movies.TryRemove(movieId, out _);
            await Task.CompletedTask;
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
