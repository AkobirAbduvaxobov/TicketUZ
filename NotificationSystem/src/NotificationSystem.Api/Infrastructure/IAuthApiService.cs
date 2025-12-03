namespace NotificationSystem.Api.Infrastructure;

public interface IAuthApiService
{
    public Task<bool> ValidateUser(long userId);
    public Task<string> GetEmailAsync(long userId);
}