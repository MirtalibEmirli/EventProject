namespace EventProject.Domain.Entities;

public class EventSeatPrice:BaseEntity
{
    public Guid EventId { get; set; }
    public Event Event { get; set; }
     
    public Guid SeatId { get; set; }
    public Seat Seat { get; set; }

    public float Price { get; set; }


}
