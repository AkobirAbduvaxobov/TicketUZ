using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Api.Services;

namespace NotificationSystem.Api.Controllers;

[Route("api/notification")]
[ApiController]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService _notificationService;
    public NotificationsController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNotifications()
    {
        var notifications = await _notificationService.GetAllNotificationsAsync();
        return Ok(notifications);
    }
}
