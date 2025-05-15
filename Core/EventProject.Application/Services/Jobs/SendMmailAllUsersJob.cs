using EventProject.Application.Abstractions.Jobs;
using EventProject.Application.Abstractions.Service;
using EventProject.Application.Repositories.Events;
using EventProject.Application.Repositories.Users;

namespace EventProject.Application.Services.Jobs;

public class SendMmailAllUsersJob: ISendMailAllUsersJob
{
    private readonly IUserReadRepsoitory _userReadRepsoitory;
    private readonly IEventReadRepository _eventReadRepository;
    private readonly IMailService _mailService;
    public SendMmailAllUsersJob(IUserReadRepsoitory userReadRepsoitory ,IEventReadRepository readRepository, IMailService mailService)
    {
        _eventReadRepository=readRepository;
        _userReadRepsoitory= userReadRepsoitory;
        _mailService = mailService;
    }
    public async Task SendMailAllUsers()
    {
        var allEmails = _userReadRepsoitory
            .GetWhere(u => u.IsDeleted != true && u.Email != null)
            .Select(u => u.Email)
            .ToList();

        var allEvents = _eventReadRepository
            .GetWhere(e => e.IsDeleted != true)
            .ToList();

        var random = new Random();

        foreach (var userEmail in allEmails)
        {
            var eventToSend = allEvents[random.Next(allEvents.Count)];
            Console.WriteLine(userEmail);
            var randomImage = eventToSend.MediaFiles.Select(f=>f.FileName).ToList() != null && eventToSend.MediaFiles.Select(f=>f.FileName).Any()
                ? eventToSend.MediaFiles.Select(f=>f.FileName).OrderBy(x => Guid.NewGuid()).FirstOrDefault()
                : "https://placehold.co/600x300?text=PartyHub+Event";

            var template = @"<!DOCTYPE html>
<html lang=""en"">
<head>
  <meta charset=""UTF-8"">
  <title>Event Notification</title>
</head>
<body style=""margin:0; padding:0; background-color:#f4f4f4;"">
  <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""padding:20px 0;"">
    <tr>
      <td align=""center"">
        <table width=""600"" cellpadding=""0"" cellspacing=""0"" style=""background-color:#ffffff; border-radius:8px; font-family:Arial, sans-serif; overflow:hidden;"">
          <tr>
            <td style=""background-color:#4CAF50; color:white; text-align:center; padding:20px; font-size:24px;"">
              🎉 Yeni Event-lərdən xəbərdar olun!
            </td>
          </tr>
          <tr>
            <td style=""padding:20px; color:#333;"">
              <p>Salam,</p>
              <p>Sizə maraqlı ola biləcək yeni tədbirlərlə tanış olun:</p>
              <h2 style=""color:#4CAF50;"">{{EventName}}</h2>
              <p style=""font-size:15px;"">{{EventDescription}}</p>
              <img src=""{{ImageUrl}}"" alt=""Event Image"" style=""width:100%; max-height:300px; object-fit:cover; border-radius:8px; margin-top:15px;"">
              <p style=""margin-top:20px;"">Əlavə tədbirlərlə tanış olmaq üçün saytımıza daxil olun!</p>
              <a href=""https://partyhub.az/events"" style=""background-color:#4CAF50; color:white; padding:10px 20px; text-decoration:none; border-radius:4px;"">Sayta keçid et</a>
            </td>
          </tr>
          <tr>
            <td style=""background-color:#f0f0f0; padding:10px; text-align:center; font-size:12px; color:#777;"">
              Bu e-mail siz PartyHub istifadəçisi olduğunuz üçün göndərilib.
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</body>
</html>
";
            var htmlBody = template
                .Replace("{{EventName}}", eventToSend.Title)
                .Replace("{{EventDescription}}", eventToSend.Description)
                .Replace("{{ImageUrl}}", randomImage);

            await _mailService.SendEmailAsync(
                recipients: new[] { userEmail },
                subject: $"Yeni Event: {eventToSend.Title}",
                body: htmlBody,
                fromEmail: "eventpartyhub@gmail.com",
                fromName: "PartyHub",
                isBodyHtml: true);
        }
    }

}

