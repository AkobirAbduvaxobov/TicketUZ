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
        var cinemaHallExists = await _appDbContext.CinemaHalls.AnyAsync(ch => ch.CinemaHallId == showtimeCreateDto.CinemaHallId);  
        
        if (movieExists == false || cinemaHallExists == null)
        {
            throw new Exception("cinemaHall or movie do not exist");
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

        var decreasePrice = (showtimeCreateDto.MaxPrice - showtimeCreateDto.MinPrice) / showtimeCreateDto.MaxRow;

        for (int i = 1; i <= showtimeCreateDto.MaxRow; i++)
        {
            for(int j = 1; j < showtimeCreateDto.MaxColumn; j++)
            {
                seats.Add(new Seat
                {
                    Row = i,
                    Column = j,
                    IsAvailable = true,
                    ShowtimeId = showtime.ShowtimeId,
                    Price = showtimeCreateDto.MaxPrice - (decreasePrice * (i - 1))
                });
            }
        }

        await _appDbContext.Seats.AddRangeAsync(seats);
        await _appDbContext.SaveChangesAsync();

        return showtime.ShowtimeId;
    }

    public async Task DeleteAsync(long id)
    {
        var showtime = await _appDbContext.Showtimes.FirstOrDefaultAsync(s => s.ShowtimeId == id);
        if(showtime == null)
        {
            throw new Exception("Showtime not found");
        }

        _appDbContext.Showtimes.Remove(showtime);
        await _appDbContext.SaveChangesAsync();
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
            CinemaHallName = s.CinemaHall.Name,
            Seats = null,
        }).ToList();
    }

    public async Task<ShowtimeDto> GetByIdAsync(long id, bool includeSeats)
    {
        var showtime = await _appDbContext.Showtimes.FirstOrDefaultAsync(s => s.ShowtimeId == id);
       
        if (showtime == null)
        {
            throw new Exception("Showtime not found");
        }

        var showTimeDto =  new ShowtimeDto
        {
            ShowtimeId = showtime.ShowtimeId,
            StartTime = showtime.StartTime,
            EndTime = showtime.EndTime,
            MinPrice = showtime.MinPrice,
            MaxPrice = showtime.MaxPrice,
            MovieId = showtime.MovieId,
            CinemaHallId = showtime.CinemaHallId
        };

        if (includeSeats == true)
        {
            await _appDbContext.Entry(showtime).Collection(a => a.Seats).LoadAsync();
            showTimeDto.Seats = showtime.Seats.Select(seat => new SeatDto
            {
                SeatId = seat.SeatId,
                Row = seat.Row,
                Column = seat.Column,
                IsAvailable = seat.IsAvailable,
                Price = seat.Price
            }).ToList();
        }

        return showTimeDto;
    }

    public async Task UpdateAsync(ShowtimeUpdateDto showtimeUpdateDto)
    {
        var showtime = await _appDbContext.Showtimes.FirstOrDefaultAsync(s => s.ShowtimeId == showtimeUpdateDto.ShowtimeId);

        if (showtime == null)
        {
            throw new Exception("Showtime not found");
        }

        showtime.StartTime = showtimeUpdateDto.StartTime;
        showtime.EndTime = showtimeUpdateDto.EndTime;
        showtime.MinPrice = showtimeUpdateDto.MinPrice;
        showtime.MaxPrice = showtimeUpdateDto.MaxPrice;
        showtime.CinemaHallId = showtimeUpdateDto.CinemaHallId;
        showtime.MovieId = showtimeUpdateDto.MovieId;
        showtime.MaxRow = showtimeUpdateDto.MaxRow;
        showtime.MaxColumn = showtimeUpdateDto.MaxColumn;
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<bool> ValidateAsync(long showtimeId, long seatId)
    {
        var showtimeExists = await _appDbContext.Showtimes.AnyAsync(s => s.ShowtimeId == showtimeId);
        var seat = await _appDbContext.Seats.FirstOrDefaultAsync(s => s.SeatId == seatId && s.ShowtimeId == showtimeId);

        var showtimeAvailableDto = new ShowtimeAvailableDto
        {
            ShowtimeExists = showtimeExists,
            SeatExists = seat != null,
            SeatAvailable = seat != null ? seat.IsAvailable : false
        };

        return showtimeAvailableDto.SeatAvailable && showtimeExists && showtimeAvailableDto.SeatAvailable;
    }
}
