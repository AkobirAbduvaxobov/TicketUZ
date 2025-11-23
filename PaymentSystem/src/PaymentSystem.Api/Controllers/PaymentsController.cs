using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Api.Dtos;
using PaymentSystem.Api.Services;

[ApiController]
[Route("api/payments")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<ActionResult<PaymentResultDto>> Create(PaymentCreateDto dto)
    {
        var result = await _paymentService.ProcessPaymentAsync(dto);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentResultDto>> Get(long id)
    {
        var result = await _paymentService.GetPaymentAsync(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<PaymentResultDto>>> GetAll()
    {
        var results = await _paymentService.GetAllPaymentsAsync();
        return Ok(results);
    }
}
