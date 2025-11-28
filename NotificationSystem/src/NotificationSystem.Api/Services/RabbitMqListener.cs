using NotificationSystem.Api.Dtos;
using NotificationSystem.Api.Entities;
using NotificationSystem.Api.Persistense;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace NotificationSystem.Api.Services;

public class NotificationListenerService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public NotificationListenerService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory()
        {
            HostName = Environment.GetEnvironmentVariable("RabbitMQ__Host") ?? "localhost",
            UserName = "guest",
            Password = "guest"
        };

        var connection = await factory.CreateConnectionAsync();
        var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: "notification.exchanges",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var data = JsonSerializer.Deserialize<NotificationCreateDto>(message);

                var notification = new Notification
                {
                    UserId = data.UserId,
                    Message = data.Message,
                    Type = data.Type,
                    Source = data.Source,
                    CreatedAt = DateTime.UtcNow,
                    IsRead = false
                };

                if (data != null)
                {
                    await db.Notifications.AddAsync(notification);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }

            await channel.BasicAckAsync(ea.DeliveryTag, false);
        };

        await channel.BasicConsumeAsync(
            queue: "notification.exchanges",
            autoAck: false,
            consumer: consumer
        );

        Console.WriteLine("📩 NotificationService listening → notification.exchanges");

        await Task.Delay(Timeout.Infinite, stoppingToken);
    }
}


