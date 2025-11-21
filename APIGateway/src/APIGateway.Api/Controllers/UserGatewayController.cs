using APIGateway.Api.Dtos;
using APIGateway.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Api.Controllers;

[Route("api/gateway/authsystem")]
[ApiController]
public class UserGatewayController : ControllerBase
{
    private readonly IUserApiService _userApiService;

    public UserGatewayController(IUserApiService userApiService)
    {
        _userApiService = userApiService;
    }

    [HttpPost("auth/register")]
    public async Task<long> Register([FromBody] RegisterDto registerDto)
    {
        var result = await _userApiService.RegisterUserAsync(registerDto);
        return result;
    }

    [HttpPost("auth/login")]
    public async Task<LoginResponseDto> Login([FromBody] LoginDto loginDto)
    {
        var result = await _userApiService.LoginUserAsync(loginDto);
        return result;
    }
}
