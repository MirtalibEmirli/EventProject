using EventProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.UserCommands.Login
{
    public class LoginResponse
    {
     public   Token? Token { get; set; }   
    }
}
