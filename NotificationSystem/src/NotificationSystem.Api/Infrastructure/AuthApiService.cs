
namespace NotificationSystem.Api.Infrastructure;

public class AuthApiService : IAuthApiService
{
    private readonly HttpClient _client;

    public AuthApiService(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("AuthSystem");
    }

    public async Task<string> GetEmailAsync(long userId)
    {
        var response = await _client.GetAsync($"api/users/email/{userId}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<string>();
    }

    public async Task<bool> ValidateUser(long userId)
    {
        var response = await _client.GetAsync($"api/users/exists/{userId}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<bool>();
    }
}
