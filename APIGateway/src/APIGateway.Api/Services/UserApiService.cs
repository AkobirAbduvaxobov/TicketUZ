using APIGateway.Api.Dtos;

namespace APIGateway.Api.Services;

public class UserApiService : IUserApiService
{
    private readonly HttpClient _client;

    public UserApiService(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("AuthSystem");
    }

    public async Task<LoginResponseDto> LoginUserAsync(LoginDto loginDto)
    {
        var response = await _client.PostAsJsonAsync("api/auth/login", loginDto);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<LoginResponseDto>()
               ?? throw new InvalidOperationException("Invalid response from auth service");
    }

    public async Task<long> RegisterUserAsync(RegisterDto registerDto)
    {
        var response = await _client.PostAsJsonAsync("api/auth/register", registerDto);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<long>();
    }
}
