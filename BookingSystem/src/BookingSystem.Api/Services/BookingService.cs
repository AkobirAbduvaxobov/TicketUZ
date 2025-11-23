using BookingSystem.Api.Dtos;
using BookingSystem.Api.Entities;
using BookingSystem.Api.Infrastructure;
using BookingSystem.Api.Persistense;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Api.Dtos;

namespace BookingSystem.Api.Services;

public class BookingService : IBookingService
{
    private readonly AppDbContext _appDbContext;
    private readonly IAuthApiService _authApiService;
    private readonly IMovieApiService _movieApiService;
    private readonly IPaymentApiService _paymentApiService;

    public BookingService(AppDbContext appDbContext, IAuthApiService authApiService, IMovieApiService movieApiService, IPaymentApiService paymentApiService)
    {
        _appDbContext = appDbContext;
        _authApiService = authApiService;
        _movieApiService = movieApiService;
        _paymentApiService = paymentApiService;
    }

    public async Task<long> AddAsync(BookingCreateDto bookingCreateDto)
    {

        var userExists = await _authApiService.ValidateUser(bookingCreateDto.UserId);
        var validShowtime = await _movieApiService.ValidateShowtime(bookingCreateDto.ShowtimeId, bookingCreateDto.SeatId, bookingCreateDto.TotalPrice);

        if (!userExists)
        {
            throw new ArgumentException($"User with id {bookingCreateDto.UserId} does not exist.");
        }

        if (!validShowtime)
        {
            throw new ArgumentException($"Showtime with id {bookingCreateDto.ShowtimeId} and seat id {bookingCreateDto.SeatId} is not valid.");
        }

        var booking = new Booking
        {
            UserId = bookingCreateDto.UserId,
            ShowtimeId = bookingCreateDto.ShowtimeId,
            TotalPrice = bookingCreateDto.TotalPrice,
            SeatId = bookingCreateDto.SeatId,
            BookingDate = DateTime.UtcNow,
            Status = BookingStatus.Pending
        };

        await _appDbContext.Bookings.AddAsync(booking);
        await _appDbContext.SaveChangesAsync();


        var paymentResult = await _paymentApiService.ProcessPaymentAsync(new PaymentCreateDto
        {
            BookingId = booking.BookingId,
            UserId = booking.UserId,
            Amount = booking.TotalPrice
        });


        if (paymentResult.Status == PaymentStatus.Failed)
        {
            booking.Status = BookingStatus.Cancelled;
            //await _seatRepository.ReleaseSeatAsync(booking.SeatId, booking.ShowtimeId);
            await _appDbContext.SaveChangesAsync();

            throw new Exception("Payment failed.");
        }

        // 6. Payment success → CONFIRM booking
        booking.Status = BookingStatus.Confirmed;
        await _appDbContext.SaveChangesAsync();

        // 7. Publish event to RabbitMQ
        //await _eventPublisher.PublishBookingConfirmed(booking);


        return booking.BookingId;
    }

    public async Task DeleteAsync(long id)
    {
        var booking = await _appDbContext.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
        if(booking == null)
        {
            throw new KeyNotFoundException($"Booking with id {id} not found.");
        }

        _appDbContext.Bookings.Remove(booking);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<BookingGetDto>> GetAllAsync()
    {
        var bookings = await _appDbContext.Bookings.ToListAsync();

        var bookingsDto = bookings.Select(b => new BookingGetDto
        {
            BookingId = b.BookingId,
            UserId = b.UserId,
            ShowtimeId = b.ShowtimeId,
            TotalPrice = b.TotalPrice,
            SeatId = b.SeatId,
            BookingDate = b.BookingDate,
            Status = b.Status
        }).ToList();

        return bookingsDto;
    }

    public async Task<BookingGetDto> GetByIdAsync(long id)
    {
        var booking = await _appDbContext.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
        if (booking == null)
        {
            throw new KeyNotFoundException($"Booking with id {id} not found.");
        }

        var bookingDto = new BookingGetDto
        {
            BookingId = booking.BookingId,
            UserId = booking.UserId,
            ShowtimeId = booking.ShowtimeId,
            TotalPrice = booking.TotalPrice,
            SeatId = booking.SeatId,
            BookingDate = booking.BookingDate,
            Status = booking.Status
        };

        return bookingDto;
    }
}
