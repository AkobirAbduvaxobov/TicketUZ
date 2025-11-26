using Microsoft.EntityFrameworkCore;
using NotificationSystem.Api.Dtos;
using NotificationSystem.Api.Entities;
using NotificationSystem.Api.Persistense;

namespace NotificationSystem.Api.Services;

public class NotificationService : INotificationService
{
    private readonly AppDbContext _context;

    public NotificationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> CreateNotificationAsync(NotificationCreateDto notificationCreateDto)
    {
        var notification = new Notification
        {
            UserId = notificationCreateDto.UserId,
            Source = notificationCreateDto.Source,
            Type = notificationCreateDto.Type,
            Message = notificationCreateDto.Message,
            CreatedAt = DateTime.UtcNow,
            IsRead = false
        };
        await _context.Notifications.AddAsync(notification);
        await _context.SaveChangesAsync();

        return notification.NotificationId;
    }

    public async Task<List<NotificationGetDto>> GetAllNotificationsAsync()
    {
        var notifications = await _context.Notifications.ToListAsync();

        var notificationDtos = notifications.Select(n => new NotificationGetDto
        {
            NotificationId = n.NotificationId,
            UserId = n.UserId,
            Source = n.Source,
            Type = n.Type,
            Message = n.Message,
            CreatedAt = n.CreatedAt,
            IsRead = n.IsRead
        }).ToList();

        return notificationDtos;
    }

    public Task<NotificationGetDto?> GetNotificationByIdAsync(long notificationId)
    {
        throw new NotImplementedException();
    }
}
