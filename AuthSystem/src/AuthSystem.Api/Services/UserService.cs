using AuthSystem.Api.Dtos;
using AuthSystem.Api.Entities;
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

    public async Task<List<UserTokenDto>> GetAllUsersAsync()
    {
        var users = await _context.Users.ToListAsync();

        var result = users.Select(user => new UserTokenDto
        {
            UserId = user.UserId,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role
        }).ToList();

        return result;
    }

    public async Task<string> GetEmailAsync(long userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if(user == null)
        {
            throw new Exception("User not fount");
        }

        return user.Email;
    }

    public async Task SetRoleAsync(long userId, UserRole role)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
        {
            throw new Exception("User not fount");
        }

        user.Role = role;
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UserExistsAsync(long userId)
    {
        return await _context.Users.AnyAsync(u => u.UserId == userId);
    }
}
