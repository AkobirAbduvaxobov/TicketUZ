using APIGateway.Api.Dtos;

namespace APIGateway.Api.Services;

public class NotificationService : INotificationService
{
    private readonly HttpClient _httpClient;
    public NotificationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<long> AddAsync(NotificationCreateDto notificationCreateDto)
    {
        throw new NotImplementedException();
    }

    public async Task<List<NotificationGetDto>> GetAllAsync(long userId)
    {
        throw new NotImplementedException();
    }
}
