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
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _appDbContext.Movies.AddAsync(movie);
        await _appDbContext.SaveChangesAsync();
        return movie.MovieId;
    }

    public async Task DeleteAsync(long movieId)
    {
        var movie = await _appDbContext.Movies.FirstOrDefaultAsync(m => m.MovieId == movieId);

        if (movie == null)
        {
            throw new Exception("Movie not found");
        }

        _appDbContext.Movies.Remove(movie);
        await _appDbContext.SaveChangesAsync();
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
            CreatedAt = m.CreatedAt,
            UpdatedAt = m.UpdatedAt
        });
    }

    public async Task<MovieDto> GetByIdAsync(long movieId)
    {
        var movie = await _appDbContext.Movies.FirstOrDefaultAsync(m => m.MovieId == movieId);

        if (movie == null)
        {
            throw new Exception("Movie not found");
        }

        return new MovieDto
        {
            MovieId = movie.MovieId,
            Title = movie.Title,
            Description = movie.Description,
            DurationMinutes = movie.DurationMinutes,
            Language = movie.Language,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate,
            Rating = movie.Rating,
            CreatedAt = movie.CreatedAt,
            UpdatedAt = movie.UpdatedAt
        };
    }

    public async Task UpdateAsync(MovieUpdateDto movieUpdateDto)
    {
        var movie = await _appDbContext.Movies.FirstOrDefaultAsync(m => m.MovieId == movieUpdateDto.MovieId);

        if (movie == null)
        {
            throw new Exception("Movie not found");
        }

        movie.Title = movieUpdateDto.Title;
        movie.Description = movieUpdateDto.Description;
        movie.DurationMinutes = movieUpdateDto.DurationMinutes;
        movie.Language = movieUpdateDto.Language;
        movie.Genre = movieUpdateDto.Genre;
        movie.ReleaseDate = movieUpdateDto.ReleaseDate;
        movie.Rating = movieUpdateDto.Rating;
        movie.UpdatedAt = DateTime.UtcNow;
        movie.CreatedAt = movieUpdateDto.CreatedAt;

        await _appDbContext.SaveChangesAsync();
    }
}
