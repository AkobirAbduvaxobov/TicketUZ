using BookingSystem.Api.Dtos;

namespace BookingSystem.Api.Services;

public interface IBookingService
{
    public Task<long> AddAsync(BookingCreateDto bookingCreateDto);
    public Task<BookingGetDto> GetByIdAsync(long id);
    public Task<List<BookingGetDto>> GetAllAsync();
    public Task DeleteAsync(long id);
}