using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Enums;
using MediatR;
using System.ComponentModel;

namespace EventProject.Application.Features.Commands.EventCommands.UpdateEvent;

public class UpdateEventRequest:IRequest<ResponseModel<Unit>>
{ 
    public required Guid EventId { get; set; }

    public string? Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int? AgeLimit { get; set; } = 0;
    public Guid? LocationId { get; set; }
    public float MinPrice { get; set; } = 0;

    public float MaxPrice { get; set; } = 0;

    public EventStatus? Status { get; set; }
    public Guid? CategoryId { get; set; }
    [DefaultValue(false)]
    public bool IsTrend { get; set; } = false;

}

//ternally ile
