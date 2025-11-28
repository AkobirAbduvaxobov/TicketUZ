using AuthSystem.Api.Dtos;
using AuthSystem.Api.Entities;
using AuthSystem.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthSystem.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService UserService;

    public UsersController(IUserService userService)
    {
        UserService = userService;
    }

    [HttpPut("{userId}/role")]
    public async Task SetRoleAsync(long userId, UserRole role)
    {
        await UserService.SetRoleAsync(userId, role);
    }

    [HttpGet("exists/{userId}")]
    public async Task<bool> UserExistsAsync(long userId)
    {
        return await UserService.UserExistsAsync(userId);
    }

    [HttpGet("email/{userId}")]
    public async Task<string> GetEmailAsync(long userId)
    {
        return await UserService.GetEmailAsync(userId);
    }

    [HttpGet]
    public async Task<List<UserTokenDto>> GetUsersAsync(long userId)
    {
        return await UserService.GetAllUsersAsync();
    }


}
