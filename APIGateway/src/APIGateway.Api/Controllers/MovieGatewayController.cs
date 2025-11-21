using APIGateway.Api.Dtos.MovieDtos;
using APIGateway.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Api.Controllers;

[Route("api/gateway/moviesystem")]
[ApiController]
public class MovieGatewayController : ControllerBase
{
    private readonly IMovieApiService _movieApiService;

    public MovieGatewayController(IMovieApiService movieApiService)
    {
        _movieApiService = movieApiService;
    }

    [HttpPost("cinemahalls")]
    public async Task<IActionResult> AddCinemaHall(CinemaHallCreateDto cinemaHallCreateDto)
    {
        var result = await _movieApiService.AddCinemaHallAsync(cinemaHallCreateDto);
        return Ok(result);
    }

    [HttpGet("cinemahalls")]
    public async Task<IActionResult> GetCinemaHalls()
    {
        var result = await _movieApiService.GetAllCinemaHallsAsync();
        return Ok(result);
    }


    [HttpPost("movies")]
    public async Task<IActionResult> AddMovie(MovieCreateDto movieCreateDto)
    {
        var result = await _movieApiService.AddMovieAsync(movieCreateDto);
        return Ok(result);
    }

    [HttpGet("movies")]
    public async Task<IActionResult> GetMovies()
    {
        var result = await _movieApiService.GetAllMoviesAsync();
        return Ok(result);
    }


    [HttpPost("showtimes")]
    public async Task<IActionResult> AddShowtimeAsync(ShowtimeCreateDto showtimeCreateDto)
    {
        var result = await _movieApiService.AddShowtimeAsync(showtimeCreateDto);
        return Ok(result);
    }

    [HttpGet("showtimes")]
    public async Task<IActionResult> GetShowtimes()
    {
        var result = await _movieApiService.GetAllShowtimesAsync();
        return Ok(result);
    }
}
