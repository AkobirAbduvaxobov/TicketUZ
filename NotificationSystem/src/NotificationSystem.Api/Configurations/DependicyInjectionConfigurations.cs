
using NotificationSystem.Api.Infrastructure;
using NotificationSystem.Api.Services;

namespace NotificationSystem.Api.Configurations;

public static class DependicyInjectionConfigurations
{
    public static void ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<INotificationService, NotificationService>();
        builder.Services.AddHostedService<NotificationListenerService>();

        builder.Services.AddScoped<IAuthApiService, AuthApiService>();
        builder.Services.AddScoped<IEmailSender, GmailEmailSender>();
        builder.Services.AddScoped<EmailProcessorService>();

        // Background worker (optional)
        builder.Services.AddHostedService<EmailBackgroundWorker>();

        builder.Services.RegisterHttpClientServices(builder.Configuration);
    }
}
