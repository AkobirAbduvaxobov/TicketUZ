namespace NotificationSystem.Api.Configurations;

public static class HttpClientExtensions
{
    public static IServiceCollection RegisterHttpClientServices(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceSettings = configuration.GetSection("Services");

        services.AddHttpClient("AuthSystem", c =>
        {
            c.BaseAddress = new Uri(serviceSettings["AuthSystem"]);
        });

        return services;
    }
}
