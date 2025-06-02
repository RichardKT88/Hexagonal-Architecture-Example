using Hex.Arc.Core.Ports;
using Hex.Arch.Infrastructure.External.Settings;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Hex.Arch.Infrastructure.External;

public class SmtpNotificationService : INotificationService
{
    private readonly SmtpSettings _settings;

    public SmtpNotificationService(IOptions<SmtpSettings> options)
    {
        _settings = options.Value; 
    }

    public async Task SendTransferNotification(string message, string recipient)
    {
        using var client = new SmtpClient(_settings.Server, _settings.Port)
        {
            Credentials = new NetworkCredential(_settings.Username, _settings.Password),
            EnableSsl = true
        };

        var mailMessage = new MailMessage(
            from: _settings.FromEmail,
            to: recipient,
            subject: "Banking Notification",
            body: message
        );

        await client.SendMailAsync(mailMessage);
    }
}
