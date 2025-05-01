
using EventProject.Domain.Enums;
namespace EventProject.Domain.Entities;
public class Event:BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }
    public bool IsTrend { get; set; } = false;

    public int AgeLimit { get; set; }
    public DateTime EndTime { get; set; }

    public Guid LocationId { get; set; }
    public virtual Venue Location { get; set; } = null!;

    public float MinPrice { get; set; }
    public float MaxPrice { get; set; }

    public EventStatus Status { get; set; }  // Active, Canceled, Past

    //// Foreign Keys
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;


 
   


    //// Relations
    public ICollection<Ticket> Tickets { get; set; } 
    public ICollection<Comment> Comments { get; set; } 
    public ICollection<Payment> Payments { get; set; } 
    public IEnumerable<EventMediaFile> MediaFiles { get; set; }
    public ICollection<EventSeatPrice> EventSeatPrices { get; set; } = new List<EventSeatPrice>();
}
