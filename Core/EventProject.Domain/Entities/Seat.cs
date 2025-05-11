using System.ComponentModel.DataAnnotations.Schema;

namespace EventProject.Domain.Entities;

//venue -seat  one-many  

public  class Seat:BaseEntity
{
    public string Section { get; set; } = null!;
    public int Row { get; set; } 
    public int Number { get; set; }
    public bool IsBooked { get; set; } = false;

    public float? X { get; set; }     // 3D koordinat
    public float? Y { get; set; }     // 3D koordinat
    public float? Z { get; set; }     // 3D koordinat

    public float? RotationY { get; set; }

    public int? Capacity { get; set; }

    public Guid VenueId { get; set; }

    [ForeignKey(nameof(VenueId))]
    public virtual Venue Venue { get; set; }

    public virtual ICollection<EventSeatPrice> EventSeatPrices { get; set; }
      = new HashSet<EventSeatPrice>();

    public virtual Ticket? Ticket { get; set; } //eger bilet alinibsa 
}
