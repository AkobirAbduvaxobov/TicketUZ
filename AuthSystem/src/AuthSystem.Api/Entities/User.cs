namespace AuthSystem.Api.Entities;

public class User
{
    public long UserId { get; set; }

    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }

    public string GoogleId { get; set; }
    public string GoogleProfilePicture { get; set; }
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; }
}
