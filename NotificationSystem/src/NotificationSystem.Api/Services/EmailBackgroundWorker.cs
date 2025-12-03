namespace NotificationSystem.Api.Services;

public class EmailBackgroundWorker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public EmailBackgroundWorker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var processor = scope.ServiceProvider.GetRequiredService<EmailProcessorService>();

            await processor.ProcessPendingEmailsAsync();

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}

