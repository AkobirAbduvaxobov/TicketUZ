using BookingSystem.Api.Infrastructure;
using BookingSystem.Api.Services;

namespace BookingSystem.Api.Configurations;

public static class DependicyInjectionConfigurations
{
    public static void ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMovieApiService, MovieApiService>();
        builder.Services.AddScoped<IAuthApiService, AuthApiService>();
        builder.Services.AddScoped<IPaymentApiService, PaymentApiService>();
        builder.Services.AddScoped<IBookingService, BookingService>();
    }
}
