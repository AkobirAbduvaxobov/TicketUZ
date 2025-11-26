namespace AuthSystem.Api.Services;

public interface IUserService
{
    Task<bool> UserExistsAsync(long userId);
    Task<string> GetEmailAsync(long userId);
}