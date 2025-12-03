
namespace BookingSystem.Api.Infrastructure;

public class AuthApiService : IAuthApiService
{
    private readonly HttpClient _client;

    public AuthApiService(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("AuthSystem");
    }
    public async Task<bool> ValidateUser(long userId)
    {
        var response = await _client.GetAsync($"api/users/exists/{userId}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<bool>();
    }
}
