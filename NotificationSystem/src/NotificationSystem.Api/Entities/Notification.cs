namespace NotificationSystem.Api.Entities;

public class Notification
{
    public long NotificationId { get; set; }
    public long UserId { get; set; }
    public string Source { get; set; } 
    public string Type { get; set; } 
    public string Message { get; set; } 
    public DateTime CreatedAt { get; set; } 
    public bool IsRead { get; set; } 
}

