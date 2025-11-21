using APIGateway.Api.Dtos.BookingDtos;
using APIGateway.Api.Dtos.MovieDtos;

namespace APIGateway.Api.Services;

public class BookingApiService : IBookingApiService
{
    private readonly HttpClient _client;

    public BookingApiService(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("BookingSystem");
    }

    public async Task<long> AddBookingAsync(BookingCreateDto bookingCreateDto)
    {
        var response = await _client.PostAsJsonAsync("api/bookings", bookingCreateDto);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<long>();
    }

    public async Task<List<BookingGetDto>> GetAllBookingsAsync()
    {
        var response = await _client.GetAsync("api/bookings");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<BookingGetDto>>()
               ?? new List<BookingGetDto>();
    }
}
