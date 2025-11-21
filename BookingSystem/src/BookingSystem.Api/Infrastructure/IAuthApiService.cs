namespace BookingSystem.Api.Infrastructure;

public interface IAuthApiService
{
    public Task<bool> ValidateUser(long userId);
}