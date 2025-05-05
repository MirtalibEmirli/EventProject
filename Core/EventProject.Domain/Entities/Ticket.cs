using EventProject.Domain.Enums;

namespace EventProject.Domain.Entities;

public class Ticket:BaseEntity
{ 
    public Guid EventId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public Guid? SeatId { get; set; }
    public virtual Seat? Seat { get; set; }

    public Guid? StandingZoneId { get; set; }
    public virtual StandingZone? StandingZone { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;


    public float Price { get; set; }

    public DateTime PurchaseDate { get; set; } //alinma tarixi

    public TicketStatus Status { get; set; }
   



}
