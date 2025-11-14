using APIGateway.Api.Dtos;

namespace APIGateway.Api.Services;

public class UserApiService : IUserApiService
{
    private readonly HttpClient _httpClient;

    public UserApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResponseDto> LoginUserAsync(LoginDto loginDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginDto);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<LoginResponseDto>()
               ?? throw new InvalidOperationException("Invalid response from auth service");
    }

    public async Task<long> RegisterUserAsync(RegisterDto registerDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/register", registerDto);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<long>();
    }
}
