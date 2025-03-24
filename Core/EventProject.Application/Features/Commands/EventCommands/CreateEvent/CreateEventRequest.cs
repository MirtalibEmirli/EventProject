using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using EventProject.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EventProject.Application.Features.Commands.EventCommands.CreateEvent;

public class CreateEventRequest : IRequest<ResponseModel<Guid>>
{

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int AgeLimit { get; set; }
    public Guid LocationId { get; set; }
    public float MinPrice { get; set; }
    public float MaxPrice { get; set; }
    public EventStatus Status { get; set; }
    public Guid CategoryId { get; set; }



}

