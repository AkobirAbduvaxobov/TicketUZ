using BookingSystem.Api.Dtos;

namespace BookingSystem.Api.Services;

public interface IRabbitMqPublisher
{
    Task AddAsync(NotificationCreateDto notificationCreateDto);
}