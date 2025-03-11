using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EventProject.Application.Features.Commands.EventCommands.CreateEvent;

    public class CreateEventRequest:IRequest<ResponseModel<CreateEventResponse>>
    {

    public string CategoryName { get; set; }
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    //vaxti da yoxla
    public DateTime StartTime { get; set; }

    public int AgeLimit { get; set; }
    public DateTime EndTime { get; set; }

    public string Location { get; set; } = string.Empty;

    public decimal Price { get; set; } = 0;

   
    public List<IFormFile> Medias { get; set; }
         
    }

