namespace EventProject.Domain.Entities;

public class EventSeatPrice:BaseEntity
{
    public Guid EventId { get; set; }
    public virtual Event Event { get; set; }
     
    public Guid SeatId { get; set; }
    public virtual Seat Seat { get; set; }

    public float Price { get; set; }


}
