using Microsoft.EntityFrameworkCore;
using MovieSystem.Api.Dtos;
using MovieSystem.Api.Entities;
using MovieSystem.Api.Persistense;

namespace MovieSystem.Api.Services;

public class ShowtimeService : IShowtimeService
{
    private readonly AppDbContext _appDbContext;

    public ShowtimeService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<long> AddAsync(ShowtimeCreateDto showtimeCreateDto)
    {
        var movieExists = await _appDbContext.Movies.AnyAsync(m => m.MovieId == showtimeCreateDto.MovieId);
        var cinemaHall = await _appDbContext.CinemaHalls.FirstOrDefaultAsync(ch => ch.CinemaHallId == showtimeCreateDto.CinemaHallId);  
        
        if (movieExists == false || cinemaHall == null)
        {
            throw new Exception("movie or showtime do not exist");
        }

        var showtime = new Showtime
        {
            StartTime = showtimeCreateDto.StartTime,
            EndTime = showtimeCreateDto.EndTime,
            MinPrice = showtimeCreateDto.MinPrice,
            MaxPrice = showtimeCreateDto.MaxPrice,
            MovieId = showtimeCreateDto.MovieId,
            CinemaHallId = showtimeCreateDto.CinemaHallId
        };

        await _appDbContext.Showtimes.AddAsync(showtime);
        await _appDbContext.SaveChangesAsync();

        var seats = new List<Seat>();

        for (int i = 1; i <= cinemaHall.TotalSeats; i++)
        {
            seats.Add(new Seat
            {
                SeatNumber = i,
                IsAvailable = true,
                ShowtimeId = showtime.ShowtimeId,
                CinemaHallId = cinemaHall.CinemaHallId,
                Row = "A"
            });
        }

        await _appDbContext.Seats.AddRangeAsync(seats);
        await _appDbContext.SaveChangesAsync();

        return showtime.ShowtimeId;
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ShowtimeDto>> GetAllAsync()
    {
        var showtimes = await _appDbContext.Showtimes
                            .Include(s => s.Movie)
                            .Include(s => s.CinemaHall)
                            .ToListAsync();


        return showtimes.Select(s => new ShowtimeDto
        {
            ShowtimeId = s.ShowtimeId,
            StartTime = s.StartTime,
            EndTime = s.EndTime,
            MinPrice = s.MinPrice,
            MaxPrice = s.MaxPrice,
            MovieId = s.MovieId,
            CinemaHallId = s.CinemaHallId,
            MovieTitle = s.Movie.Title,
            CinemaHallName = s.CinemaHall.Name
        }).ToList();
    }

    public Task<ShowtimeDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ShowtimeUpdateDto showtimeUpdateDto)
    {
        throw new NotImplementedException();
    }
}
