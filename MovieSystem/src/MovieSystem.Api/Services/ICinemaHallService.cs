using MovieSystem.Api.Dtos;

namespace MovieSystem.Api.Services;

public interface ICinemaHallService
{
    public Task<long> AddAsync(CinemaHallCreateDto cinemaHallCreateDto);
    public Task UpdateAsync(CinemaHallUpdateDto cinemaHallUpdateDto);
    public Task<CinemaHallDto> GetByIdAsync(long id);
    public Task<List<CinemaHallDto>> GetAllAsync();
    public Task DeleteAsync(long id);
}