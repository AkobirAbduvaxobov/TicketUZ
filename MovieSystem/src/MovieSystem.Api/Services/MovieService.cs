using Microsoft.EntityFrameworkCore;
using MovieSystem.Api.Dtos;
using MovieSystem.Api.Entities;
using MovieSystem.Api.Persistense;

namespace MovieSystem.Api.Services;

public class MovieService : IMovieService
{
    private readonly AppDbContext _appDbContext;

    public MovieService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<long> AddAsync(MovieCreateDto movieCreateDto)
    {
        var movie = new Movie
        {
            Title = movieCreateDto.Title,
            Description = movieCreateDto.Description,
            DurationMinutes = movieCreateDto.DurationMinutes,
            Language = movieCreateDto.Language,
            Genre = movieCreateDto.Genre,
            ReleaseDate = movieCreateDto.ReleaseDate ?? DateTime.UtcNow,
            Rating = movieCreateDto.Rating ?? 0,
            IsActive = movieCreateDto.IsActive,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _appDbContext.Movies.AddAsync(movie);
        await _appDbContext.SaveChangesAsync();
        return movie.MovieId;
    }

    public Task DeleteAsync(long movieId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<MovieDto>> GetAllAsync()
    {
        var movies = await _appDbContext.Movies.ToListAsync();

        return movies.Select(m => new MovieDto
        {
            MovieId = m.MovieId,
            Title = m.Title,
            Description = m.Description,
            DurationMinutes = m.DurationMinutes,
            Language = m.Language,
            Genre = m.Genre,
            ReleaseDate = m.ReleaseDate,
            Rating = m.Rating,
            IsActive = m.IsActive,
            CreatedAt = m.CreatedAt,
            UpdatedAt = m.UpdatedAt
        });
    }

    public Task<MovieDto> GetByIdAsync(long movieId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(MovieUpdateDto movieUpdateDto)
    {
        throw new NotImplementedException();
    }
}
