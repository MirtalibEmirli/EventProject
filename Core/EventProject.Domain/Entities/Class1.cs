//using EventProject.Domain.Entities;
//using EventProject.Domain.Enums;
//using System.ComponentModel;

//SqlException: The UPDATE statement conflicted with the FOREIGN KEY constraint "FK_Events_Categories_CategoryId". The conflict occurred in database "EventDatabase", table "dbo.Categories", column 'Id'. using EventProject.Application.ResponseModels.Generics;
//using EventProject.Domain.Enums;
//using MediatR;
//using System.ComponentModel;

//namespace EventProject.Application.Features.Commands.EventCommands.UpdateEvent;

//public class UpdateEventRequest : IRequest<ResponseModel<Unit>>
//{
//    public required Guid EventId { get; set; }

//    public string? Title { get; set; } = string.Empty;
//    public string? Description { get; set; } = string.Empty;
//    public DateTime? StartTime { get; set; }
//    public DateTime? EndTime { get; set; }
//    public int? AgeLimit { get; set; } = 0;
//    public Guid? LocationId { get; set; }
//    public float MinPrice { get; set; } = 0;

//    public float MaxPrice { get; set; } = 0;

//    public EventStatus? Status { get; set; }
//    public Guid? CategoryId { get; set; }
//    [DefaultValue(false)]
//    public bool IsTrend { get; set; } = false;

//}

////ternally ile
//using EventProject.Domain.Entities;
//using EventProject.Domain.Enums;

//public class Event : BaseEntity
//{
//    public string Title { get; set; } = string.Empty;

//    public string Description { get; set; } = string.Empty;

//    public DateTime StartTime { get; set; }
//    public bool IsTrend { get; set; } = false;

//    public int AgeLimit { get; set; }
//    public DateTime EndTime { get; set; }

//    public Guid LocationId { get; set; }
//    public virtual Venue Location { get; set; } = null!;

//    public float MinPrice { get; set; }
//    public float MaxPrice { get; set; }

//    public EventStatus Status { get; set; }  // Active, Canceled, Past

//    //// Foreign Keys
//    public Guid CategoryId { get; set; }
//    public Category Category { get; set; } = null!;






//    //// Relations
//    public ICollection<Ticket> Tickets { get; set; }
//    public ICollection<Comment> Comments { get; set; }
//    public ICollection<Payment> Payments { get; set; }
//    public IEnumerable<EventMediaFile> MediaFiles { get; set; }
//    public ICollection<EventSeatPrice> EventSeatPrices { get; set; } = new List<EventSeatPrice>();
//}
