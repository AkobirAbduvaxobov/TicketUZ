using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.Api.Configurations;

public static class HttpClientExtensions
{
    public static IServiceCollection RegisterHttpClientServices(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceSettings = configuration.GetSection("Services");

        services.AddHttpClient("AuthSystem", c =>
        {
            c.BaseAddress = new Uri(serviceSettings["AuthSystem"]);
        });

        services.AddHttpClient("MovieSystem", c =>
        {
            c.BaseAddress = new Uri(serviceSettings["MovieSystem"]);
        });

        services.AddHttpClient("PaymentSystem", c =>
        {
            c.BaseAddress = new Uri(serviceSettings["PaymentSystem"]);
        });

        services.AddHttpClient("NotificationSystem", c =>
        {
            c.BaseAddress = new Uri(serviceSettings["NotificationSystem"]);
        });

        return services;
    }
}

