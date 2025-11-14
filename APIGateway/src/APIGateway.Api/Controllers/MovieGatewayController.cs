using APIGateway.Api.Dtos.MovieDtos;
using APIGateway.Api.Services;
using Microsoft.AspNetCore.Mvc;
using MovieSystem.Api.Dtos;

namespace APIGateway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGatewayController : ControllerBase
    {
        private readonly IMovieApiService _movieApiService;

        public MovieGatewayController(IMovieApiService movieService)
        {
            _movieApiService = movieService;
        }
         
        [HttpPost("cinema-hall")]
        public async Task<IActionResult> AddCinemaHall([FromBody] CinemaHallCreateDto cinemaHallCreateDto)
        {
            var id = await _movieApiService.AddCinemaHallAsync(cinemaHallCreateDto);
            return Ok(new { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] MovieCreateDto movieCreateDto)
        {
            var id = await _movieApiService.AddMovieAsync(movieCreateDto);
            return Ok(new { Id = id });
        }
    }
}