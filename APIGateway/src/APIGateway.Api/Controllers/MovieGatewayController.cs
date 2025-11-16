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

        public MovieGatewayController(IMovieApiService movieApiService)
        {
            _movieApiService = movieApiService;
        }

        [HttpGet("/CinemaHall")]
        public async Task<List<CinemaHallDto>> GetCinemaHalls()
        {
            var cinemaHalls = await _movieApiService.GetAllCinemaHallsAsync();
            return cinemaHalls;
        }

        [HttpGet("/Movies")]
        public async Task<List<MovieDto>> GetMovies()
        {
            var movies = await _movieApiService.GetAllMoviesAsync();
            return movies;
        }
    }
}
