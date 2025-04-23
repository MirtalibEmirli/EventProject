using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EventProject.Application.Abstractions.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EventProject.Infrastructure.Services;

public class MailSettings
{
    public string Host { get; set; } = null!;
    public int Port { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool EnableSsl { get; set; } = true;
}

public class MailService : IMailService
{
    private readonly MailSettings _settings;

    public MailService(IOptions<MailSettings> options)
    {
        _settings = options.Value;
    }

    public async Task SendEmailAsync(
        IEnumerable<string> recipients,
        string subject,
        string body,
        string? fromEmail = null,
        string? fromName = null,
        bool isBodyHtml = true)
    {
        var fromAddress = fromEmail != null
            ? new MailAddress(fromEmail, fromName ?? fromEmail, Encoding.UTF8)
            : new MailAddress(_settings.Username, "Party Event Hub", Encoding.UTF8);

        using var mail = new MailMessage()
        {
            From = fromAddress,
            Subject = subject,
            SubjectEncoding = Encoding.UTF8,
            Body = body,
            BodyEncoding = Encoding.UTF8,
            IsBodyHtml = isBodyHtml
        };
        foreach (var to in recipients)
            mail.To.Add(to);

        using var smtp = new SmtpClient(_settings.Host, _settings.Port)
        {
            Credentials = new NetworkCredential(_settings.Username, _settings.Password),
            EnableSsl = _settings.EnableSsl
        };

        await smtp.SendMailAsync(mail);
    }
}