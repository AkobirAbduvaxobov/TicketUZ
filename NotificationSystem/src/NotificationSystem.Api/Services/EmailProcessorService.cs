using Microsoft.EntityFrameworkCore;
using NotificationSystem.Api.Infrastructure;
using NotificationSystem.Api.Persistense;

namespace NotificationSystem.Api.Services;

public class EmailProcessorService
{
    private readonly AppDbContext _db;
    private readonly IEmailSender _emailSender;
    private readonly IAuthApiService _authApiService;

    public EmailProcessorService(AppDbContext db, IEmailSender emailSender, IAuthApiService authApiService)
    {
        _db = db;
        _emailSender = emailSender;
        _authApiService = authApiService;
    }

    public async Task ProcessPendingEmailsAsync()
    {
        var pendingEmails = await _db.Notifications
            .Where(x => !x.IsRead)
            .ToListAsync();

        Console.WriteLine($"📧 EmailProcessor: found {pendingEmails.Count} pending emails");

        foreach (var email in pendingEmails)
        {
            try
            {
                Console.WriteLine($"📧 Fetching email for UserId: {email.UserId}");
                var receiverEmail = await _authApiService.GetEmailAsync(email.UserId);
                Console.WriteLine($"📧 Sending to: {receiverEmail}");
                await _emailSender.SendAsync(receiverEmail, $"{email.Source} : {email.Type}", email.Message);

                email.IsRead = true;
                await _db.SaveChangesAsync();
                Console.WriteLine($"✅ Email sent successfully to {receiverEmail}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Email failed: {ex.Message}");
                Console.WriteLine($"❌ Details: {ex.InnerException?.Message}");
            }
        }
    }
}
