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

    [HttpGet("exists/{userId}")]
    public async Task<bool> UserExistsAsync(long userId)
    {
        return await UserService.UserExistsAsync(userId);
    }

}
