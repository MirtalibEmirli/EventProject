namespace EventProject.Domain.Entities;

public class Ticket:BaseEntity
{
    public Guid EventId { get; set; }

    public Event Event { get; set; } = null!;

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public decimal Price { get; set; }
    //burda imaURL olmalidir 

    public string SeatNumber { get; set; } = string.Empty;

    public bool IsPaid { get; set; } = false;

    public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

}
