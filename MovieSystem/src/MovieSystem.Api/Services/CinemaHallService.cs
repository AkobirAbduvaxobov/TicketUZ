using Microsoft.EntityFrameworkCore;
using MovieSystem.Api.Dtos;
using MovieSystem.Api.Entities;
using MovieSystem.Api.Persistense;

namespace MovieSystem.Api.Services;

public class CinemaHallService : ICinemaHallService
{
    private readonly AppDbContext _appDbContext;

    public CinemaHallService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<long> AddAsync(CinemaHallCreateDto cinemaHallCreateDto)
    {
        var cinemaHall = new CinemaHall
        {
            Name = cinemaHallCreateDto.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _appDbContext.CinemaHalls.AddAsync(cinemaHall);
        await _appDbContext.SaveChangesAsync();
        return cinemaHall.CinemaHallId;
    }

    public async Task DeleteAsync(long id)
    {
        var cinemaHall = await _appDbContext.CinemaHalls.FirstOrDefaultAsync(ch => ch.CinemaHallId == id);
        if(cinemaHall == null)
        {
            throw new Exception("Cinema hall not found");
        }

        _appDbContext.CinemaHalls.Remove(cinemaHall);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<CinemaHallDto>> GetAllAsync()
    {
        var cinemaHalls = await _appDbContext.CinemaHalls.ToListAsync();

        return cinemaHalls.Select(ch => new CinemaHallDto
        {
            CinemaHallId = ch.CinemaHallId,
            Name = ch.Name,
            CreatedAt = ch.CreatedAt,
            UpdatedAt = ch.UpdatedAt
        }).ToList();
    }

    public async Task<CinemaHallDto> GetByIdAsync(long id)
    {
        var cinemaHall = await _appDbContext.CinemaHalls.FirstOrDefaultAsync(ch => ch.CinemaHallId == id);
        
        if (cinemaHall == null)
        {
            throw new Exception("Cinema hall not found");
        }
        return new CinemaHallDto
        {
            CinemaHallId = cinemaHall.CinemaHallId,
            Name = cinemaHall.Name,
            CreatedAt = cinemaHall.CreatedAt,
            UpdatedAt = cinemaHall.UpdatedAt
        };
    }

    public async Task UpdateAsync(CinemaHallUpdateDto cinemaHallUpdateDto)
    {
        CinemaHall? cinemaHall = await _appDbContext.CinemaHalls.FirstOrDefaultAsync(ch => ch.CinemaHallId == cinemaHallUpdateDto.CinemaHallId);

        if (cinemaHall == null)
        {
            throw new Exception("Cinema hall not found");
        }

        cinemaHall.UpdatedAt = DateTime.UtcNow;
        cinemaHall.Name = cinemaHallUpdateDto.Name;

        await _appDbContext.SaveChangesAsync();
    }
}
