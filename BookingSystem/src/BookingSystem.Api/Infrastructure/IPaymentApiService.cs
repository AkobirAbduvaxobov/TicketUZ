using BookingSystem.Api.Dtos;
using PaymentSystem.Api.Dtos;

namespace BookingSystem.Api.Infrastructure;

public interface IPaymentApiService
{
    Task<PaymentResultDto> ProcessPaymentAsync(PaymentCreateDto dto);
    Task<PaymentResultDto> GetPaymentAsync(long paymentId);
}