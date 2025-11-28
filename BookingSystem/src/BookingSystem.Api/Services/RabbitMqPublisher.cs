using BookingSystem.Api.Dtos;
using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace BookingSystem.Api.Services;

public class RabbitMqPublisher : IRabbitMqPublisher
{
    public async Task AddAsync(NotificationCreateDto notificationCreateDto)
    {
        var factory = new ConnectionFactory()
        {
            HostName = Environment.GetEnvironmentVariable("RabbitMQ__Host") ?? "localhost",
            UserName = "guest",
            Password = "guest"
        };

        using IConnection connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: "notification.exchanges",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var message = JsonSerializer.Serialize(notificationCreateDto);
        var body = Encoding.UTF8.GetBytes(message);

        var basicProperties = new BasicProperties();
        await channel.BasicPublishAsync(
            exchange: "",
            routingKey: "notification.exchanges",
            basicProperties: basicProperties,
            mandatory: false,
            body: body
        );


        await Task.CompletedTask;
    }
}
