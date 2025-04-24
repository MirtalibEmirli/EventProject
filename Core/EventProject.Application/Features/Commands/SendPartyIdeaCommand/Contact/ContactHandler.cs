using EventProject.Application.Abstractions.Service;
using EventProject.Application.ResponseModels;
using MediatR;

namespace EventProject.Application.Features.Commands.SendPartyIdeaCommand.Contact;
public record ContactUsCommand(string firstName, string lastName, string phone, string email) : IRequest<BaseResponseModel> { }

public class ContactHandler(IMailService mailService) : IRequestHandler<ContactUsCommand, BaseResponseModel>
{
    private readonly IMailService _mailService = mailService;
    public async Task<BaseResponseModel> Handle(ContactUsCommand request, CancellationToken cancellationToken)
    {
        var template = @"<!DOCTYPE html>
<html lang=""en"">
  <head>
    <meta charset=""UTF-8"" />
    <title>Contact Request</title>
    
    <!-- Orbitron font linki -->
    <link href=""https://fonts.googleapis.com/css2?family=Orbitron:wght@400;700&display=swap"" rel=""stylesheet"">

    <style>
      body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        background: #0d0d0d;
        color: #ffffff;
        margin: 0;
        padding: 0;
      }

      .container {
        max-width: 600px;
        margin: 40px auto;
        background: #1a1a1a;
        border: 2px solid #8338ec;
        border-radius: 8px;
        overflow: hidden;
      }

      .header {
        background: linear-gradient(90deg, #ff006e, #8338ec, #3a86ff);
        padding: 20px;
        text-align: center;
      }

      .header img {
        width: 120px;
        margin-bottom: 10px;
      }

      .header h1 {
        margin: 0;
        font-size: 24px;
        color: #ffffff;
        text-shadow: 0 0 5px #ffbe0b;
        font-family: 'Orbitron', sans-serif;
      }

      .content {
        padding: 30px 20px;
      }

      .field {
        margin-bottom: 20px;
      }

      .field span {
        display: block;
        color: #ffbe0b;
        font-weight: bold;
        margin-bottom: 5px;
        font-size: 14px;
        font-family: 'Orbitron', sans-serif;
      }

      .field p {
        font-size: 16px;
        margin: 0;
        color: #ffffff;
        border-left: 4px solid #fb5607;
        padding-left: 10px;
      }

      .footer {
        padding: 20px;
        background: #0f0f0f;
        text-align: center;
        font-size: 12px;
        color: #888;
        font-family: 'Orbitron', sans-serif;
      }
    </style>
  </head>
  <body>
    <div class=""container"">
      <div class=""header"">
        <img src=""https://partyhubevent.blob.core.windows.net/event-medias/Group-1.png"" alt=""PartyHub Logo"" />
        <h1>New Contact Request</h1>
      </div>
      <div class=""content"">
        <div class=""field"">
          <span>First Name:</span>
          <p>{{firstName}}</p>
        </div>
        <div class=""field"">
          <span>Last Name:</span>
          <p>{{lastName}}</p>
        </div>
        <div class=""field"">
          <span>Email:</span>
          <p>{{email}}</p>
        </div>
        <div class=""field"">
          <span>Phone:</span>
          <p>{{phone}}</p>
        </div>
      </div>
      <div class=""footer"">
        This message was sent via the Get in Touch form on PartyHub.
      </div>
    </div>
  </body>
</html>
";

        var html = template
  .Replace("{{firstName}}", request.firstName)
  .Replace("{{lastName}}", request.lastName)
  .Replace("{{email}}", request.email)
  .Replace("{{phone}}", request.phone);


        var subject = $"[Get in touch] {DateTime.Now:dd/MM/yyy}";
        var fullname = request.firstName + request.lastName;
        try
        {
            await _mailService.SendEmailAsync(
                recipients: new[] { "mirtalibemirli217@gmail.com" },
                 subject: subject,
                 body: html,
                 fromEmail: request.email,
                 fromName: fullname,
                 isBodyHtml: true
                 );
            return new BaseResponseModel { IsSuccess = true, Message = "Email uğurla göndərildi.Tezliklə sizinlə əlaqə qurulacaq😊" };
        }
        catch (Exception ex)
        {

            return new BaseResponseModel
            {
                IsSuccess = false,
                Errors = new List<string> { ex.Message.ToString() }
            ,
                Message = "The problem is in the mailservice"
            };
        }
    }
}
