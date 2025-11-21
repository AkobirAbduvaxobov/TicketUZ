using APIGateway.Api.Services;

namespace APIGateway.Api.Configurations;

public static class DependicyInjectionConfigurations
{
    public static IServiceCollection ConfigureDI(this IServiceCollection services)
    {
        services.AddScoped<IMovieApiService, MovieApiService>();
        services.AddScoped<IUserApiService, UserApiService>();
        services.AddScoped<IBookingApiService, BookingApiService>();

        return services;
    }
}
