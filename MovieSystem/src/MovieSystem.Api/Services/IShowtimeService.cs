using MovieSystem.Api.Dtos;

namespace MovieSystem.Api.Services;

public interface IShowtimeService
{
    public Task<long> AddAsync(ShowtimeCreateDto showtimeCreateDto);
    public Task UpdateAsync(ShowtimeUpdateDto showtimeUpdateDto);
    public Task<ShowtimeDto> GetByIdAsync(long id, bool includeSeats);
    public Task<List<ShowtimeDto>> GetAllAsync();
    public Task DeleteAsync(long id);
    public Task<bool> ValidateAsync(long showtimeId, long seatId);
}