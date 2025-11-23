using BookingSystem.Api.Dtos;
using BookingSystem.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers;

[Route("api/bookings")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;
    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost]
    public async Task<ActionResult<long>> CreateBooking([FromBody] BookingCreateDto bookingCreateDto)
    {
        var bookingId = await _bookingService.AddAsync(bookingCreateDto);
        return CreatedAtAction(nameof(GetBookingById), new { id = bookingId }, bookingId);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookingGetDto>> GetBookingById(long id)
    {
        var booking = await _bookingService.GetByIdAsync(id);
        if (booking == null)
        {
            return NotFound();
        }
        return Ok(booking);
    }

    [HttpGet]
    public async Task<ActionResult<List<BookingGetDto>>> GetAllBookings()
    {
        var bookings = await _bookingService.GetAllAsync();
        return Ok(bookings);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(long id)
    {
        await _bookingService.DeleteAsync(id);
        return NoContent();
    }
}
