using AuthSystem.Api.Dtos;
using AuthSystem.Api.Entities;

namespace AuthSystem.Api.Services;

public interface IUserService
{
    Task<bool> UserExistsAsync(long userId);
    Task<string> GetEmailAsync(long userId);
    Task SetRoleAsync(long userId, UserRole role);
    Task<List<UserTokenDto>> GetAllUsersAsync();
}