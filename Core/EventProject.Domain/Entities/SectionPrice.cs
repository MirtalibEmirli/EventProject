namespace EventProject.Domain.Entities;

public class SectionPrice:BaseEntity
{

    public decimal Price { get; set; }
    public Guid SectionId { get; set; }

    public Section Section { get; set; }

    public Event Event { get; set; }
    public Guid EventId { get; set; }

}