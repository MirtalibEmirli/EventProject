using EventProject.Domain.Enums;

namespace EventProject.Domain.Entities;

public class Ticket:BaseEntity
{
    public Guid EventId { get; set; }

    public Event Event { get; set; } = null!;

    public Guid? SeatId { get; set; }
    public Seat? Seat { get; set; }

    public Guid? StandingZoneId { get; set; }
    public StandingZone? StandingZone { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;


    public decimal Price { get; set; }

    public DateTime PurchaseDate { get; set; } //alinma tarixi

    public TicketStatus Status { get; set; }
   



}
