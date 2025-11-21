using APIGateway.Api.Dtos.BookingDtos;
using APIGateway.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Api.Controllers;

[Route("api/gateway/bookingsystem")]
[ApiController]
public class BookingGatewayController : ControllerBase
{
    private readonly IBookingApiService _bookingApiService;
    public BookingGatewayController(IBookingApiService bookingApiService)
    {
        _bookingApiService = bookingApiService;
    }

    [HttpPost("bookings")]
    public async Task<IActionResult> AddBooking(BookingCreateDto bookingCreateDto)
    {
        var result = await _bookingApiService.AddBookingAsync(bookingCreateDto);
        return Ok(result);
    }

    [HttpGet("bookings")]
    public async Task<IActionResult> GetBookings()
    {
        var result = await _bookingApiService.GetAllBookingsAsync();
        return Ok(result);
    }
}
