using AuthSystem.Api.Dtos;

namespace AuthSystem.Api.Services;

public interface IRabbitMqPublisher
{
    Task AddAsync(NotificationCreateDto notificationCreateDto);
}