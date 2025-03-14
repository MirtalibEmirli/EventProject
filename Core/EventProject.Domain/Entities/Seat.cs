namespace EventProject.Domain.Entities;

public  class Seat:BaseEntity
{
    public string Section { get; set; } = null!;
    public string Row { get; set; } = null!;
    public int Number { get; set; }
    public bool IsBooked { get; set; } = false;

    public Guid VenueId { get; set; }
    public Venue Venue { get; set; }

    public Ticket? Ticket { get; set; } //eger bilet alinibsa 
}
