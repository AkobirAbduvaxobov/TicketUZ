using PaymentSystem.Api.Dtos;

namespace PaymentSystem.Api.Services;

public interface IRabbitMqPublisher
{
    Task AddAsync(NotificationCreateDto notificationCreateDto);
}