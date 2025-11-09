using MovieSystem.Api.Dtos;

namespace MovieSystem.Api.Services;

public interface IMovieService
{
    Task<long> AddAsync(MovieCreateDto movieCreateDto);
    Task<MovieDto> GetByIdAsync(long movieId);
    Task<IEnumerable<MovieDto>> GetAllAsync();
    Task UpdateAsync(MovieUpdateDto movieUpdateDto);
    Task DeleteAsync(long movieId);
}