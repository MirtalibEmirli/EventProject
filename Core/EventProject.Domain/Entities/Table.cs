namespace EventProject.Domain.Entities;

public class Table : BaseEntity
{
    public string TableName { get; set; } = null!; // məsələn: “VIP Table 1”

    public int Capacity { get; set; } // məsələn: 4 nəfərlik

    public Guid VenueId { get; set; }
    public virtual Venue Venue { get; set; } = null!;

    public Guid SectionId { get; set; }
    public virtual Section Section { get; set; } = null!;

    public virtual ICollection<EventTablePrice> EventTablePrices { get; set; } = new List<EventTablePrice>();
}
