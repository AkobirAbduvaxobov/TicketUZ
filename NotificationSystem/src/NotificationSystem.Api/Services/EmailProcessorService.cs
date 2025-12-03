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

        foreach (var email in pendingEmails)
        {
            try
            {
                var receiverEmail = await _authApiService.GetEmailAsync(email.UserId);
                await _emailSender.SendAsync(receiverEmail, $"{email.Source} : {email.Type}", email.Message);

                email.IsRead = true;
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // You can log error here
            }
        }
    }
}
