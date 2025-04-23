// EventProject.Application.Features.PartyIdeas.Commands/SendPartyIdeaCommandHandler.cs
using System.Threading;
using System.Threading.Tasks;
using EventProject.Application.Abstractions.Service;
using EventProject.Application.Features.Commands.SendPartyIdeaCommand;
using EventProject.Application.Features.PartyIdeas.Commands;
using MediatR;

namespace EventProject.Application.Features.PartyIdeas.Commands
{
    public class SendPartyIdeaCommandHandler : IRequestHandler<SendPartyIdeaRequest, bool>
    {
        private readonly IMailService _mailService;

        public SendPartyIdeaCommandHandler(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async Task<bool> Handle(SendPartyIdeaRequest request, CancellationToken cancellationToken)
        {
            // 1) Hamı HTML şablonu
            var template = @"<!DOCTYPE html>
<html lang=""en"">
<head>
  <meta charset=""UTF-8"">
  <title>New Party Idea Submission</title>
</head>
<body style=""margin:0; padding:0; background-color:#f4f4f4;"">
  <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""background-color:#f4f4f4; padding:20px 0;"">
    <tr>
      <td align=""center"">
        <table width=""600"" cellpadding=""0"" cellspacing=""0"" style=""background-color:#ffffff; border:1px solid #e0e0e0; border-radius:8px; overflow:hidden; font-family:Arial, sans-serif;"">
          <tr>
            <td style=""background-color:#007BFF; color:#ffffff; padding:20px; text-align:center; font-size:24px; font-weight:bold;"">
              Got an Idea? 🎉
            </td>
          </tr>
          <tr>
            <td style=""padding:20px; color:#333333; font-size:16px; line-height:1.5;"">
              <p style=""margin:0 0 16px;"">
                Salam <strong>Admin</strong>,
              </p>
              <p style=""margin:0 0 24px;"">
                Aşağıda yeni “Party Idea” formu vasitəsilə gələn məlumatlar:
              </p>
              <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse:collapse; margin-bottom:24px;"">
                <tr>
                  <td style=""width:150px; padding:8px 0; font-weight:bold; color:#555555;"">Full Name:</td>
                  <td style=""padding:8px 0; color:#333333;"">{{FullName}}</td>
                </tr>
                <tr style=""background-color:#f9f9f9;"">
                  <td style=""padding:8px 0; font-weight:bold; color:#555555;"">Email:</td>
                  <td style=""padding:8px 0; color:#333333;"">{{Email}}</td>
                </tr>
                <tr>
                  <td style=""padding:8px 0; font-weight:bold; color:#555555;"">Phone:</td>
                  <td style=""padding:8px 0; color:#333333;"">{{PhoneNumber}}</td>
                </tr>
                <tr style=""background-color:#f9f9f9;"">
                  <td style=""padding:8px 0; font-weight:bold; color:#555555;"">Guests:</td>
                  <td style=""padding:8px 0; color:#333333;"">{{EstimatedNumberOfGuests}}</td>
                </tr>
                <tr>
                  <td style=""padding:8px 0; font-weight:bold; color:#555555;"">Date:</td>
                  <td style=""padding:8px 0; color:#333333;"">{{Date}}</td>
                </tr>
                <tr style=""background-color:#f9f9f9;"">
                  <td style=""padding:8px 0; font-weight:bold; color:#555555;"">Venue:</td>
                  <td style=""padding:8px 0; color:#333333;"">{{Venue}}</td>
                </tr>
              </table>
              <h3 style=""margin:0 0 8px; color:#007BFF; font-size:18px;"">Description</h3>
              <p style=""margin:0; padding:12px; background-color:#f9f9f9; border-radius:4px; color:#333333; font-size:15px; line-height:1.6;"">
                {{Description}}
              </p>
            </td>
          </tr>
          <tr>
            <td style=""background-color:#f4f4f4; color:#777777; padding:12px 20px; font-size:12px; text-align:center;"">
              You received this email because someone submitted a party idea via your website.
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</body>
</html>";


            var htmlBody = template
                .Replace("{{FullName}}", request.FullName)
                .Replace("{{Email}}", request.Email)
                .Replace("{{PhoneNumber}}", request.PhoneNumber)
                .Replace("{{EstimatedNumberOfGuests}}", request.EstimatedNumberOfGuests.ToString())
                .Replace("{{Date}}", request.Date.ToString("dd/MM/yyyy"))
                .Replace("{{Venue}}", request.Venue)
                .Replace("{{Description}}", request.Description);


            var subject = $"[New Party Idea] PartyEventHub – {request.Date:dd/MM/yyyy}";

            try
            {
                await _mailService.SendEmailAsync(
                    recipients: new[] { "miri976y@gmail.com" },
                    subject: subject,
                    body: htmlBody,
                    fromEmail: request.Email,
                    fromName: request.FullName,
                    isBodyHtml: true);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
