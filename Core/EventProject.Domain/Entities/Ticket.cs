using EventProject.Domain.Enums;

namespace EventProject.Domain.Entities;

public class Ticket : BaseEntity
{
    public Guid EventId { get; set; }

    public virtual Event Event { get; set; } = null!;
 

    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;


    public decimal Price { get; set; }

    public DateTime PurchaseDate { get; set; }  

    public TicketStatus Status { get; set; }

    public string TicketNumber { get; set; } = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
    public bool IsScanned { get; set; } = false; // Girişdə istifadə üçün
    public string? QRCodePath { get; set; }
    public string VenueName { get; set; }
    public  string SectorName { get; set; }
    public int? Row { get; set; }

    public int? Seat { get; set; }

}
//Bilet necə yaranır?
//Variant A: Əvvəlcədən bilet yaratmaq
//Hər event üçün sistem avtomatik olaraq StandingZone, Seat, Table üzrə mövcud tutuma əsasən Ticket record-ları yaradır.

//İstifadəçi bilet alanda status Sold olur, qalanlar Available.

//Əlavə fayda: istifadəçi yer seçimi görə bilər.