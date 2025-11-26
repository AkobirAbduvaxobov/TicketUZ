namespace AuthSystem.Api.Dtos;

public class NotificationCreateDto
{
    public long UserId { get; set; }
    public string Source { get; set; }
    public string Type { get; set; }
    public string Message { get; set; }
}
