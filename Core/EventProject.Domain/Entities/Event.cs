
using EventProject.Domain.Enums;
namespace EventProject.Domain.Entities;
public class Event : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }
    public bool IsTrend { get; set; } = false;

    public int AgeLimit { get; set; }
    public DateTime EndTime { get; set; }

    public Guid LocationId { get; set; }


    public float MinPrice { get; set; }
    public float MaxPrice { get; set; }

    public EventStatus Status { get; set; }  // Active, Canceled, Past

    //// Foreign Keys
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
    public virtual ICollection<UserRwEvent> UserRwEvents { get; set; }
    public virtual ICollection<SectionPrice> SectionPrices { get; set; }

    //// Relations
    public virtual Venue Location { get; set; } = null!;
    public virtual ICollection<Ticket> Tickets { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
    public virtual IEnumerable<EventMediaFile> MediaFiles { get; set; }
}
