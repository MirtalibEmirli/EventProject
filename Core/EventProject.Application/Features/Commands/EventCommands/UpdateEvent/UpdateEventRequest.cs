using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Enums;
using MediatR;
using System.ComponentModel;

namespace EventProject.Application.Features.Commands.EventCommands.UpdateEvent;
public class UpdateEventRequest : IRequest<ResponseModel<Unit>>
{
    public required Guid EventId { get; set; }

    public string? Title { get; set; }
    public string? Description { get; set; }

    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public int? AgeLimit { get; set; }
    public Guid? LocationId { get; set; }

    public float MinPrice { get; set; } = 0;
    public float MaxPrice { get; set; } = 0;

    public EventStatus? Status { get; set; }
    public Guid? CategoryId { get; set; }

    public bool IsTrend { get; set; } 
}


//ternally ile
