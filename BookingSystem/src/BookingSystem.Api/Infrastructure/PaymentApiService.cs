using BookingSystem.Api.Dtos;
using PaymentSystem.Api.Dtos;

namespace BookingSystem.Api.Infrastructure;

public class PaymentApiService : IPaymentApiService
{
    private readonly HttpClient _client;

    public PaymentApiService(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("PaymentSystem");
    }

    public async Task<PaymentResultDto> GetPaymentAsync(long paymentId)
    {
        var response = await _client.GetAsync($"api/payments/{paymentId}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<PaymentResultDto>() ?? new PaymentResultDto();
    }

    public async Task<PaymentResultDto> ProcessPaymentAsync(PaymentCreateDto dto)
    {
        var response = await _client.PostAsJsonAsync("api/payments", dto);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<PaymentResultDto>() ?? new PaymentResultDto();
    }
}
