using PaymentSystem.Api.Entities;

namespace PaymentSystem.Api.Dtos;

public class PaymentResultDto
{
    public long PaymentId { get; set; }
    public long UserId { get; set; }
    public long BookingId { get; set; }
    public PaymentStatus Status { get; set; }
    public DateTime ProcessedAt { get; set; }
}
