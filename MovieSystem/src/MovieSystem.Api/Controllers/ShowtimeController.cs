using Microsoft.AspNetCore.Mvc;
using MovieSystem.Api.Dtos;
using MovieSystem.Api.Services;

namespace MovieSystem.Api.Controllers;

[Route("api/showtimes")]
[ApiController]
public class ShowtimeController : ControllerBase
{
    private readonly IShowtimeService _showtimeService;

    public ShowtimeController(IShowtimeService showtimeService)
    {
        _showtimeService = showtimeService;
    }

    [HttpPost]
    public async Task<long> Add([FromBody] ShowtimeCreateDto showtimeCreateDto)
    {
        var showtimeId = await _showtimeService.AddAsync(showtimeCreateDto);
        return showtimeId;
    }

    [HttpGet]
    public async Task<List<ShowtimeDto>> GetAll()
    {
        var showtimes = await _showtimeService.GetAllAsync();
        return showtimes;
    }

    [HttpGet("{id}")]
    public async Task<ShowtimeDto> GetById(long id, bool includeSeats)
    {
        return await _showtimeService.GetByIdAsync(id, includeSeats);
    }

    [HttpGet("{showtimeId}/seats/{seatId}/validate")]
    public async Task<bool> ValidateSeat(long showtimeId, long seatId)
    {
        var result = await _showtimeService.ValidateAsync(showtimeId, seatId);
        return result;
    }

}
