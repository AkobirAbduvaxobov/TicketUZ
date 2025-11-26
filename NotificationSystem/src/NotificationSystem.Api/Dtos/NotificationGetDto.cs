namespace NotificationSystem.Api.Dtos;

public class NotificationGetDto
{
    public long NotificationId { get; set; }
    public long UserId { get; set; }
    public string Source { get; set; }
    public string Type { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsRead { get; set; }
}
