namespace EventProject.Domain.Entities;

public class SectionPrice:BaseEntity
{

    public decimal Price { get; set; }
    public Guid SectionId { get; set; }
    public Guid EventId { get; set; }

    public virtual Section Section { get; set; }
    public virtual Event Event { get; set; }

}
