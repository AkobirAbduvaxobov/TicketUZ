using AuthSystem.Api.Persistense;
using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Api.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<bool> UserExistsAsync(long userId)
    {
        return await _context.Users.AnyAsync(u => u.UserId == userId);
    }
}
