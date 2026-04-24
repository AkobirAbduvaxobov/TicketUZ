using AuthSystem.Api.Entities;
using AuthSystem.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Api.Persistense;

public static class SeedData
{
    public static async Task SeedAsync(AppDbContext db)
    {
        // Only seed if DB is empty
        if (await db.Users.AnyAsync()) return;

        var (hash, salt) = PasswordHasher.Hasher("Admin123!");

        var admin = new User
        {
            UserName = "admin",
            FirstName = "Super",
            LastName = "Admin",
            Email = "akobirabduvahobov@gmail.com",
            EmailConfirmed = true,
            PasswordHash = hash,
            Salt = salt,
            GoogleId = string.Empty,
            GoogleProfilePicture = string.Empty,
            Role = UserRole.Admin,
            CreatedAt = DateTime.UtcNow
        };

        await db.Users.AddAsync(admin);
        await db.SaveChangesAsync();

        Console.WriteLine("✅ Default admin seeded → admin@ticketuz.com / Admin123!");
    }
}
