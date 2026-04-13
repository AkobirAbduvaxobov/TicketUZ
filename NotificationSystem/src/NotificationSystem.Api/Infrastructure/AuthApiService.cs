
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

        var raw = await response.Content.ReadAsStringAsync();
        return raw.Trim('"'); // handle both plain text and JSON string responses
    }

    public async Task<bool> ValidateUser(long userId)
    {
        var response = await _client.GetAsync($"api/users/exists/{userId}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<bool>();
    }
}
