namespace PaymentSystem.Api.Entities;

public class Payment
{
    public long PaymentId { get; set; }
    public long UserId { get; set; }
    public long BookingId { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}


public enum PaymentStatus
{
    Pending = 0,
    Success = 1,
    Failed = 2
}