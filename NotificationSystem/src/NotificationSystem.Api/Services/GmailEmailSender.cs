using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace NotificationSystem.Api.Services;

public class GmailEmailSender : IEmailSender
{
    private readonly string _fromEmail = "akobirazizjonugli@gmail.com";
    private readonly string _appPassword = "parol yours";

    public async Task SendAsync(string to, string subject, string body)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_fromEmail));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart("plain") { Text = body };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_fromEmail, _appPassword);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}