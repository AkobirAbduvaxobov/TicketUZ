namespace APIGateway.Api.Dtos;

public class NotificationCreateDto
{
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
}
