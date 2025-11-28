using PaymentSystem.Api.Services;
using PaymentSystem.Api.Dtos;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Api.Dtos;
using PaymentSystem.Api.Entities;
using PaymentSystem.Api.Persistense;

namespace PaymentSystem.Api.Services;

public class PaymentService : IPaymentService
{
    private readonly AppDbContext _context;
    private readonly Random _random = new();
    private readonly IRabbitMqPublisher _rabbitMqPublisher;

    public PaymentService(AppDbContext context, IRabbitMqPublisher rabbitMqPublisher)
    {
        _context = context;
        _rabbitMqPublisher = rabbitMqPublisher;
    }

    public async Task<PaymentResultDto> ProcessPaymentAsync(PaymentCreateDto dto)
    {
        bool isSuccess = _random.Next(1, 101) <= 70;

        var payment = new Payment
        {
            UserId = dto.UserId,
            BookingId = dto.BookingId,
            Amount = dto.Amount,
            Status = isSuccess ? PaymentStatus.Success : PaymentStatus.Failed,
            CreatedAt = DateTime.UtcNow
        };

        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();

        var notificationCreateDto = new NotificationCreateDto()
        {
            UserId = dto.UserId,
            Source = "PaymentSystem",
            Type = "ProcessPayment",
            Message = $"Payment was successfully",
        };

        if(!isSuccess)
        {
            notificationCreateDto.Message = "Payment failed";
        }

        await _rabbitMqPublisher.AddAsync(notificationCreateDto);

        return new PaymentResultDto
        {
            UserId = payment.UserId,
            PaymentId = payment.PaymentId,
            BookingId = payment.BookingId,
            Status = payment.Status,
            ProcessedAt = payment.CreatedAt
        };
    }

    public async Task<PaymentResultDto> GetPaymentAsync(long paymentId)
    {
        var payment = await _context.Payments.FindAsync(paymentId);

        if (payment == null)
            throw new Exception("Payment not found.");

        return new PaymentResultDto
        {
            UserId = payment.UserId,
            PaymentId = payment.PaymentId,
            BookingId = payment.BookingId,
            Status = payment.Status,
            ProcessedAt = payment.CreatedAt
        };
    }

    public async Task<List<PaymentResultDto>> GetAllPaymentsAsync()
    {
        return await _context.Payments
            .Select(payment => new PaymentResultDto
            {
                UserId = payment.UserId,
                PaymentId = payment.PaymentId,
                BookingId = payment.BookingId,
                Status = payment.Status,
                ProcessedAt = payment.CreatedAt
            })
            .ToListAsync();
    }
}
