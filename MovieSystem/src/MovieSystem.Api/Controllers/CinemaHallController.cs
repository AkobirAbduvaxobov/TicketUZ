using Microsoft.AspNetCore.Mvc;
using MovieSystem.Api.Dtos;
using MovieSystem.Api.Services;

namespace MovieSystem.Api.Controllers;

[Route("api/cinemahalls")]
[ApiController]
public class CinemaHallController : ControllerBase
{
    private readonly ICinemaHallService _cinemaHallService;

    public CinemaHallController(ICinemaHallService cinemaHallService)
    {
        _cinemaHallService = cinemaHallService;
    }

    [HttpGet]
    public async Task<List<CinemaHallDto>> GetAll()
    {
        var cinemaHalls = await _cinemaHallService.GetAllAsync();
        return cinemaHalls;
    }

    [HttpPost]
    public async Task<long> Add([FromBody] CinemaHallCreateDto cinemaHallCreateDto)
    {
        var cinemaHallId = await _cinemaHallService.AddAsync(cinemaHallCreateDto);
        return cinemaHallId;
    }
}
