using APIGateway.Api.Dtos;

namespace APIGateway.Api.Services;

public interface INotificationService
{
    Task<long> AddAsync(NotificationCreateDto notificationCreateDto);
    Task<List<NotificationGetDto>> GetAllAsync(long userId);
}
