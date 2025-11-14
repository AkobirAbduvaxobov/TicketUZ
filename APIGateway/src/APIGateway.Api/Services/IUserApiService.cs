using APIGateway.Api.Dtos;

namespace APIGateway.Api.Services;

public interface IUserApiService
{
    Task<long> RegisterUserAsync(RegisterDto registerDto);
    Task<LoginResponseDto> LoginUserAsync(LoginDto login);
}
