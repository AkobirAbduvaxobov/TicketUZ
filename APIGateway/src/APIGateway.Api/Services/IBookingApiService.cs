using APIGateway.Api.Dtos.BookingDtos;

namespace APIGateway.Api.Services;

public interface IBookingApiService
{
    Task<long> AddBookingAsync(BookingCreateDto bookingCreateDto);
    Task<List<BookingGetDto>> GetAllBookingsAsync();
}