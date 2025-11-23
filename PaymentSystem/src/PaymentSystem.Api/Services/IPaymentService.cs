using PaymentSystem.Api.Dtos;

namespace PaymentSystem.Api.Services
{
    public interface IPaymentService
    {
        Task<PaymentResultDto> ProcessPaymentAsync(PaymentCreateDto dto);
        Task<PaymentResultDto> GetPaymentAsync(long paymentId);
        Task<List<PaymentResultDto>> GetAllPaymentsAsync();
    }
}