using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Abstractions.Service;

public interface IMailService
{
    Task SendEmailAsync( IEnumerable<string> recipients,string subject,string body,string? fromEmail = null,string? fromName = null,bool isBodyHtml = true);



}
