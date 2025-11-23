namespace PaymentSystem.Api.Dtos;

public class PaymentResultDto
{
    public long PaymentId { get; set; }
    public long BookingId { get; set; }
    public PaymentStatus Status { get; set; }
    public DateTime ProcessedAt { get; set; }
}


public enum PaymentStatus
{
    Pending = 0,
    Success = 1,
    Failed = 2
}