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
            TotalSeats = cinemaHallCreateDto.TotalSeats,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _appDbContext.CinemaHalls.AddAsync(cinemaHall);
        await _appDbContext.SaveChangesAsync();
        return cinemaHall.CinemaHallId;
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CinemaHallDto>> GetAllAsync()
    {
        var cinemaHalls = await _appDbContext.CinemaHalls.ToListAsync();

        return cinemaHalls.Select(ch => new CinemaHallDto
        {
            CinemaHallId = ch.CinemaHallId,
            Name = ch.Name,
            TotalSeats = ch.TotalSeats,
            CreatedAt = ch.CreatedAt,
            UpdatedAt = ch.UpdatedAt
        }).ToList();
    }

    public Task<CinemaHallDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CinemaHallUpdateDto cinemaHallUpdateDto)
    {
        throw new NotImplementedException();
    }
}
