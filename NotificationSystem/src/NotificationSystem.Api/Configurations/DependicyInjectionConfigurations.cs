
using NotificationSystem.Api.Services;

namespace NotificationSystem.Api.Configurations;

public static class DependicyInjectionConfigurations
{
    public static void ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<INotificationService, NotificationService>();
        builder.Services.AddHostedService<NotificationListenerService>();
    }
}
