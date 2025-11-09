
using MovieSystem.Api.Services;

namespace MovieSystem.Api.Configurations;

public static class DependicyInjectionConfigurations
{
    public static void ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMovieService, Services.MovieService>();
        builder.Services.AddScoped<IShowtimeService, ShowtimeService>();
        builder.Services.AddScoped<ICinemaHallService, CinemaHallService>();
    } 
}
