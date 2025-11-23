namespace PaymentSystem.Api.Dtos;

public class PaymentCreateDto
{
    public long UserId { get; set; }
    public long BookingId { get; set; }
    public decimal Amount { get; set; }
}
