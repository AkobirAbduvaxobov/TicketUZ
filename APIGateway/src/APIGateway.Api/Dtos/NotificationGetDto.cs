namespace APIGateway.Api.Dtos;

public class NotificationGetDto
{
    public long NotificationId { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; }
}
