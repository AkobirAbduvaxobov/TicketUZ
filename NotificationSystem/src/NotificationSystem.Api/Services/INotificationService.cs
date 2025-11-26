using NotificationSystem.Api.Dtos;
using NotificationSystem.Api.Entities;

namespace NotificationSystem.Api.Services;

public interface INotificationService
{
    Task<long> CreateNotificationAsync(NotificationCreateDto notificationCreateDto);
    Task<NotificationGetDto?> GetNotificationByIdAsync(long notificationId);
    Task<List<NotificationGetDto>> GetAllNotificationsAsync();
}